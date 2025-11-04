using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_SidneyWackenier
{
    abstract class ReadingRoomItem
    {
        public string Title { get; }

		private string publisher;
		public string Publisher
		{
			get { return publisher; }
			set { publisher = value; }
		}


        public abstract string Identification { get; }
        public abstract string Categorie { get; }


        public ReadingRoomItem(string title, string publisher)
        {
            this.Title = title;
            this.Publisher = publisher;
        }


    }
}
