using System;
using Xunit;
using SimpleStringsComparison.ConsoleApp;

namespace tests
{
    public class StringsComparisonTests
    {
        IStringsComparisonService stringsComparison = new StringsComparisonService();

        
        [Fact]
        public void ShouldReturnAreEqualTrueAndEmptyCollectionsOfDifferencesWhenEqual()
        {
            //Arrange
            var stringOne = "lorem";
            var  stringTwo = "lorem";

            //Act
            var result = stringsComparison.Compare(stringOne, stringTwo);

            //Assert

            Assert.True(result.AreEqual);
            Assert.Empty(result.Differences);
           
        }

        [Fact]
        public void ShouldReturnAreEqualFalseAndCollectionsOfDifferencesWhenNotEqual()
        {
            //Arrange
            var stringOne = "lorem";
            var  stringTwo = "lorem1";

            //Act
            var result = stringsComparison.Compare(stringOne, stringTwo);

            //Assert

            Assert.False(result.AreEqual);
            Assert.NotEmpty(result.Differences);           
        }

        [Fact]
        public void ShouldReturnLengthDifferenceWhenNotEqual()
        {
            //Arrange
            var stringOne = "lorem555555";
            var  stringTwo = "lorem1";

            //Act
            var result = stringsComparison.Compare(stringOne, stringTwo);

            //Assert

            Assert.False(result.AreEqual);
            Assert.NotEmpty(result.Differences);   
            Assert.Contains(result.Differences, c => c.DifferenceType == DifferenceType.Length);
            Assert.Contains(result.Differences, d => d.Description.Equals("Pierwszy ciąg znaków jest dłuższy od drugiego ciągu znaków o 5 znaków"));    
        }

         [Fact]
        public void ShouldReturnReservedDifferenceWhenAreReserved()
        {
            //Arrange
            var stringOne = "lorem ipsum";
            var  stringTwo = "muspi merol";

            //Act
            var result = stringsComparison.Compare(stringOne, stringTwo);

            //Assert

            Assert.False(result.AreEqual);
            Assert.NotEmpty(result.Differences);   
            Assert.Contains(result.Differences, c => c.DifferenceType == DifferenceType.Reversed);             
        }

        [Fact]
        public void ShouldNotReturnReservedDifferenceWhenAreNotReserved()
        {
            //Arrange
            var stringOne = "lorem ipsum";
            var  stringTwo = "lorem ipusm";

            //Act
            var result = stringsComparison.Compare(stringOne, stringTwo);

            //Assert

            Assert.False(result.AreEqual);
            Assert.NotEmpty(result.Differences);   
            Assert.DoesNotContain(result.Differences, c => c.DifferenceType == DifferenceType.Reversed);             
        }
        [Fact]
        public void ShouldReturnAnagramsDifferenceWhenAreAnagrams()
        {
            //Arrange
            var stringOne = "kolarstwo";
            var  stringTwo = "kostwolar";

            //Act
            var result = stringsComparison.Compare(stringOne, stringTwo);

            //Assert

            Assert.False(result.AreEqual);
            Assert.NotEmpty(result.Differences);   
            Assert.Contains(result.Differences, c => c.DifferenceType == DifferenceType.Anagrams);             
        }
        [Fact]
        public void ShouldReturnNotAnagramsDifferenceWhenAreNotAnagrams()
        {
            //Arrange
            var stringOne = "kolarstwoo";
            var  stringTwo = "kostwolara";

            //Act
            var result = stringsComparison.Compare(stringOne, stringTwo);

            //Assert

            Assert.False(result.AreEqual);
            Assert.NotEmpty(result.Differences);   
            Assert.Contains(result.Differences, c => c.DifferenceType == DifferenceType.NotAnagrams);             
        }

        [Fact]
        public void ShouldReturnAreEqualWithDifferentCharacterSizeDifferenceWhenAre()
        {
            //Arrange
            var stringOne = "KaJakarstwo";
            var  stringTwo = "kajakARSTWO";

            //Act
            var result = stringsComparison.Compare(stringOne, stringTwo);

            //Assert

            Assert.False(result.AreEqual);
            Assert.NotEmpty(result.Differences);   
            Assert.Contains(result.Differences, c => c.DifferenceType == DifferenceType.CaseInsensitiveEqual);             
        }

        [Fact]
        public void ShouldReturnNumberOfVowelDifferenceWhenIs()
        {
            //Arrange
            var stringOne = "aąeęiouytt";
            var stringTwo = "pszcszoła";

            //Act
            var result = stringsComparison.Compare(stringOne, stringTwo);

            //Assert

            Assert.False(result.AreEqual);
            Assert.NotEmpty(result.Differences);   
            Assert.Contains(result.Differences, c => c.DifferenceType == DifferenceType.NumberOfVowel);             
        }

          [Fact]
        public void ShouldNotReturnNumberOfVowelDifferenceWhenNotIs()
        {
            //Arrange
            var stringOne = "aąeęiouyttaaa";
            var  stringTwo = "aąeęiouyttooo";

            //Act
            var result = stringsComparison.Compare(stringOne, stringTwo);

            //Assert

            Assert.False(result.AreEqual);          
            Assert.DoesNotContain(result.Differences, c => c.DifferenceType == DifferenceType.NumberOfVowel);             
        }
    }
}
