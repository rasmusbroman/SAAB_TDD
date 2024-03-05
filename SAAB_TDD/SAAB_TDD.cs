
namespace SAAB_TDD
{
    public class SAAB_TDD
    {
        public int minute;
        public int second;
        public int hour;

        public SAAB_TDD() { }

        public SAAB_TDD(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public string TimeToString(int hour, int minute, int second, string amPm)
        {
            if (IsValid(hour, minute, second) == true)
            {
                string hourBelowTen = "";
                if (amPm.Contains("pm") || amPm.Contains("am"))
                {
                    int displayHour = hour > 12 ? hour - 12 : hour == 12 ? 0 : hour;
                    if (displayHour < 10)
                    {
                        //string[] delimiters = { "[", "]" };
                        ////= stringHour.Split('[', ']').Trim();
                        ////nums = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        //hourBelowTen = displayHour(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        //hourBelowTen = "0" + displayHour.ToString();
                        //string showTime = $"{hourBelowTen}:{minute}:{second}: {amPm}";
                        //return showTime;
                        hourBelowTen = "0" + displayHour.ToString();
                        return $"{hourBelowTen}:{minute}:{second}[{amPm}]";
                    }
                    return $"{displayHour}:{minute}:{second}[{amPm}]";
                }

                else if (hour < 10)
                {
                    hourBelowTen = "0" + hour.ToString();
                    return $"{hourBelowTen}:{minute}:{second}";
                }
                return $"{hour}:{minute}:{second}";
            }
            else
            {
                throw new ArgumentException("Time is not written correct");
            }
        }

        public bool IsValid(int hour, int minute, int second)
        {
            if (hour >= 0 && hour < 24 && minute >= 0 && minute < 60 && second >= 0 && second < 60)
            {
                return true;
            }
            throw new ArgumentException("Time is not correct");
        }
    }
}








//public bool IsThisValid()
//{
//    if (hour >= 0 && hour < 24 && minute >= 0 && minute < 60 && second >= 0 && second < 60)
//    {
//        return true;
//    }
//    throw new ArgumentException("Time is not correct");
//}