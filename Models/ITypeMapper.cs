namespace Models
{
    public interface ITypeMapper
    {
        TypeMapperResult<TOut> Map<TIn, TOut>(TIn instance);
    }
}