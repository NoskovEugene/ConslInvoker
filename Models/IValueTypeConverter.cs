namespace Models
{
    public interface IValueTypeConverter<TIn,TOut>
    {
        TOut Convert(TIn instance);
    }
}