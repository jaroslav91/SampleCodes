namespace SimpleStringsComparison.ConsoleApp
{
    public class Difference
    {        
        public string Description {get; set;}
        public DifferenceType DifferenceType {get; set;}       
    }

    public enum DifferenceType : int {

        None = 0,
        Length,
        Reversed,
        Anagrams,
        NotAnagrams,
        CaseInsensitiveEqual,
        NumberOfVowel,
    }
}