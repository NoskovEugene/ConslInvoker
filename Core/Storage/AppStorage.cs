using System.IO;
using System.Collections.Generic;
using Core.Storage.Models;
using Models;   
using UI.MessengerUI;
using UI.Request;

namespace Core.Storage
{


    public class AppStorage : IAppStorage
    {
        Dictionary<string, StorageItem> Storage = new Dictionary<string, StorageItem>();

        protected IMessenger Messenger { get; set; }

        protected IRequester Requester { get; set; }

        private string DirectoryPath { get;}

        private const string APPSTORAGEPATH = "ApplicationStorage";

        public AppStorage(IMessenger messenger, IRequester requester)
        {
            this.Messenger = messenger;
            this.Requester = requester;
            this.DirectoryPath = Path.Combine(Directory.GetCurrentDirectory(),APPSTORAGEPATH);
            if(!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }

        public void Insert<T>(string key, T instance)
        {
            Storage.Add(key, new StorageItem(instance, key, typeof(T)));
        }

        public bool Delete(string key)
        {
            return Storage.Remove(key);
        }

        /// <summary>
        /// Производит поиск элемента в хранилище
        /// Если элемент не будет найден будет возращёт default
        /// Если элемент будет найдет, но тип не будет совпадать с T будет возвращён default
        /// </summary>
        /// <param name="key">Ключ значения в хранилище</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Find<T>(string key)
        {
            if (Storage.ContainsKey(key))
            {
                var storageItem = Storage[key];
                if (typeof(T) != storageItem.Type)
                {
                    return default(T);
                }
                return (T)storageItem.Item;
            }
            return default(T);
        }


        /// <summary>
        /// Производит поиск элемента в хранилище
        /// Если элемент не будет найден будет возращёт default
        /// </summary>
        /// <param name="key">Ключ значения в хранилище</param>
        /// <returns></returns>
        public object Find(string key)
        {
            if (Storage.ContainsKey(key))
            {
                var item = Storage[key];
                return item.Item;
            }
            return null;
        }

    }
}