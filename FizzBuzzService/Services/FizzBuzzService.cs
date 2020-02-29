using FizzBuzzCore;
using FizzBuzzService.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzzService.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public Task<List<string>> DoFizzBuzzAsync(int start, Dictionary<int, string> fizzBuzzParams, int limit)
        {
            return FizzBuzz.DoFizzBuzzAsync(start, fizzBuzzParams, limit);
        }
    }
}
