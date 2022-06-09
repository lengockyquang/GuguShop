namespace GuguShop.Infrastructure.Utility;

public interface ICustomJwtGenerator
{
    string GenerateToken(string userName);
    bool ValidateCurrentToken(string token);
}