namespace GuguShop.Infrastructure.Utility;

public interface IAuthUser
{
    public bool IsAuthenticated { get;}
    public string UserName {get;}
    
}