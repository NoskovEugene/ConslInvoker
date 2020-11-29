namespace Core.Maps
{
    public interface IMap<TIn,TOut>
    {
		void Register(TIn inputItem, TOut outputItem);

		MapItem<TIn,TOut> Map(TIn inputItem, TOut OutputItem);
    }
}
