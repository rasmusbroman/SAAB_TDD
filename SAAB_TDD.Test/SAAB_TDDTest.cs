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

        // Kontrollerar att tiden är i rätt format
        [TestCase(23, 59, 59, "", 0, ExpectedResult = true)]
        [TestCase(03, 01, 45, "", 0, ExpectedResult = true)]
        [TestCase(11, 45, 33, "", 0, ExpectedResult = true)]
        public bool IsTimeValid(int hour, int minute, int second, string amPm, int timeAdd)
        {
            SAAB_TDD time = new SAAB_TDD(hour, minute, second, amPm, timeAdd);
            return time.IsTimeValid();
        }

        // Omvandlar tiden till string
        [TestCase(9, 52, 59, "am", 0, ExpectedResult = "09:52:59[am]")]
        [TestCase(23, 53, 59, "pm", 0, ExpectedResult = "11:53:59[pm]")]
        [TestCase(23, 54, 59, "", 0, ExpectedResult = "23:54:59")]
        [TestCase(09, 55, 59, "", 0, ExpectedResult = "09:55:59")]
        [TestCase(9, 56, 59, "", 0, ExpectedResult = "09:56:59")]
        [TestCase(9, 57, 59, "", 0, ExpectedResult = "09:57:59")]
        [TestCase(12, 18, 59, "pm", 0, ExpectedResult = "00:18:59[pm]")]
        [TestCase(0, 59, 59, "pm", 0, ExpectedResult = "00:59:59[pm]")]
        public string ConvertTimeToString(int hour, int minute, int second, string amPm, int timeAdd)
        {
            SAAB_TDD time = new SAAB_TDD(hour, minute, second, amPm, timeAdd);
            return time.ConvertTimeToString();
        }

        // Kontroll om tiden är i 24h format eller 12h format
        [TestCase(23, 51, 59, "am", 0, ExpectedResult = true)]
        [TestCase(23, 51, 59, "pm", 0, ExpectedResult = true)]
        [TestCase(23, 51, 59, "", 0, ExpectedResult = true)]
        [TestCase(9, 51, 59, "pm", 0, ExpectedResult = true)]
        [TestCase(03, 51, 59, "", 0, ExpectedResult = true)]
        [TestCase(9, 51, 59, "am", 0, ExpectedResult = true)]
        [TestCase(9, 50, 59, "pm", 0, ExpectedResult = true)]
        [TestCase(9, 51, 59, "", 0, ExpectedResult = true)]
        public bool IsAmAndPm(int hour, int minute, int second, string amPm, int timeAdd)
        {
            SAAB_TDD time = new SAAB_TDD(hour, minute, second, amPm, timeAdd);
            return time.IsAmAndPm();
        }

        // Testar omräkning av tid, byter timme/dag
        [TestCase(23, 59, 54, "", -7, ExpectedResult = "23:59:47")]
        [TestCase(10, 00, 00, "am", -5, ExpectedResult = "09:59:55[am]")]
        [TestCase(10, 00, 00, "am", 5, ExpectedResult = "10:00:05[am]")]
        [TestCase(11, 30, 00, "am", 5, ExpectedResult = "11:30:05[am]")]
        [TestCase(11, 30, 00, "pm", 5, ExpectedResult = "11:30:05[pm]")]
        [TestCase(09, 52, 54, "am", 5, ExpectedResult = "09:52:59[am]")]
        [TestCase(11, 59, 54, "am", 7, ExpectedResult = "00:00:01[pm]")]
        [TestCase(11, 59, 54, "pm", 7, ExpectedResult = "00:00:01[am]")]
        [TestCase(23, 59, 54, "", 7, ExpectedResult = "00:00:01")]
        [TestCase(09, 55, 54, "", 5, ExpectedResult = "09:55:59")]
        [TestCase(09, 56, 54, "", 5, ExpectedResult = "09:56:59")]
        [TestCase(09, 57, 54, "", 5, ExpectedResult = "09:57:59")]
        [TestCase(00, 18, 54, "pm", 5, ExpectedResult = "00:18:59[pm]")]
        [TestCase(00, 59, 54, "pm", 5, ExpectedResult = "00:59:59[pm]")]
        public string AddTime(int hour, int minute, int second, string amPm, int timeAdd)
        {
            SAAB_TDD time = new SAAB_TDD(hour, minute, second, amPm, timeAdd);
            return time.AddTime();
        }

        // Testar addera en sekund på tid
        [Test]
        public void AdjustTimePlusOne()
        {
            SAAB_TDD time = new(23, 59, 59, "", 0);
            time++;
            Assert.That(time, Is.EqualTo(new SAAB_TDD(00, 00, 00, "", 0)));
        }

        // Testar subtrahera en sekund på tid
        [Test]
        public void AdjustTimeMinusOne()
        {
            SAAB_TDD time = new(00, 00, 00, "", 0);
            time--;
            Assert.That(time, Is.EqualTo(new SAAB_TDD(23, 59, 59, "", 0)));
        }

        // Kontrollerar om en tid är större än en annan
        [Test]
        public void TimeGreaterThanTime()
        {
            SAAB_TDD time1 = new SAAB_TDD(12, 00, 10, "", 0);
            SAAB_TDD time2 = new SAAB_TDD(13, 00, 10, "", 0);
            Assert.That(time2 > time1, Is.True);
        }

        // Kontrollerar om två tider ej är lika
        [Test]
        public void TimeUnequalThanTime()
        {
            SAAB_TDD time1 = new SAAB_TDD(12, 00, 00, "", 0);
            SAAB_TDD time2 = new SAAB_TDD(12, 00, 01, "", 0);
            Assert.That(time1 != time2, Is.True);
        }
    }
}