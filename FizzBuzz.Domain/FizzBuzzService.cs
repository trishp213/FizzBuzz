using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;

namespace FizzBuzz.Domain
{
    /// <summary>
    /// Generates a list of strings, from min to max, replacing configured numbers with configurable words
    /// </summary>
    public class FizzBuzzService
    {
        /// <summary>
        /// The number to finish the count at
        /// Must be positive and greater than MinNumber
        /// Default value is 100
        /// </summary>
        private int _maxNumber;
        public int MaxNumber
        {
            get
            {
                return _maxNumber;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("MaxNumber", "MaxNumber cannot be negative");
                }

                if (value < MinNumber)
                {
                    throw new ArgumentOutOfRangeException("MaxNumber", "MinNumber must be less than MaxNumber");
                }
                _maxNumber = value;
            }
        }

        /// <summary>
        /// The number to start the count at
        /// Must be positive and less than MaxNumber
        /// Default value is 1
        /// </summary>
        private int _minNumber;
        public int MinNumber 
        {
            get
            {
                return _minNumber;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("MinNumber", "MinNumber cannot be negative");
                }

                if (value > MaxNumber)
                {
                    throw new ArgumentOutOfRangeException("MinNumber must be less than MaxNumber");
                }

                _minNumber = value;
            } 
        }

        /// <summary>
        /// Stores the list of number/string pairs to to replace
        /// </summary>
        private readonly Dictionary<int, string> _maps;

        public FizzBuzzService()
        {
            _maps = new Dictionary<int, string>();
            MaxNumber = 100;
            MinNumber = 1;
        }

        /// <summary>
        /// Adds a number word pair to the list of replacements
        /// If there is already a replacement for this number, it overwrites that word
        /// </summary>
        /// <param name="number">The number to replace</param>
        /// <param name="word">The string to output instead of the number</param>
        /// Throws ArgumentOutOfRangeException if number is not between MinNumber and MaxNumber
        public void AddMap(int number, string word)
        {
            if (number < MinNumber || number > MaxNumber)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Number must be between MinNumber and MaxNumber");
            }

            if (!_maps.ContainsKey(number))
            {
                _maps.Add(number, word);
            }
            else
            {
                _maps[number] = word;
            }

        }

        /// <summary>
        /// Gets the string for the specified number
        /// </summary>
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

        /// <summary>
        /// Gets all strings with replacements
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllValues()
        {
            for (var i = MinNumber; i <= MaxNumber; i++)
            {
                yield return GetValueForNumber(i);
            }
        }
    }
}