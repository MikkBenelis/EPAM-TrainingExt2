using System;
using System.Collections.Generic;

namespace No6.Solution
{
    public static class SequenceGenerator
    {
        public static IEnumerable<T> Generate<T>(int count, T first, T second, Func<T, T, T> generator)
        {
            if (count < 0)
            {
                throw new ArgumentException();
            }

            T prev = first;
            T next = second;
            for (int i = 0; i < count; i++)
            {
                switch (i)
                {
                    case 0:
                        yield return prev;
                        break;
                    case 1:
                        yield return next;
                        break;
                    default:
                        T temp = generator(next, prev);
                        prev = next;
                        next = temp;
                        yield return next;
                        break;
                }
            }
        }
    }
}
