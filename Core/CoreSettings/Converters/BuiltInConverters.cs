using SharedModels;
namespace Core.CoreSettings.Converters
{
    public class StringToInt : IValueTypeConverter<string, int>
    {
        public int Convert(string instance) => int.Parse(instance);
    }
    public class StringToDouble : IValueTypeConverter<string, double>
    {
        public double Convert(string instance) => double.Parse(instance);
    }
}