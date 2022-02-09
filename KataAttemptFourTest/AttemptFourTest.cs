using KataAttemptFour;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace KataAttemptFourTest
{
    public class AttemptFourTest
    {
        AttemptFour attemptFour;
        [SetUp]
        public void Setup()
        {
            attemptFour = new AttemptFour();
        }

        [Test]
        public void Given_EmptyString_When_Adding_Should_Return_Zero()
        {
            int results = attemptFour.Add("");
            int expected = 0;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_OneNumberWhen_Adding_Should_Return_One()
        {
            int results = attemptFour.Add("1");
            int expected = 1;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_TwoNumbers_SeperatedByDelimeter_When_Adding_Should_Return_SumOfTwoNumbers()
        {
            int results = attemptFour.Add("1,2");
            int expected = 3;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_ThreeNumbers_SeperatedByDelimeters_When_Adding_Should_SumOfThreeNumbers()
        {
            int results = attemptFour.Add("1\n2,3");
            int expected = 6;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_TwoNumbersStartingWithForwardSlashes_When_Adding_Should_Return_SumOfTwoNumbers()
        {
            int results = attemptFour.Add("//;\n1;2");
            int expected = 3;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_NumbersWithNegetives_When_Adding_Should_ThrowException()
        {
            Assert.Throws<Exception>(() => attemptFour.Add("1\n2,-3"));
        }
        [Test]
        public void Given_NumbersGreaterThan1000_When_Adding_Should_Return_SumOfAllNumbersExcludingNumbersGreaterThan1000()
        {
            int results = attemptFour.Add("//;\n1;2,2000");
            int expected = 3;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_NumbersSeperatedByDelimiters_OfDifferentLength_When_Adding_Should_Return_SumOfAllNumbers()
        {
            int results = attemptFour.Add("//%%%\n1%%%2%%%3");
            int expected = 6;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_NumbersSeperatedByMultiplyDelimiters_InSquareBrackets_When_Adding_Should_Return_SumOfAllNumbers()
        {
            int results = attemptFour.Add("//[*][%]\n1*2%3");
            int expected = 6;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_NumbersSeperatedByMultiplyDelimitersOfDifferentLength_InSquareBrackets_When_Adding_Should_Return_SumOfAllNumbers()
        {
            int results = attemptFour.Add("//[***][%%%%]\n1***2%%%%3");
            int expected = 6;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_NumbersWithDelimeters_When_GetDelimeterList_Should_Return_ListOfDelimeters()
        {
            List<string> results = attemptFour.GetDelimeterList("//[***][%%%%]\n1***2%%%%3");
            List<string> expected = new List<string>() { ",", "\n", "***", "%%%%" };
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_NumbersWithDelimetersInBrackets_When_ExtractDelimetersInBrackets_Should_Return_ListOfExtractedDelimeters()
        {
            List<string> results = attemptFour.ExtractDelimetersInBrackets("//[***][%%%%]\n1***2%%%%3");
            List<string> expected = new List<string>() { "***", "%%%%" };
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_NumbersWithDelimeters_When_ExtractNumbersFromTextInput_Should_Return_ListOfExtractedNumbers()
        {
            List<int> results = attemptFour.ExtractNumbersFromTextInput("//[*][%]\n1*2%3");
            List<int> expected = new List<int>() { 1, 2, 3 };
            Assert.AreEqual(expected, results);
        }
    }
}