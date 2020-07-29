namespace SimpleStringsComparison.ConsoleApp
{
    public interface IStringsComparisonService
    {
         ResultOfCompare Compare(string stringOne, string stringTwo);
    }
}