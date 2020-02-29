using FizzBuzzCore.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzzCore
{
    public class FizzBuzz
    {
        public static Task<List<string>> DoFizzBuzzAsync(int start, Dictionary<int, string> fizzBuzzParams, int limit = 100)
        {
            if (start > limit ) throw new InvalidRangeException("The starting number must be lower than the ending.");
            if (fizzBuzzParams.ContainsKey(0)) throw new InvalidKeyException("The value of the key must not be equals to 0");

            var task = Task<List<string>>.Factory.StartNew(() =>
            {
                List<string> result = new List<string>();

                for (int i = start; i < limit; i++)
                {
                    string text = string.Empty;

                    foreach (var item in fizzBuzzParams)
                    {
                        text += i % item.Key == 0 ? item.Value : string.Empty;
                    }

                    result.Add(string.IsNullOrEmpty(text) ? i.ToString() : text);
                }

                return result;
            });

            return task;
        }
    }
}

