using System.Linq;
using System.Collections.Generic;
namespace Core.Maps
{
    public class Map<TIn, TOut> : IMap<TIn, TOut>
    {
        public List<MapItem<TIn, TOut>> Items { get; set; } = new List<MapItem<TIn, TOut>>();

        public void Register(TIn inputItem, TOut outputItem)
        {
            Items.Add(new MapItem<TIn, TOut>(inputItem, outputItem));
        }

        MapItem<TIn, TOut> IMap<TIn, TOut>.Map(TIn inputItem, TOut OutputItem)
        {
            return Items.Where(x=> x.InputItem.Equals(inputItem) && x.OutputItem.Equals(OutputItem)).First();
        }
    }
}
