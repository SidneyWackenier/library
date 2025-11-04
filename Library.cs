using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bib_SidneyWackenier
{
    internal class Library
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<Book> books = new List<Book>();
        public List<Book> Books
        {
            get { return books; }
            set { books = value; }
        }

        public Dictionary<DateTime, ReadingRoomItem> AllReadingRoom { get; } = new Dictionary<DateTime, ReadingRoomItem>();

        public Library(string name)
        {
            this.Name = name;
            this.Books = new List<Book>();

        }

        public void RemoveBook(string title, string author)
        {
            List<Book> booksToRemove = new List<Book>();

            foreach (Book book in Books)
            {
                if (book.Title == title && book.Author == author)
                {
                    booksToRemove.Add(book);
                }
            }

            foreach (Book book in booksToRemove)
            {
                Books.Remove(book);
            }
        }

        public Book SearchForBook(string title, string author)
        {
            foreach (Book book in Books)
            {
                if (book.Title == title && book.Author == author)
                {
                    return book;
                }
                
            }

            Console.WriteLine("Book niet gevonden.");
            return null;
        }

        public Book SearchForISBN(string isbn)
        {
            foreach (Book book in Books)
            {
                if (book.ISBN == isbn)
                {
                    return book;
                }

            }

            Console.WriteLine("Boek niet gevonden.");
            return null;
        }

        public List<Book> BooksByAuthor(string author)
        {
            List<Book> AuthorBooks = new List<Book>();

            foreach (Book book in Books)
            {
                if (book.Author == author)
                {
                    AuthorBooks.Add(book);
                }
            }

            return AuthorBooks;
        }

        public List<Book> BooksByGenre(BookGenre genre)
        {
            List<Book> AuthorBooks = new List<Book>();

            foreach (Book book in Books)
            {
                if (book.Genre == genre)
                {
                    AuthorBooks.Add(book);
                }
            }

            return AuthorBooks;
        }

        public void AddNewsPaper()
        {
            Console.WriteLine("Wat is de naam van de krant?");
            string title = Console.ReadLine();

            Console.WriteLine("Wat is de datum van de krant?");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Wat is de uitgeverij van de krant?");
            string publisher = Console.ReadLine();

            NewsPaper newspaper = new NewsPaper(title, publisher, date);

            this.AllReadingRoom.Add(DateTime.Now, newspaper);
        }

        public void AddMagazine()
        {
            Console.WriteLine("Wat is de naam van het maandblad?");
            string title = Console.ReadLine();

            Console.WriteLine("Wat is de maand van het maandblad?");
            byte month = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("Wat is het jaar van het maandblad?");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Wat is de uitgeverij van de krant?");
            string publisher = Console.ReadLine();

            Magazine magazine = new Magazine(title, publisher, month, year);

            this.AllReadingRoom.Add(DateTime.Now, magazine);
        }

        public void ShowAllMagazines()
        {
            Console.Clear();
            List<Magazine> AllMagazines = new List<Magazine>();
            foreach (var item in AllReadingRoom)
            {
                if (item.Value is Magazine magazine)
                {
                    AllMagazines.Add(magazine);
                }
            }
            Console.WriteLine("Alle maandbladen uit de leeszaal:");
            foreach (var item in AllMagazines)
            {
                Console.WriteLine($"{item.Title} van {item.Month}/{item.Year} van uitgeverij {item.Publisher}.");
            }
        }

        public void ShowAllNewsPapers()
        {
            Console.Clear();
            List<NewsPaper> AllNewsPapers = new List<NewsPaper>();
            foreach (var item in AllReadingRoom)
            {
                if (item.Value is NewsPaper newspaper)
                {
                    AllNewsPapers.Add(newspaper);
                }
            }
            Console.WriteLine("Alle kranten uit de leeszaal:");
            foreach (var item in AllNewsPapers)
            {
                Console.WriteLine($"{item.Title} van {item.Date.Date} van uitgeverij {item.Publisher}.");
            }
        }

        public void AqcuisitionsReadingRoomToday()
        {
            Console.Clear();
            List<ReadingRoomItem> Aqcuisitions = new List<ReadingRoomItem>();
            foreach (var item in AllReadingRoom)
            {
                if (item.Key.Date == DateTime.Today)
                {
                    Aqcuisitions.Add(item.Value);
                }
            }
            Console.WriteLine($"Aanwinsten in de leeszaal van {DateTime.Today.Date}:");
            foreach (var item in Aqcuisitions)
            {
                Console.WriteLine($"{item.Title} met id {item.Identification}");
            }
        }

    }

}
