using System;
namespace Shared.Models.Packages
{
    public class Package<T>
    {
        public Package(T payLoad, string from = "", string to = "", Type fromType = null, Type toType = null)
        {
            From = from;
            To = to;
            FromType = fromType;
            ToType = toType;
            PayLoad = payLoad;
        }

        public string From { get; set; }

        public string To { get; set; }

        public Type FromType { get; set; }

        public Type ToType { get; set; }

        public T PayLoad { get; set; }
    }
}
