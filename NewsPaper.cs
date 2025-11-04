using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bib_SidneyWackenier
{
    class NewsPaper : ReadingRoomItem
    {
		private DateTime date;
		public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

		public override string Identification
        {
            get
			{
                string initials = string.Concat(Title.Split(' ').Select(word => word[0].ToString().ToUpper()));

                string date = Date.ToString("ddMMyyyy");

				return $"{initials}{date}";
            }
		}

        public override string Categorie
		{
			get
			{
				return "Krant";
			}
		}

        public NewsPaper(string title, string publisher, DateTime date)
        : base(title, publisher)
        {
            this.Date = date;
        }
    }
}
