

//using DalApi;

using BO;

namespace BlApi;

public interface IBI
{
    public ICastumer Castumer { get; }
    public IProduct product { get; }
    public IOrder order { get; }
    public ISale sale { get; }

}
