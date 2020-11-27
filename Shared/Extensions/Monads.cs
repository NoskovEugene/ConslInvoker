using System;
namespace Shared.Extensions
{
    public static class Monads
    {
        public static TOut Load<TIn,TOut>(this TIn input, Func<TIn,TOut> func)
		where TIn : class
		where TOut: class
		{
			if(input  == null) return null;
			return func(input);
		}

		public static TIn If<TIn>(this TIn input, Predicate<TIn> predicate)
		where TIn : class
		{
			if(input == null) return null;
			return predicate(input) ? input : null;
		}

		public static bool NotNull<TIn>(this TIn input)
		where TIn : class
		{
			return input != null;
		}

		public static (TIn input, bool notNull) NotNullWithContext<TIn>(this TIn input)
		{
			return (input, input != null);
		}

		public static TIn Do<TIn,TOut> (this TIn input, Action<TIn> action)
		where TIn: class
		where TOut: class
		{
			if(input == null) return null;
			action(input);
			return input.NotNullWithContext().input;
		}

		public static TOut Convert<TIn, TOut>(this TIn input, Func<TIn, TOut> converter)
		where TIn : class
		where TOut : class
		{
			if(input == null) { return null; }
			return converter(input);
		}

		public static TOut Select<TIn,TOut>(this TIn input, Func<TIn,TOut> selector)
		where TIn : class
		where TOut : class
		{
			if(input == null) return null;
			return selector(input);
		}
    }
}
