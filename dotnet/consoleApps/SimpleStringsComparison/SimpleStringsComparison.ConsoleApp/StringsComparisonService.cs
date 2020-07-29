using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleStringsComparison.ConsoleApp
{
    public class StringsComparisonService : IStringsComparisonService
    {
        public ResultOfCompare Compare(string stringOne, string stringTwo)
        {
            if (stringOne == null)
            {
                throw new ArgumentNullException(nameof(stringOne));

            }

            if (stringTwo == null)
            {
                throw new ArgumentNullException(nameof(stringTwo));

            }

            var result = new ResultOfCompare();

            if (CheckIfAreEqual(stringOne, stringTwo))
            {
                result.AreEqual = true;
                return result;
            }

            CompareLength(result, stringOne, stringTwo);
            CheckIfAreReversed(result, stringOne, stringTwo);
            CheckIfAreAnagrams(result, stringOne, stringTwo);
            CheckIfAreEqualIgnoreCase(result, stringOne, stringTwo);
            CompareNumberOfVowel(result, stringOne, stringTwo);

            return result;

        }

        private bool CheckIfAreEqual(string stringOne, string stringTwo)
        {
            return stringOne.Equals(stringTwo);
        }

        private void CheckIfAreAnagrams(ResultOfCompare result, string stringOne, string stringTwo)
        {
            if (AreAnagrams(stringOne, stringTwo))
            {
                var anagrams = new Difference() { DifferenceType = DifferenceType.Anagrams };
                anagrams.Description = "Podane ciągi są anagramami";
                result.AddDifference(anagrams);
            }
            else
            {
                var notAnagrams = new Difference() { DifferenceType = DifferenceType.NotAnagrams };
                notAnagrams.Description = "Podane ciągi nie są anagramami";
                result.AddDifference(notAnagrams);
            }
        }

        private void CheckIfAreEqualIgnoreCase(ResultOfCompare result, string stringOne, string stringTwo)
        {
            if (stringOne.Equals(stringTwo, StringComparison.OrdinalIgnoreCase))
            {
                result.AddDifference(new Difference() { DifferenceType = DifferenceType.CaseInsensitiveEqual, Description = "Podane ciągi różnią się wielkością znaków" });
            }
        }

        private bool AreAnagrams(string stringOne, string stringTwo)
        {
            return stringOne.OrderBy(x => x).SequenceEqual(stringTwo.OrderBy(x => x));
        }

        private void CheckIfAreReversed(ResultOfCompare result, string stringOne, string stringTwo)
        {
            var reversed = new string(stringTwo.Reverse().ToArray());
            if (stringOne.Equals(reversed))
            {
                result.AddDifference(new Difference() { DifferenceType = DifferenceType.Reversed, Description = "Ciągi są odwrócone" });
            }
        }

        private void CompareLength(ResultOfCompare result, string stringOne, string stringTwo)
        {
            if (stringOne.Length != stringTwo.Length)
            {
                var lengthDifference = new Difference() { DifferenceType = DifferenceType.Length };

                if (stringOne.Length > stringTwo.Length)
                {
                    lengthDifference.Description = String.Format($"Pierwszy ciąg znaków jest dłuższy od drugiego ciągu znaków o {stringOne.Length - stringTwo.Length} znaków");
                }
                else
                {
                    lengthDifference.Description = String.Format($"Drugi ciąg znaków jest dłuższy od pierwszego o {stringTwo.Length - stringOne.Length} znaków");
                }
                result.AddDifference(lengthDifference);
            }
        }

        private void CompareNumberOfVowel(ResultOfCompare result, string stringOne, string stringTwo)
        {
            int stringOneVowelCount = VowelCounter(stringOne);
            int stringTwoVowelCount = VowelCounter(stringTwo);

            if (stringOneVowelCount != stringTwoVowelCount)
            {
                result.AddDifference(new Difference()
                {
                    DifferenceType = DifferenceType.NumberOfVowel,
                    Description = $"Ciągi różnią się ilością samogłosek, pierwszy ciąg zawiera {stringOneVowelCount} a drugi {stringTwoVowelCount}."
                });
            }
        }

        private int VowelCounter(string sentence)
        {
            int total = 0;
            var vowels = new HashSet<char> { 'a', 'ą', 'e', 'ę', 'i', 'o', 'u', 'y' };

            for (int i = 0; i < sentence.Length; i++)
            {
                if (vowels.Contains(sentence[i]))
                {
                    total++;
                }
            }
            return total;
        }
    }
}
