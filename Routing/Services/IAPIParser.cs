
using Shared.Models;

namespace Routing.Services
{
    public interface IAPIParser
    {
        Utility GetApiMap<T>();
    }
}