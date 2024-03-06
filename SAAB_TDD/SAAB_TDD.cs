
namespace SAAB_TDD
{
    public struct SAAB_TDD
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

        public bool IsValid(int hour, int minute, int second)
        {
            if (hour >= 0 && hour < 24 && minute >= 0 && minute < 60 && second >= 0 && second < 60)
            {
                return true;
            }
            throw new ArgumentException("Time is not correct");
        }

        public string TimeToString(int hour, int minute, int second, string amPm)
        {
            if (IsValid(hour, minute, second) == true)
            {
                const string hourBelowTen = "0";
                string fullTime24HourFormat = $"{hour}:{minute}:{second}";

                if (amPm.Contains("pm") || amPm.Contains("am"))
                {
                    hour = hour > 12 ? hour - 12 : hour == 12 ? 0 : hour;

                    string fullTime12HourFormat = $"{hour}:{minute}:{second}[{amPm}]";
                    if (hour < 10)
                    {
                        Console.WriteLine(hourBelowTen + fullTime12HourFormat);
                        return hourBelowTen + fullTime12HourFormat;
                    }
                    Console.WriteLine(fullTime12HourFormat);
                    return fullTime12HourFormat;
                }

                else if (hour < 10)
                {
                    Console.WriteLine(hourBelowTen + fullTime24HourFormat);
                    return hourBelowTen + fullTime24HourFormat;
                }
                Console.WriteLine(fullTime24HourFormat);
                return fullTime24HourFormat;
            }
            else
            {
                throw new ArgumentException("Time is not written correct");
            }
        }

        public bool IsAm(int hour, int minute, int second, string amPm)
        {
            if (amPm == "am")
            {
                Console.WriteLine("AM");
                return true;
            }
            else if (amPm == "pm")
            {
                Console.WriteLine("PM");
                return true;
            }
            else if (hour < 12)
            {
                Console.WriteLine("AM");
                return true;
            }
            else if (hour > 12)
            {
                Console.WriteLine("PM");
                return true;
            }
            else
            {
                throw new ArgumentException("Its neither Am or Pm, what is this madness?");
            }
        }

        public string ConvertTimeToSecond(int hour, int minute, int second, string amPm, int timeAdd)
        {
            int totalSecondsFromOriginalTime = ((hour * 60) * 60) + (minute * 60) + second + timeAdd;
            
            hour = totalSecondsFromOriginalTime / 3600;
            minute = (totalSecondsFromOriginalTime % 3600) / 60;
            second = (totalSecondsFromOriginalTime % 60);

            const int if12HourFormat = 12;
            if (hour >= 12 && amPm == "am")
            {
                hour = hour - if12HourFormat;
                amPm = "[pm]";
            }
            else if (hour >= 12 && amPm == "pm")
            {
                hour = hour - if12HourFormat;
                amPm = "[am]";
            }


            const int if24hourFormat = 24;
            if (hour >= 24)
            {
                hour = hour - if24hourFormat;
            }

            const string addZero = "0";
            string lessThanTenHour = hour.ToString();
            string lessThanTenMinutes = minute.ToString();
            string lessThanTenSeconds = second.ToString();


            if (hour < 10 && amPm == "am")
            {
                amPm = "[am]";
                lessThanTenHour = addZero + lessThanTenHour;
            }
            else if (hour < 10 && amPm == "pm")
            {
                amPm = "[pm]";
                lessThanTenHour = addZero + lessThanTenHour;
            }
            else if (hour < 10)
            {
                lessThanTenHour = addZero + lessThanTenHour;
            }

            if (minute < 10)
            {
                lessThanTenMinutes = addZero + lessThanTenMinutes;
            }
            if (second < 10)
            {
                lessThanTenSeconds = addZero + lessThanTenSeconds;
            }

            string fullNewTime = lessThanTenHour + ":" + lessThanTenMinutes + ":" + lessThanTenSeconds + amPm;

            return fullNewTime;
        }

        public string AddTime(int hour, int minute, int second, string amPm, int timeAdd)
        {
            if (amPm == "am")
            {
                Console.WriteLine(ConvertTimeToSecond(hour, minute, second, amPm, timeAdd));
                return ConvertTimeToSecond(hour, minute, second, amPm, timeAdd);
            }
            else if (amPm == "pm")
            {

                Console.WriteLine(ConvertTimeToSecond(hour, minute, second, amPm, timeAdd));
                return ConvertTimeToSecond(hour, minute, second, amPm, timeAdd);
            }
            else
            {
                Console.WriteLine(ConvertTimeToSecond(hour, minute, second, amPm, timeAdd));
                return ConvertTimeToSecond(hour, minute, second, amPm, timeAdd);
            }
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





//string[] delimiters = { "[", "]" };
////= stringHour.Split('[', ']').Trim();
////nums = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
//hourBelowTen = displayHour(delimiters, StringSplitOptions.RemoveEmptyEntries);
//hourBelowTen = "0" + displayHour.ToString();
//string showTime = $"{hourBelowTen}:{minute}:{second}: {amPm}";
//return showTime;
//hourBelowTen = "0";





/*
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
                Console.WriteLine($"{hourBelowTen}:{minute}:{second}[{amPm}]");
                return $"{hourBelowTen}:{minute}:{second}[{amPm}]";
            }

            Console.WriteLine($"{displayHour}:{minute}:{second}[{amPm}]");
            return $"{displayHour}:{minute}:{second}[{amPm}]";
        }

        else if (hour < 10)
        {
            hourBelowTen = "0" + hour.ToString();
            Console.WriteLine($"{hourBelowTen}:{minute}:{second}");
            return $"{hourBelowTen}:{minute}:{second}";
        }
        Console.WriteLine($"{hour}:{minute}:{second}");
        return $"{hour}:{minute}:{second}";
    }
    else
    {
        throw new ArgumentException("Time is not written correct");
    }
}
*/