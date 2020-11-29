namespace Core.Extensions.StructureMapExtensions
{
    public class Option<T> : IOption<T>
        where T : class, new()
    {
        public T Value { get; set; }
    }
}
