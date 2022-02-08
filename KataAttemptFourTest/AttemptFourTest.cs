using KataAttemptFour;
using NUnit.Framework;
using System;

namespace KataAttemptFourTest
{
    public class AttemptFourTest
    {
        AttemptFour kata;
        [SetUp]
        public void Setup()
        {
            kata = new AttemptFour();
        }

        [Test]
        public void Given_EmptyString_When_Adding_Should_Return_0()
        {
            int results = kata.Add("");
            int expected = 0;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_InputString_1_When_Adding_Should_Return_1()
        {
            int results = kata.Add("1");
            int expected = 1;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_InputString_1_And_2_SeperatedByDelimeter_When_Adding_Should_Return_3()
        {
            int results = kata.Add("1,2");
            int expected = 3;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_InputString_1_2_And_3_SeperatedByDelimeters_When_Adding_Should_Return_6()
        {
            int results = kata.Add("1\n2,3");
            int expected = 6;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_InputStringStartsWithDoubleForwardSlashes_When_Adding_Should_Return_3()
        {
            int results = kata.Add("//;\n1;2");
            int expected = 3;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_InputStringWithNegetiveNumbers_When_Adding_Should_ThrowException()
        {
            Assert.Throws<Exception>(() => kata.Add("1\n2,-3"));
        }
        [Test]
        public void Given_InputStringWithNumbers_GreaterThan_1000_When_Adding_Should_Return_3()
        {
            int results = kata.Add("//;\n1;2,2000");
            int expected = 3;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_InputStringWithDelimiters_OfDifferentLength_When_Adding_Should_Return_6()
        {
            int results = kata.Add("//%%%\n1%%%2%%%3");
            int expected = 6;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_InputStringWithMultiplyDelimiters_InSquareBrackets_When_Adding_Should_Return_6()
        {
            int results = kata.Add("//[*][%]\n1*2%3");
            int expected = 6;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_InputStringWithMultiplyDelimitersOfDifferentLength_InSquareBrackets_When_Adding_Should_Return_6()
        {
            int results = kata.Add("//[***][%%%%]\n1***2%%%%3");
            int expected = 6;
            Assert.AreEqual(expected, results);
        }
    }
}