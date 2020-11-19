using System.Linq;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
namespace Routing.Services
{
    public class StringService : IStringService
    {
        protected List<Profile> Profiles { get; set; } = new List<Profile>();

        protected int Counter { get; set; }

        protected Profile CurrentProfile { get; set; }

        public StringService()
        {

        }

        public int AddProfile()
        {
            var profile = new Profile() { Id = Counter };
            Profiles.Add(profile);
            Counter++;
            return profile.Id;
        }

        public IStringService SetPattern(int id, string pattern)
        {
            if(TryGetProfile(id,out var profile))
            {
                profile.RegexPattern =pattern;
                profile.CurrentRegex = new Regex(pattern);
            }
            return this;
        }

        public IStringService SetRemoveStat(int id,bool remove)
        {
            if(TryGetProfile(id,out var profile))
            {
                profile.Remove = remove;
            }
            return this;
        }

        public IStringService SetInputLine(int id,string input, Action<string> updateAction = null)
        {
            if(TryGetProfile(id,out var profile))
            {
                profile.InputLine = input;
                profile.UpdateAction = updateAction;
            }
            return this;
        }

        public (bool success, string output) Next(int id)
        {
            if(TryGetProfile(id, out var profile))
            {
                var match = profile.CurrentRegex.Match(profile.InputLine);
                if(match.Value == string.Empty)
                {
                    return (false, "");
                }
                if(profile.Remove)
                {
                    profile.InputLine = profile.InputLine.Replace(match.Value, string.Empty).Trim();
                    if(profile.UpdateAction != null)
                    {
                        profile.UpdateAction(profile.InputLine);
                    }
                }
                return (true, match.Value);
            }
            else
            {
                throw new Exception("Profile not found");
            }
        }

        private bool TryGetProfile(int id, out Profile profile)
        {
            profile = Profiles.Where(x=> x.Id == id).FirstOrDefault();
            return profile != null;
        }

        public void RemoveProfile(int id)
        {
            if(TryGetProfile(id, out var profile))
            {
                Profiles.Remove(profile);
            }
        }
    }
}
