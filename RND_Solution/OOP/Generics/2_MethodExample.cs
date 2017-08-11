using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace OOP.Generics
{
    class _2_MethodExample
    {
        private static T Add<T>(T firstVal, T secondVal)
        {
            ParameterExpression paramFirstValue = Expression.Parameter(typeof(T), "firstVal");
            ParameterExpression paramSecondValue = Expression.Parameter(typeof(T), "secondVal");

            BinaryExpression body;

            body = Expression.Add(paramFirstValue, paramSecondValue);

            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(body, paramFirstValue, paramSecondValue).Compile();

            return add(firstVal,secondVal);
        }

        private static T Sub<T>(T firstParam, T secondParam)
        {
            ParameterExpression paramFirst = Expression.Parameter(typeof(T), "firstParam");
            ParameterExpression paramSecond = Expression.Parameter(typeof(T), "secondParam");

            BinaryExpression body = Expression.Subtract(paramFirst, paramSecond);

            Func<T, T, T> sub = Expression.Lambda<Func<T, T, T>>(body, paramFirst, paramSecond).Compile();
            return sub.Invoke(firstParam, secondParam);

        }

        public static void Main1(string[] arg)
        {
            Console.WriteLine(Add(10, 20));
            Console.WriteLine(Add(10.10, 20.21));

            Console.WriteLine(Sub(10, 20));
            Console.WriteLine(Sub(10.10, 20.21));

            Console.Read();
        }
    }
}
