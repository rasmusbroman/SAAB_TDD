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

        [TestCase(23, 59, 59, "", 0, ExpectedResult = true)]
        [TestCase(03, 01, 45, "", 0, ExpectedResult = true)]
        [TestCase(11, 45, 33, "", 0, ExpectedResult = true)]
        public bool IsValid(int hour, int minute, int second, string amPm, int timeAdd)
        {
            SAAB_TDD time = new SAAB_TDD(hour, minute, second, amPm, timeAdd);
            return time.IsTimeValid();
        }
        //[Test]
        //public void IsValid()
        //{
        //    SAAB_TDD time1 = new(23, 10, 15, "", 0);
        //    Assert.That(time1.IsValid(), Is.True);
        //    SAAB_TDD time2 = new(03, 01, 45, "", 0);
        //    Assert.That(time2.IsValid(), Is.True);
        //    SAAB_TDD time3 = new(11, 45, 33, "", 0);
        //    Assert.That(time3.IsValid(), Is.True);
        //}



        // ExpectedResult antas alltid visas med HH:MM:SS, pm
        //[TestCase(23, 53, 59, "", 0, ExpectedResult = "11:53:59[pm]")]
        //[TestCase(12, 18, 59, "", 0, ExpectedResult = "00:18:59[pm]")]


        [TestCase(9, 52, 59, "am", 0, ExpectedResult = "09:52:59[am]")]
        [TestCase(23, 53, 59, "pm", 0, ExpectedResult = "11:53:59[pm]")]
        [TestCase(23, 54, 59, "", 0, ExpectedResult = "23:54:59")]
        [TestCase(09, 55, 59, "", 0, ExpectedResult = "09:55:59")]
        [TestCase(9, 56, 59, "", 0, ExpectedResult = "09:56:59")]
        [TestCase(9, 57, 59, "", 0, ExpectedResult = "09:57:59")]
        [TestCase(12, 18, 59, "pm", 0, ExpectedResult = "00:18:59[pm]")]
        [TestCase(0, 59, 59, "pm", 0, ExpectedResult = "00:59:59[pm]")]
        public string TimeToString(int hour, int minute, int second, string amPm, int timeAdd)
        {
            SAAB_TDD time = new SAAB_TDD(hour, minute, second, amPm, timeAdd);
            return time.ConvertTimeToString();
        }
        //[Test]
        //public void TimeToString()
        //{
        //    SAAB_TDD time1 = new SAAB_TDD(23, 51, 59, "am", 0);
        //    Assert.That(time1.TimeToString(), Is.EqualTo("11:51:59[am]"));
        //    SAAB_TDD time2 = new SAAB_TDD(9, 52, 59, "am", 0);
        //    Assert.That(time2.TimeToString(), Is.EqualTo("09:52:59[am]"));
        //    SAAB_TDD time3 = new SAAB_TDD(23, 53, 59, "pm", 0);
        //    Assert.That(time3.TimeToString(), Is.EqualTo("11:53:59[pm]"));
        //    SAAB_TDD time4 = new SAAB_TDD(23, 54, 59, "", 0);
        //    Assert.That(time4.TimeToString(), Is.EqualTo("23:54:59"));
        //    SAAB_TDD time5 = new SAAB_TDD(09, 55, 59, "", 0);
        //    Assert.That(time5.TimeToString(), Is.EqualTo("09:55:59"));
        //    SAAB_TDD time6 = new SAAB_TDD(9, 56, 59, "", 0);
        //    Assert.That(time6.TimeToString(), Is.EqualTo("09:56:59"));
        //    SAAB_TDD time7 = new SAAB_TDD(9, 57, 59, "", 0);
        //    Assert.That(time7.TimeToString(), Is.EqualTo("09:57:59"));
        //    SAAB_TDD time8 = new SAAB_TDD(12, 18, 59, "pm", 0);
        //    Assert.That(time8.TimeToString(), Is.EqualTo("00:18:59[pm]"));
        //    SAAB_TDD time9 = new SAAB_TDD(0, 59, 59, "pm", 0);
        //    Assert.That(time9.TimeToString(), Is.EqualTo("00:59:59[pm]"));
        //}



        [TestCase(23, 51, 59, "am", 0, ExpectedResult = true)]
        [TestCase(23, 51, 59, "pm", 0, ExpectedResult = true)]
        [TestCase(23, 51, 59, "", 0, ExpectedResult = true)]
        [TestCase(9, 51, 59, "pm", 0, ExpectedResult = true)]
        [TestCase(03, 51, 59, "", 0, ExpectedResult = true)]
        [TestCase(9, 51, 59, "am", 0, ExpectedResult = true)]
        [TestCase(9, 50, 59, "pm", 0, ExpectedResult = true)]
        [TestCase(9, 51, 59, "", 0, ExpectedResult = true)]
        public bool IsAm(int hour, int minute, int second, string amPm, int timeAdd)
        {
            SAAB_TDD time = new SAAB_TDD(hour, minute, second, amPm, timeAdd);
            return time.IsAmAndPm();
        }
        //[Test]
        //public void IsAm()
        //{
        //    SAAB_TDD time1 = new(23, 51, 59, "am", 0);
        //    Assert.IsTrue(time1.IsAm());
        //    SAAB_TDD time2 = new(23, 51, 59, "pm", 0);
        //    Assert.IsTrue(time2.IsAm());
        //    SAAB_TDD time3 = new(23, 51, 59, "", 0);
        //    Assert.IsTrue(time3.IsAm());
        //    SAAB_TDD time4 = new(9, 51, 59, "pm", 0);
        //    Assert.IsTrue(time4.IsAm());
        //    SAAB_TDD time5 = new(03, 51, 59, "", 0);
        //    Assert.IsTrue(time5.IsAm());
        //    SAAB_TDD time6 = new(9, 51, 59, "am", 0);
        //    Assert.IsTrue(time6.IsAm());
        //    SAAB_TDD time7 = new(9, 50, 59, "pm", 0);
        //    Assert.IsTrue(time7.IsAm());
        //    SAAB_TDD time8 = new(9, 51, 59, "", 0);
        //    Assert.IsTrue(time8.IsAm());
        //}



        [TestCase(23, 59, 54, "", -7, ExpectedResult = "23:59:47")]
        //[TestCase(00, 00, 00, "", -5, ExpectedResult = "23:59:55")] //
        //[TestCase(00, 00, 00, "am", -5, ExpectedResult = "11:59:55[pm]")] //
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
        //[Test]
        //public void AddTime()
        //{
        //    SAAB_TDD time1 = new(10, 00, 00, "am", 5);
        //    Assert.That(time1.AddTime(), Is.EqualTo("10:00:05[am]"));
        //    SAAB_TDD time2 = new(11, 30, 00, "am", 5);
        //    Assert.That(time2.AddTime(), Is.EqualTo("11:30:05[am]"));
        //    SAAB_TDD time3 = new(11, 30, 00, "pm", 5);
        //    Assert.That(time3.AddTime(), Is.EqualTo("11:30:05[pm]"));
        //    SAAB_TDD time4 = new(09, 52, 54, "am", 5);
        //    Assert.That(time4.AddTime(), Is.EqualTo("09:52:59[am]"));
        //    SAAB_TDD time5 = new(11, 59, 54, "am", 7);
        //    Assert.That(time5.AddTime(), Is.EqualTo("00:00:01[pm]"));
        //    SAAB_TDD time6 = new(11, 59, 54, "pm", 7);
        //    Assert.That(time6.AddTime(), Is.EqualTo("00:00:01[am]"));
        //    SAAB_TDD time7 = new(23, 59, 54, "", 7);
        //    Assert.That(time7.AddTime(), Is.EqualTo("00:00:01"));
        //    SAAB_TDD time8 = new(09, 55, 54, "", 5);
        //    Assert.That(time8.AddTime(), Is.EqualTo("09:55:59"));
        //    SAAB_TDD time9 = new(09, 56, 54, "", 5);
        //    Assert.That(time9.AddTime(), Is.EqualTo("09:56:59"));
        //    SAAB_TDD time10 = new(09, 57, 54, "", 5);
        //    Assert.That(time10.AddTime(), Is.EqualTo("09:57:59"));
        //    SAAB_TDD time11 = new(00, 18, 54, "pm", 5);
        //    Assert.That(time11.AddTime(), Is.EqualTo("00:18:59[pm]"));
        //    SAAB_TDD time12 = new(00, 59, 54, "pm", 5);
        //    Assert.That(time12.AddTime(), Is.EqualTo("00:59:59[pm]"));
        //}



        [Test]
        public void AdjustTimePlusOne()
        {
            SAAB_TDD time = new(23, 59, 59, "", 0);
            time++;
            Assert.That(time, Is.EqualTo(new SAAB_TDD(00, 00, 00, "", 0)));
        }

        [Test]
        public void AdjustTimeMinusOne()
        {
            SAAB_TDD time = new(00, 00, 00, "", 0);
            time--;
            Assert.That(time, Is.EqualTo(new SAAB_TDD(23, 59, 59, "", 0)));
        }





        [Test]
        public void TimeGreaterThanTime()
        {
            SAAB_TDD time1 = new SAAB_TDD(12, 00, 10, "", 0);
            SAAB_TDD time2 = new SAAB_TDD(13, 00, 10, "", 0);
            Assert.That(time2 > time1, Is.True);
        }

        [Test]
        public void TimeUnequalThanTime()
        {
            SAAB_TDD time1 = new SAAB_TDD(12, 00, 00, "", 0);
            SAAB_TDD time2 = new SAAB_TDD(12, 00, 01, "", 0);
            Assert.That(time1 != time2, Is.True);
        }
    }
}


