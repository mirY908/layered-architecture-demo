using BO;


namespace BlApi;

public interface IOrder
{
    List<SaleInProduct> AddProductToOrder( int code, int amount);

    void CalcTotalPriceForProduct(ProductInOrder productInOrder);
    List<SaleInProduct> AddProductToOrder(Order order, int productId, int amountInOrder);
    void CalcTotalPrice(Order order);



    void SearchSaleForProduct(ProductInOrder productInOrder, bool isFavorate);
   
    void DoOrder(Order order);
    IEnumerable<object> ReadAll();
}
