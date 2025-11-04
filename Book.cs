using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bib_SidneyWackenier
{
    internal class Book : Ilendable
    {
        private string title;
        private string author;
        private string publisher;
        private string isbn;
        private int publicationyear;
        private BookGenre genre;
        private double price;
        private int pages;
        private bool isAvailable;
        private DateTime borrowingDate;
        private int borrowDays;

        public string Title
        {
            get { return title; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    title = value;
                }
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    author = value;
                }
            }
        }
                

        public string Publisher
        {
            get { return publisher; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    publisher = value;
                }
            }
        }

        public string ISBN
        {
            get { return isbn; }
            set {
                if (value.Length == 13)
                {
                    isbn = value;
                }
                else
                {
                    throw new InvalidLengthException();
                }

            }
        }

        public int PublicationYear
        {
            get { return publicationyear; }
            set {
                if (value < 0)
                {
                    throw new LessThanZeroException();
                }
                else
                {
                    publicationyear = value;
                }

            }
        }

        public BookGenre Genre
        {
            get { return genre; }
            set { genre = value;
                if (genre == BookGenre.SchoolBoek)
                {
                    borrowDays = 10;
                }
                else
                {
                    borrowDays = 20;
                }
            }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Pages
        {
            get { return pages; }
            set { pages = value; }
        }

        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }

        public DateTime BorrowingDate
        {
            get { return borrowingDate; }
            set { borrowingDate = value; }
        }

        public int BorrowDays
        {
            get { return borrowDays; }
            set { borrowDays = value; }
        }

        public Book(string title, string author, Library library)
        {
            this.Title = title;
            this.Author = author;
            this.IsAvailable = true;
            library.Books.Add(this);
        }

        public void DisplayBook()
        {
            Console.WriteLine($"{this.title}, een {this.genre}-boek geschreven door {this.author}.");
            Console.WriteLine($"Gepubliceerd door {this.publisher} in {this.publicationyear}");
            Console.WriteLine($"ISBN-nummer: {this.isbn}\nPrijs: {this.price}\nAantal paginas: {this.pages}");
            Console.WriteLine();
        }

        public void Borrow()
        {
            if (this.isAvailable == true)
            {
                this.BorrowingDate = DateTime.Today;
                DateTime returnDate = this.borrowingDate.AddDays(this.borrowDays);
                Console.WriteLine($"Boek succesvol ontleend! \nUiterste inleverdatum: {returnDate.ToString("yyyy-MM-dd")}");
                isAvailable = false;
            }
            else
            {
                Console.WriteLine("Dit boek is al ontleend!");
            }
        }
        public void Return()
        {
            this.isAvailable = true;
            DateTime returnDate = this.borrowingDate.AddDays(this.borrowDays);
            DateTime today = DateTime.Today;
            

            if (returnDate.Date > today)
            {
                Console.WriteLine("Je hebt het boek op tijd binnengebracht.");
            }
            else if (returnDate.Date < today)
            {
                Console.WriteLine("Je hebt het boek te laat binnengebracht!");
            }
        }
    }
}
