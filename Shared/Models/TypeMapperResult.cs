using System;

namespace Shared.Models
{
    public class TypeMapperResult<T>
    {
        public TypeMapperResult(T item, bool converted, Exception exception)
        {
            Item = item;
            Converted = converted;
            Exception = exception;
        }

        public T Item { get; private set; }

        public bool Converted { get; private set; }

        public Exception Exception { get; private set; }
    }
}