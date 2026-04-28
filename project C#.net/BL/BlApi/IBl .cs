

//using DalApi;

using BO;

namespace BlApi;

public interface IBI
{
    public ICastumer customer { get; }
    public IProduct product { get; }
    public IOrder order { get; }
    public ISale sale { get; }

}
