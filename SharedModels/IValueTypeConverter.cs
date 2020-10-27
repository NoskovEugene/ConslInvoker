namespace SharedModels
{
    public interface IValueTypeConverter<TIn,TOut>
    {
        TOut Convert(TIn instance);
    }
}