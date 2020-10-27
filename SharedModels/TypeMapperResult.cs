using System;

namespace SharedModels
{
    public class TypeMapperResult<T>
    {
        public TypeMapperResult(T item, bool converter, Exception exception)
        {
            Item = item;
            Converter = converter;
            Exception = exception;
        }

        public T Item { get; private set; }

        public bool Converter { get; private set; }

        public Exception Exception { get; private set; }
    }
}