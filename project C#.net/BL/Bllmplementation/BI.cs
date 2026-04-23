using BlApi;


namespace Bllmplementation;

internal class BI:IBI
{
    public ICastumer Customer => new CustemerImplementation();
    public IProduct Product => new ProductImplementation();
    public ISale Sale => new SaleImplementation();

    public IOrder Order => new OrderImplementation();
}
