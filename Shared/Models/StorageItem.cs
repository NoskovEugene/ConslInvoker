using System;

namespace Shared.Models
{
    [Serializable]
    public class StorageItem
    {
        public StorageItem(object item, string key, Type type)
        {
            Item = item;
            Key = key;
            Type = type;
        }

        public object Item { get; set; }

        public string Key { get; set; }

        public Type Type { get; set; }

        
    }
}