namespace Shared.Models
{
    public interface IValueTypeConverter<TIn,TOut>
    {
        TOut Convert(TIn instance);
    }
}