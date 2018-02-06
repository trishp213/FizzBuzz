using System.Collections.Generic;

namespace Domain
{
    public class FizzBuzzService
    {
        public int MaxNumber { get; set; }
        public int MinNumber { get; set; }

        private readonly Dictionary<int, string> _maps = new Dictionary<int, string>();

        public FizzBuzzService()
        {
            MinNumber = 1;
            MaxNumber = 100;
        }

        public void SetToDefaultValues()
        {
            MinNumber = 1;
            MaxNumber = 100;

            _maps.Clear();

            AddMap(3, "Fizz");
            AddMap(5, "Buzz");
        }

        public void AddMap(int number, string word)
        {
            if (!_maps.ContainsKey(number))
            {
                _maps.Add(number, word);
            }
            else
            {
                _maps[number] = word;
            }

        }

        public string GetValueForNumber(int number)
        {
            var retVal = "";

            foreach (var map in _maps)
            {
                if (number%map.Key == 0)
                {
                    retVal += map.Value;
                }
            }

            if (string.IsNullOrEmpty(retVal))
            {
                retVal = number.ToString();
            }

            return retVal;
        }


        public IEnumerable<string> GetAllValues()
        {
            for (var i = MinNumber; i <= MaxNumber; i++)
            {
                yield return GetValueForNumber(i);
            }
        }
    }
}