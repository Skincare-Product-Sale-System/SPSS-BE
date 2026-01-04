using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Shared.Security;

/// <summary>
/// Helper class for secure password hashing and verification using PBKDF2
/// </summary>
public static class PasswordHelper
{
    private const int SaltSize = 128 / 8; // 16 bytes
    private const int HashSize = 256 / 8; // 32 bytes
    private const int Iterations = 100000; // OWASP recommends at least 100,000 iterations for PBKDF2-SHA256

    /// <summary>
    /// Hashes a password using PBKDF2 with a random salt
    /// </summary>
    /// <param name="password">The password to hash</param>
    /// <returns>A string containing the salt and hash, separated by a period</returns>
    public static string HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentNullException(nameof(password));

        // Generate a random salt
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

        // Hash the password
        byte[] hash = KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: Iterations,
            numBytesRequested: HashSize);

        // Combine salt and hash, then encode as base64
        byte[] hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

        return Convert.ToBase64String(hashBytes);
    }

    /// <summary>
    /// Verifies a password against a stored hash
    /// </summary>
    /// <param name="password">The password to verify</param>
    /// <param name="storedHash">The stored hash to verify against</param>
    /// <returns>True if the password matches, false otherwise</returns>
    public static bool VerifyPassword(string password, string storedHash)
    {
        if (string.IsNullOrEmpty(password))
            return false;

        if (string.IsNullOrEmpty(storedHash))
            return false;

        try
        {
            // Decode the stored hash
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Check if it's a valid hash (old plain text passwords won't be base64 encoded properly)
            if (hashBytes.Length != SaltSize + HashSize)
            {
                // Fallback: Direct comparison for migration from plain text
                // This should be removed after all passwords are migrated
                return password == storedHash;
            }

            // Extract the salt
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Hash the provided password with the same salt
            byte[] hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: Iterations,
                numBytesRequested: HashSize);

            // Compare the hashes
            for (int i = 0; i < HashSize; i++)
            {
                if (hashBytes[SaltSize + i] != hash[i])
                    return false;
            }

            return true;
        }
        catch (FormatException)
        {
            // If the stored hash is not valid base64, it might be a plain text password (legacy)
            // This allows migration from plain text passwords
            return password == storedHash;
        }
    }

    /// <summary>
    /// Checks if a password hash needs to be upgraded (e.g., from plain text)
    /// </summary>
    /// <param name="storedHash">The stored hash to check</param>
    /// <returns>True if the hash needs to be upgraded</returns>
    public static bool NeedsUpgrade(string storedHash)
    {
        if (string.IsNullOrEmpty(storedHash))
            return true;

        try
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);
            return hashBytes.Length != SaltSize + HashSize;
        }
        catch (FormatException)
        {
            // Not valid base64, needs upgrade
            return true;
        }
    }
}
