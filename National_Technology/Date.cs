using System;
using System.Collections.Generic;
using System.Text;

namespace National_Technology
{
    class Date
    {
        private int day, month, year;

        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param day of the date ="day"></param>
        /// <param month of the date="month"></param>
        /// <param year of the date="year"></param>
        public Date(int day, int month, int year)
        {
            // validating input bounds
            if (day <= 0 || month <= 0 || year <= 0) throw new System.ArgumentException("Input must be positive integer only");
            if ((day > 29 && month == 2) || day > 31 || month > 12 || year > 9999) throw new System.ArgumentException("Input must be bounded");

            this.day = day;
            this.month = month;
            this.year = year;
        }

        /// <summary>
        /// indicates if the year is leap or not
        /// </summary>
        /// <returns> number of days in February </returns>
        private int FebDays() // returns number of days in feb
        {
            if (this.year % 4 == 0 && (this.year % 100 != 0 || this.year % 400 == 0)) return 29;
            else return 28;
        }

        /// <summary>
        /// Calculates number of Days from the start of year until the given date
        /// </summary>
        /// <returns> number of days</returns>
        public int YearDays() // returns number of days in this year
        {
            int[] days = new int[] { 31, this.FebDays(), 31, 30, 31, 30, 31, 31, 30, 31, 30 };

            int sum = day;

            for (int idx = 0; idx < month - 1; ++idx) // if month = 4 -> i want to add the days until 3
                sum += days[idx];

            return sum;
         
        }

        /// <summary>
        /// converts the date to string to help in printing by Console.Write() function
        /// </summary>
        /// <returns> string contains the date </returns>
        public override String ToString() // to help in printing
        {
            return (this.day.ToString() + "." + this.month.ToString() + "." + this.year.ToString());
        }

        /// <summary>
        /// Compares two dates and identifies which is smaller
        /// </summary>
        /// <param Current class object="current"></param>
        /// <param object to compare with ="other"></param>
        /// <returns> true if current is smaller than other </returns>
        public static bool operator < (Date current , Date other) // checks which smaller to help in comparison
        {
            if (current.year < other.year) return true;
            if (current.year > other.year) return false;

            if (current.month < other.month) return true;
            if (current.month > other.month) return false;

            return current.day < other.day;
        }
        public static bool operator == (Date current, Date other)
        {
            return (current.year == other.year && current.month == other.month && current.day == other.day) ;
        }
        public static bool operator !=(Date current, Date other)
        {
            return !(current == other);
        }
        public static bool operator >(Date current, Date other)
        {
            return !(current < other || current == other);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// hashes the date if it needed
        /// </summary>
        /// <returns>hashed code of the date</returns>
        public override int GetHashCode()
        {
            return (this.year.ToString() + this.month.ToString() + this.day.ToString()).GetHashCode(); // converts it to strings and hash this string
        }

    }
}
