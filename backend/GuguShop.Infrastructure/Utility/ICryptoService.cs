namespace GuguShop.Infrastructure.Utility;

public interface ICryptoService
{
    string Encrypt(string plainText, string passPhrase);
    string Decrypt(string cipherText, string passPhrase);
}