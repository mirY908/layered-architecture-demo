using BlApi;


namespace BlImplementation;

internal class BI : IBI
{
    public ICastumer customer => new CustemerImplementation();
    public IProduct product => new ProductImplementation();
    public ISale sale => new SaleImplementation();
    public IOrder order => new OrderImplementation();
}
