// See https://johnrush.github.io/File-Encryption-Tutorial/

// .NET Cryptography
// See https://learn.microsoft.com/en-us/dotnet/standard/security/cryptography-model
// See https://learn.microsoft.com/en-us/dotnet/standard/security/cross-platform-cryptography
// See https://learn.microsoft.com/en-us/dotnet/standard/security/cryptographic-services

// MS given Symmetric Cryptography Demo
// See https://learn.microsoft.com/en-us/dotnet/standard/security/encrypting-data
// See https://learn.microsoft.com/en-us/dotnet/standard/security/decrypting-data
// See https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.cryptostream?view=net-7.0

// AES algorithm - Symmetric and Asymmetric
// See https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-7.0
// See https://learn.microsoft.com/en-us/dotnet/standard/security/generating-keys-for-encryption-and-decryption

// RSA algorithm - Asymmetric
// see https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsa?view=net-7.0
// See https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsaparameters?view=net-7.0
// See https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsa.importparameters?view=net-7.0

using System.Security.Cryptography;
using EncryptionAttempt;

RSA rsa = RSA.Create();
Aes aes = Aes.Create();

EncryptDecrypt.Encrypt();
EncryptDecrypt.Decrypt();