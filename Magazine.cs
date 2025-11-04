using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bib_SidneyWackenier
{
    class Magazine : ReadingRoomItem
    {
        private byte month;
        public byte Month
        {
            get { return month; }
            set
            {
                if (value > 12)
                {
                    throw new ArgumentOutOfRangeException("De maand is maximaal 12");
                }
                month = value;
            }
        }

        private int year;
        public int Year
        {
            get { return year; }
            set
            {
                if (value > 2500)
                {
                    throw new ArgumentOutOfRangeException("Het jaartal is maximaal 2500");
                }
                year = value;
            }
        }

        public override string Identification
        {
            get
            {
                string initials = string.Concat(Title.Split(' ').Select(word => word[0].ToString().ToUpper()));

                string date = string.Concat(Month, Year);

                return $"{initials}{date}";
            }
        }

        public override string Categorie
        {
            get
            {
                return "Maandblad";
            }
        }

        public Magazine(string title, string publisher, byte month, int year)
        : base(title, publisher)
        {
            this.Month = month;
            this.Year = year;
        }

    }
}
