using Shared.Models;
using Shared.Models.Packages;
using Shared.Models.Router;

namespace Routing
{
    public interface IRouter
    {
        void AddApi<T>();
        NeedRout GetRout(Package<UserPackage> package);
    }
}
