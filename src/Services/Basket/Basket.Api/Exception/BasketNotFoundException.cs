namespace Basket.Api.Exception;

public class BasketNotFoundException : NotFoundException
{
    public BasketNotFoundException(string username) : base("name", username)
    {
    }
}