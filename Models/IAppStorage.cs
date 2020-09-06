namespace Models
{
    public interface IAppStorage
    {

        /// <summary>
        /// Remove element by the key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Delete(string key);

        /// <summary>
        /// Find element in storage by the key
        /// If element not found will be returned default
        /// If element founded but type not equal with T will be returned default
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Find<T>(string key);

        /// <summary>
        /// Find element in storage by the key
        /// If element not found will be returned default
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object Find(string key);

        /// <summary>
        /// Insert item in storage
        /// </summary>
        /// <param name="key"></param>
        /// <param name="instance"></param>
        /// <typeparam name="T"></typeparam>
        void Insert<T>(string key, T instance);

        // /// <summary>
        // /// Load storage from file
        // /// </summary>
        // /// <param name="storageName"></param>
        // void Load(string storageName);

        // /// <summary>
        // /// Save storage to file
        // /// </summary>
        // /// <param name="storageName"></param>
        // void Save(string storageName);
    }
}