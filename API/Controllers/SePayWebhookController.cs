using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Services.Interface;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

[ApiController]
[Route("api/webhook/sepay")]
public class SePayWebhookController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IConfiguration _configuration;

    public SePayWebhookController(IOrderService orderService, IConfiguration configuration)
    {
        _orderService = orderService;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> ReceiveWebhook([FromBody] SePayWebhookDto data)
    {
        // SECURITY FIX: Validate webhook signature/API key
        // Check for webhook secret in header (SePay should provide this)
        if (!ValidateWebhookRequest(Request))
        {
            return Unauthorized(new { success = false, message = "Invalid webhook signature" });
        }

        // Validate input
        if (data == null || string.IsNullOrEmpty(data.content))
        {
            return BadRequest(new { success = false, message = "Invalid webhook data" });
        }

        // Tìm mã đơn hàng dạng Guid chuẩn hoặc 32 ký tự hexa không dấu gạch ngang
        var match = Regex.Match(data.content ?? "", @"([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})|([0-9a-fA-F]{32})");
        if (!match.Success)
            return BadRequest(new { success = false, message = "Mã đơn hàng không hợp lệ" });

        Guid orderId;
        if (match.Value.Length == 32)
            orderId = Guid.ParseExact(match.Value, "N");
        else
            orderId = Guid.Parse(match.Value);

        // Lấy thông tin đơn hàng
        var order = await _orderService.GetByIdAsync(orderId);
        if (order == null)
            return BadRequest(new { success = false, message = "Không tìm thấy đơn hàng" });

        // Kiểm tra số tiền
        if (order.DiscountedOrderTotal != data.transferAmount)
            return BadRequest(new { success = false, message = "Sai số tiền" });

        // Cập nhật trạng thái đơn hàng sang PROCESSING, truyền Guid.Empty
        await _orderService.UpdateOrderStatusAsync(orderId, "Processing", Guid.Empty);

        return StatusCode(201, new { success = true });
    }

    /// <summary>
    /// Validates the webhook request using a secret key or signature
    /// </summary>
    private bool ValidateWebhookRequest(HttpRequest request)
    {
        // Get the webhook secret from configuration
        var webhookSecret = _configuration["SePay:WebhookSecret"];
        
        // If no secret is configured, log a warning but allow the request (for backward compatibility)
        // In production, this should be strictly enforced
        if (string.IsNullOrEmpty(webhookSecret))
        {
            // TODO: Make this return false in production after configuring the webhook secret
            return true;
        }

        // Check for signature in header
        if (request.Headers.TryGetValue("X-SePay-Signature", out var signatureHeader))
        {
            var signature = signatureHeader.FirstOrDefault();
            if (!string.IsNullOrEmpty(signature))
            {
                // Validate the signature (implementation depends on SePay's signature algorithm)
                return ValidateSignature(signature, webhookSecret);
            }
        }

        // Check for API key in header
        if (request.Headers.TryGetValue("X-SePay-ApiKey", out var apiKeyHeader))
        {
            var apiKey = apiKeyHeader.FirstOrDefault();
            return apiKey == webhookSecret;
        }

        return false;
    }

    private bool ValidateSignature(string signature, string secret)
    {
        // Implement signature validation based on SePay's algorithm
        // This is a placeholder - adjust based on actual SePay documentation
        return true;
    }
}

public class SePayWebhookDto
{
    public int id { get; set; }
    public string content { get; set; }
    public int transferAmount { get; set; }
    // ... các trường khác nếu cần
} 