/* -------------Lägga till----------------

    * Konstanter(const) ska användas där lämpligt. Dina funktioner ska ha dokumentation där det framgår
    tydligt vad som är viktigt för dina kollegor att läsa och vad som bara är implementationsdetaljer

    * Din kod ska följa kodkonventioner för .NET. Din kod ska inte ge några varningar eller errors.

    * Get hour funktion? eller funktion att hämta nuvarande tid.

    * Det ska gå att ändra implementationen av diverse funktioner utan att det påverkar eller "breakar" andra
    program som använder din kod. Detta innebär att alla funktionsparametrar och returvärden inte ska vara
    beroende av hur din kod är skriven. Exempelvis så ska en funktion GetHour returnera den timme som den
    tidpunkten kallas vid. OAVSETT av hur implementationen av tidpunkten är kodad.
    Din tidpunktsstruct ska vara implementrad med tre integers, en för timmar, en för minuter och en för
    sekunder. Men din kod ska vara skriven på så sätt att detta inte spelar någon roll. Du ska kunna ändra din
    struct på så sätt att den bara lagrar sekunder utan att det påverkar användarens kod. (Detta innebär
    såklart att mycket kommer behöva skrivas om men omskrivningen ska inte märkas av andra
    programmerare. Dvs de ska inte behöva ändra något även att du ändrade massor.) NOTERA: det är inte
    nödvändigt eller förväntat att du faktiskt implementerar dessa ändringar i denna uppgift.


*/