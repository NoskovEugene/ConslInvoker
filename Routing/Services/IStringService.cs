using System;
namespace Routing.Services
{
    public interface IStringService
    {
        int AddProfile();

        void RemoveProfile(int id);

        IStringService SetPattern(int id, string pattern);
        
        IStringService SetRemoveStat(int id,bool remove);

        IStringService SetInputLine(int id,string input, Action<string> updateAction = null);

        (bool success, string output) Next(int id);

    }
}