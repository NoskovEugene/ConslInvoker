namespace Core.Maps
{
    public class MapItem<TIn, TOut>
    {
        public MapItem(TIn inputItem, TOut outputItem)
        {
            InputItem = inputItem;
            OutputItem = outputItem;
        }

        public TIn InputItem { get; set; }

        public TOut OutputItem { get; set; }
    }
}
