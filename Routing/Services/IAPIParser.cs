using Shared.Models.Router;

namespace Routing.Services
{
    public interface IAPIParser
    {
        Utility GetApiMap<T>();
    }
}
