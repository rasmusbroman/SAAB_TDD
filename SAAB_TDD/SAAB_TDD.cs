
namespace SAAB_TDD
{
    public struct SAAB_TDD
    {
        public int minute;
        public int second;
        public int hour;
        public string amPm;
        public int timeAdd;
        public SAAB_TDD(int hour, int minute, int second, string amPm, int timeAdd)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
            this.amPm = amPm;
            this.timeAdd = timeAdd;
        }


        public bool IsTimeValid()
        {
            if (hour >= 0 && hour < 24 && minute >= 0 && minute < 60 && second >= 0 && second < 60)
            {
                return true;
            }
            throw new ArgumentException("Time is not correct");
        }

        public string ConvertTimeToString()
        {
            if (IsTimeValid() == true)
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


        public bool IsAmAndPm()
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
            else if ((hour < 12 || hour > 9) && amPm == "am")
            {
                amPm = "[am]";
            }
            else if ((hour < 12 || hour > 9) && amPm == "pm")
            {
                amPm = "[pm]";
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


        //Metod för att räkna om tiden när vi passerar ny timme eller dag.
        public string AddTime()
        {
            if (amPm.Contains("am"))
            {
                Console.WriteLine(ConvertTimeToSecond(hour, minute, second, amPm, timeAdd));
                return ConvertTimeToSecond(hour, minute, second, amPm, timeAdd);
            }
            else if (amPm.Contains("pm"))
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

        //Metoder för att kunna addera och subtrahera tiden.
        public static SAAB_TDD operator ++(SAAB_TDD time)
        {
            if (time.second < 59)
            {
                time.second += 1;
            }
            else if (time.minute < 59)
            {
                time.minute += 1;
                time.second = 0;
            }
            else if (time.hour < 23)
            {
                time.hour += 1;
                time.minute = 0;
                time.second = 0;
            }
            else
            {
                time.hour = 0;
                time.minute = 0;
                time.second = 0;
            }
            Console.WriteLine(time);
            return time;
        }

        public static SAAB_TDD operator --(SAAB_TDD time)
        {
            if (time.second > 0)
            {
                time.second -= 1;
            }
            else if (time.minute > 0)
            {
                time.minute -= 1;
                time.second = 59;
            }
            else if (time.hour > 0)
            {
                time.hour -= 1;
                time.minute = 59;
                time.second = 59;
            }
            else
            {
                time.hour = 23;
                time.minute = 59;
                time.second = 59;
            }
            Console.WriteLine(time);
            return time;
        }


        //jämför två tider genom att först omvandla tiden till sekunder.
        private int TotalSeconds => hour * 3600 + minute * 60 + second;

        public static bool operator >(SAAB_TDD time1, SAAB_TDD time2)
        {            
            return time1.TotalSeconds > time2.TotalSeconds;
        }

        public static bool operator <(SAAB_TDD time1, SAAB_TDD time2)
        {
            return time1.TotalSeconds < time2.TotalSeconds;
        }

        public static bool operator ==(SAAB_TDD time1, SAAB_TDD time2)
        {
            return time1.TotalSeconds == time2.TotalSeconds;
        }

        public static bool operator !=(SAAB_TDD time1, SAAB_TDD time2)
        {
            return !(time1 == time2);
        }
    }
}