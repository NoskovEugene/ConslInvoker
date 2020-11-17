using Shared.Models;

namespace Routing
{
    public interface IRouter
    {
        void AddApi<T>();
        NeedRout GetRout(Package package);
    }
}