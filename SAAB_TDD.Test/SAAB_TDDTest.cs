using System.Diagnostics;
using NUnit.Framework;

namespace SAAB_TDD.Test
{
    public class SAAB_TESTTest
    {
        public SAAB_TDD SAAB;
        [SetUp]
        public void Setup()
        {
            SAAB = new();
        }

        [TestCase(23, 59, 59, ExpectedResult = true)]
        public bool IsValid(int hour, int minute, int second)
        {
            return SAAB.IsValid(hour, minute, second);
        }

        // ExpectedResult antas alltid visas med HH:MM:SS, pm
        [TestCase(23, 51, 59, "am", ExpectedResult = "11:51:59[am]")]
        [TestCase(9, 52, 59, "am", ExpectedResult = "09:52:59[am]")]
        [TestCase(23, 53, 59, "pm", ExpectedResult = "11:53:59[pm]")]
        [TestCase(23, 54, 59, "", ExpectedResult = "23:54:59")]
        [TestCase(09, 55, 59, "", ExpectedResult = "09:55:59")]
        [TestCase(9, 56, 59, "", ExpectedResult = "09:56:59")]
        [TestCase(9, 57, 59, "", ExpectedResult = "09:57:59")]
        [TestCase(12, 18, 59, "pm", ExpectedResult = "00:18:59[pm]")]
        [TestCase(0, 59, 59, "pm", ExpectedResult = "00:59:59[pm]")]
        public string TimeToString(int hour, int minute, int second, string amPm)
        {
            return SAAB.TimeToString(hour, minute, second, amPm);
        }
    }
}







        //[Test]
        //public void IsTthisValid()
        //{
        //    SAAB_TDD time = new(23, 10, 15);
        //    //time.ToString();
        //    Assert.IsTrue(time.IsThisValid());
        //}

        //[TestCase(23, 10, 15, ExpectedResult = true)]
        //public bool IsTimeValid(int hours, int minutes, int seconds)
        //{
        //    SAAB_TDD time = new SAAB_TDD(hours, minutes, seconds);
        //    //time.ToString();
        //    return time.IsThisValid();
        //}