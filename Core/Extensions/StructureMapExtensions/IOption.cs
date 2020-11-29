namespace Core.Extensions.StructureMapExtensions
{
    public interface IOption<T>
        where T : class, new()
    {
        T Value { get; set; }
    }
}
