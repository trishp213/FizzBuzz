using System;
using FizzBuzz.Domain;

namespace CMFB
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizzBuzzService = new FizzBuzzService()
            {
                MinNumber = GetNumericInputFromUser("Enter the min number to start from", 1),
                MaxNumber = GetNumericInputFromUser("Enter the max number to stop at", 100)
            };
            
            fizzBuzzService.AddMap(
                GetNumericInputFromUser("Enter first number to replace, or hit enter to use the default of 3", 3),
                GetStringInputFromUser("Enter fizz word, or hit enter to just use the default of Fizz", "Fizz")
                );

            fizzBuzzService.AddMap(
               GetNumericInputFromUser("Enter next number to replace, or hit enter to use the default of 5", 5),
               GetStringInputFromUser("Enter buzz word, or hit enter to just use the default of Buzz", "Buzz")
               );

            while (true)
            {
                var number = GetNumericInputFromUser("Enter another number to replace, or hit enter get the results", -1);
                if (number == -1)
                {
                    break;
                }

                var word = GetStringInputFromUser($"Enter the replacement word for number {number}, or hit enter to get the results", string.Empty);
                if (string.IsNullOrEmpty(word))
                {
                    break;
                }

                fizzBuzzService.AddMap(number, word);
            }

            var results = fizzBuzzService.GetAllValues();
            
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

            // Pause for user input
            Console.ReadKey();
        }

        private static string GetStringInputFromUser(string messageText, string defaultWord)
        {
            Console.WriteLine(messageText);

            var input = Console.ReadLine();
            return string.IsNullOrEmpty(input) ? defaultWord : input;
        }

        private static int GetNumericInputFromUser(string messageText, int defaultNumber)
        {
            Console.WriteLine(messageText);
            var input = Console.ReadLine();
            int fizzNumber;
            int.TryParse(input, out fizzNumber);
            return fizzNumber > 0 ? fizzNumber : defaultNumber;
        }
    }
}
