using Bllmplementation;
namespace BlApi
{
    public static class Factory
    {
        public static IBI Get()
        {
            IBI BI = new BI();
            return BI;
        }
    }
}
