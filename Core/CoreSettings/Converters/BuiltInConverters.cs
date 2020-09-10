using Models;
namespace Core.CoreSettings.Converters
{
    public class StringToInt : IValueTypeConverter<string, int>
    {
        public int Convert(string instance)
        {
            return int.Parse(instance);
        }
    }

    public class StringToDouble : IValueTypeConverter<string, double>
    {
        public double Convert(string instance)
        {
            return double.Parse(instance);
        }
    }
}