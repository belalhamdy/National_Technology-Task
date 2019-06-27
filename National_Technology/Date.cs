using System;
using System.Collections.Generic;
using System.Text;

namespace National_Technology
{
    class Date
    {
        private int day, month, year;

        public Date (int day,int month,int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        private int FebDays() // returns number of days in feb
        {
            return( (this.year % 4 == 0 && (this.year % 100 != 0 || this.year % 400 == 0)) ? 29 : 28);
        }
        public int YearDays() // returns number of days in this year
        {
            int[] days = new int[] { 31, this.FebDays(), 31, 30, 31, 30, 31, 31, 30, 31, 30 };

            int sum = day;

            for (int idx = 0; idx < month - 1; ++idx) // if month = 4 -> i want to add the days until 3
                sum += days[idx];

            return sum;
         
        }
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
        public override String ToString() // to help in printing
        {
            return (this.day.ToString() + "." + this.month.ToString() + "." + this.year.ToString());
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return (this.year.ToString() + this.month.ToString() + this.day.ToString()).GetHashCode(); // converts it to strings and hash this string
        }

    }
}
