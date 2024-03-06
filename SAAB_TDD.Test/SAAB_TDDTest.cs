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
        [TestCase(03, 01, 45, ExpectedResult = true)]
        [TestCase(11, 45, 33, ExpectedResult = true)]
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

        [TestCase(23, 51, 59, "am", ExpectedResult = true)]
        [TestCase(23, 51, 59, "pm", ExpectedResult = true)]
        [TestCase(23, 51, 59, "", ExpectedResult = true)]
        [TestCase(9, 51, 59, "pm", ExpectedResult = true)]
        [TestCase(03, 51, 59, "", ExpectedResult = true)]
        [TestCase(9, 51, 59, "am", ExpectedResult = true)]
        [TestCase(9, 50, 59, "pm", ExpectedResult = true)]
        [TestCase(9, 51, 59, "", ExpectedResult = true)]
        public bool IsAm(int hour, int minute, int second, string amPm)
        {
            return SAAB.IsAm(hour, minute, second, amPm);
        }

        [TestCase(10, 00, 00, "am", 5, ExpectedResult = "10:00:05[am]")]
        [TestCase(09, 52, 54, "am", 5, ExpectedResult = "09:52:59[am]")]
        [TestCase(11, 59, 54, "am", 7, ExpectedResult = "00:00:01[pm]")]
        [TestCase(11, 59, 54, "pm", 7, ExpectedResult = "00:00:01[am]")]
        [TestCase(23, 59, 54, "", 7, ExpectedResult = "00:00:01")]
        [TestCase(09, 55, 54, "", 5, ExpectedResult = "09:55:59")]
        [TestCase(09, 56, 54, "",5, ExpectedResult = "09:56:59")]
        [TestCase(09, 57, 54, "",5, ExpectedResult = "09:57:59")]
        [TestCase(00, 18, 54, "pm", 5, ExpectedResult = "00:18:59[pm]")]
        [TestCase(00, 59, 54, "pm",5, ExpectedResult = "00:59:59[pm]")]
        public string AddTime(int hour, int minute, int second, string amPm, int timeAdd)
        {
            return SAAB.AddTime(hour, minute, second, amPm, timeAdd);
        }
        //+5 00.00.05
        //+125 00.02.05   tid 3600 => tid % 24, tid % 60, tid % 60  :::::: 60%60minut och sekunder, %24timmar
        //  

    }
}


/* -------------Lägga till----------------
    * Const
    * Get hour funktion? eller funktion att hämta nuvarande tid.
    * 





*/




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