using BO;


namespace BlApi;

public interface IOrder
{
    List<SaleInProduct> AddProductToOrder( int code, int amount);

    void CalcTotalPriceForProduct(ProductInOrder productInOrder);

    void CalcTotalPrice(Order order);

    void DoOrder(Order order);
    IEnumerable<object> ReadAll();
}
