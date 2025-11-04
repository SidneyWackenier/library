using System.Threading.Channels;

namespace Bib_SidneyWackenier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library arcanaeum = new Library("The Arcanaeum");
            bool exit = false;

            AddBooksFromCSVInput(arcanaeum);

            do
            {
                Console.WriteLine($"Welcome in {arcanaeum.Name}!");
                Console.WriteLine("Wat wil je doen?");
                Console.WriteLine("-------------");
                Console.WriteLine("1. Een boek toevoegen");
                Console.WriteLine("2. Voeg informatie toe aan een bestaand boek");
                Console.WriteLine("3. Zoek naar een boek met bepaalde titel en auteur");
                Console.WriteLine("4. Andere manieren om een boek te zoeken");
                Console.WriteLine("5. Verwijder een boek");
                Console.WriteLine("6. Toon alle boeken");
                Console.WriteLine("7: Een krant of maandblad toevoegen");
                Console.WriteLine("8: Alle kranten tonen");
                Console.WriteLine("9: Alle maandbladen tonen");
                Console.WriteLine("10: Aanwinsten opvragen");
                Console.WriteLine("11: Een boek ontlenen");
                Console.WriteLine("12: Een boek terugbrengen");

                string response =  Console.ReadLine();

                switch (response)
                {
                    case "1":
                        AddBook(arcanaeum);
                        break;
                    case "2":
                        EditBook(arcanaeum);
                        break;
                    case "3":
                        SearchForBookTitleAuthor(arcanaeum);
                        break;
                    case "4":
                        SearchForBookOthers(arcanaeum);
                        break;
                    case "5":
                        RemoveBook(arcanaeum);
                        break;
                    case "6":
                        ShowAllBooks(arcanaeum);
                        break;
                    case "7":
                        AddReadingRoomItem(arcanaeum);
                        break;
                    case "8":
                        Console.Clear();
                        arcanaeum.ShowAllNewsPapers();
                        break;
                    case "9":
                        Console.Clear();
                        arcanaeum.ShowAllMagazines();
                        break;
                    case "10":
                        Console.Clear();
                        arcanaeum.AqcuisitionsReadingRoomToday();
                        break;
                    case "11":
                        LoanBook(arcanaeum);
                        break;
                    case "12":
                        ReturnBook(arcanaeum);
                        break;
                    case "exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ongeldige invoer!");
                        break;
                }
            } while (exit == false);
        }

        public static void AddBook(Library arcanaeum)
        {
            string title;
            string author;

            try
            {
                Console.Clear();
                Console.Write("Voer de titel van het boek in: ");
                title = Console.ReadLine();
                Console.Write("Voer de auteur van het boek in: ");
                author = Console.ReadLine();

                Book newBook = new Book(title, author, arcanaeum);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Titel/Auteur mag niet leeg zijn!");
            }
        }

        public static void EditBook(Library arcanaeum)
        {
            string title;
            string author;
            bool addInfo = true;

            Console.Clear();
            Console.Write("Voer de titel van het boek in: ");
            title = Console.ReadLine();
            Console.Write("Voer de auteur van het boek in: ");
            author = Console.ReadLine();

            Book bookToEdit = arcanaeum.SearchForBook(title, author);

            Console.WriteLine($"Boek gevonden: {bookToEdit.Title} door {bookToEdit.Author}");

            do
            {
                Console.WriteLine("Wat wil je aan dit boek toevoegen?");
                Console.WriteLine("--------");
                Console.WriteLine("1. ISBN-nummer");
                Console.WriteLine("2. Genre");
                Console.WriteLine("3. Uitgever");
                Console.WriteLine("4. Prijs");
                Console.WriteLine("5. Aantal Paginas");
                Console.WriteLine("6. Publicatiejaar");

                string selection = Console.ReadLine();

                if (selection == "1")
                {
                    try
                    {
                        Console.WriteLine("Voer het ISBN-nummer in:");
                        bookToEdit.ISBN = Console.ReadLine();
                    }
                    catch (InvalidLengthException e)
                    {

                        Console.WriteLine(e);
                    }
                }

                else if (selection == "2")
                {
                    Console.WriteLine("Selecteer het genre:");
                    Console.WriteLine($"1. {BookGenre.Horror}");
                    Console.WriteLine($"2. {BookGenre.Fantasy}");
                    Console.WriteLine($"3. {BookGenre.Thriller}");
                    Console.WriteLine($"4. {BookGenre.ScienceFiction}");
                    Console.WriteLine($"5. {BookGenre.Crime}");
                    Console.WriteLine($"6. {BookGenre.SchoolBoek}");

                    try
                    {
                        BookGenre genre = (BookGenre)Convert.ToInt32(Console.ReadLine());

                        bookToEdit.Genre = genre;

                        Console.Clear();
                        Console.WriteLine("Genre toegevoegd!");
                        Console.WriteLine();
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine("Gebruik de nummers om het genre te selecteren!");
                    }
                }

                else if (selection == "3")
                {
                    try
                    {
                        Console.WriteLine("Voer de uitgever in: ");
                        bookToEdit.Publisher = Console.ReadLine();
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("Uitgever mag niet leeg zijn!");
                    }
                }

                else if (selection == "4")
                {
                    Console.WriteLine("Voer de prijs in: ");
                    bookToEdit.Price = Convert.ToDouble(Console.ReadLine());
                }

                else if (selection == "5")
                {
                    Console.WriteLine("Voer het aantal paginas in: ");
                    bookToEdit.Pages = Convert.ToInt32(Console.ReadLine());
                }

                else if (selection == "6")
                {
                    Console.WriteLine("Voer het publicatiejaar in: ");
                    bookToEdit.Price = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Wens je nog iets aan dit boek toe te voegen?");
                string keepAdding = Console.ReadLine().ToUpper();

                if (keepAdding == "JA")
                {
                    addInfo = true;
                }
                else
                {
                    addInfo = false;
                }

            } while (addInfo == true);

            
        }

        public static void SearchForBookTitleAuthor(Library arcanaeum)
        {
            string title;
            string author;

            Console.Clear();
            Console.Write("Voer de titel van het boek in: ");
            title = Console.ReadLine();
            Console.Write("Voer de auteur van het boek in: ");
            author = Console.ReadLine();

            Book book = arcanaeum.SearchForBook(title, author);

            book.DisplayBook();
        }

        public static void SearchForBookOthers(Library arcanaeum)
        {
            Console.Clear();
            Console.WriteLine("Op basis van welk gegeven wil je zoeken?: ");
            Console.WriteLine("1. ISBN-Nummer");
            Console.WriteLine("2. Genre");
            Console.WriteLine("3. Auteur");

            string selection = Console.ReadLine();

            if (selection == "1")
            {
                Console.WriteLine("Voer het ISBN-nummer in: ");
                string isbn = Console.ReadLine();

                Book isbnBook = arcanaeum.SearchForISBN(isbn);

                Console.WriteLine($"Boek gevonden: {isbnBook.Title} door {isbnBook.Author}");
            }

            else if (selection == "2")
            {
                Console.WriteLine("Selecteer het genre:");
                Console.WriteLine($"1. {BookGenre.Horror}");
                Console.WriteLine($"2. {BookGenre.Fantasy}");
                Console.WriteLine($"3. {BookGenre.Thriller}");
                Console.WriteLine($"4. {BookGenre.ScienceFiction}");
                Console.WriteLine($"5. {BookGenre.Crime}");
                Console.WriteLine($"6. {BookGenre.SchoolBoek}");

                BookGenre genre = (BookGenre)Convert.ToInt32(Console.ReadLine());

                List<Book> genreBooks = arcanaeum.BooksByGenre(genre);

                foreach (Book books in genreBooks)
                {
                    Console.WriteLine($"{books.Title} door {books.Author}");
                }
            }

            else if (selection == "3")
            {
                Console.WriteLine("Voer de auteur van het boek in: ");
                string author = Console.ReadLine();

                List<Book> authorBooks = arcanaeum.BooksByAuthor(author);

                foreach (Book books in authorBooks)
                {
                    Console.WriteLine($"{books.Title} door {books.Author}");
                }
            }
        }

        public static void RemoveBook(Library arcanaeum)
        {
            string title;
            string author;

            Console.Clear();
            Console.Write("Voer de titel van het boek in: ");
            title = Console.ReadLine();
            Console.Write("Voer de auteur van het boek in: ");
            author = Console.ReadLine();

            arcanaeum.RemoveBook(title, author);
            Console.WriteLine("Boek verwijderd.");
        }

        public static void ShowAllBooks(Library arcanaeum)
        {
            Console.Clear();
            foreach (Book books in arcanaeum.Books)
            {
                Console.WriteLine($"{books.Title} door {books.Author}");
                Console.WriteLine("");
            }
        }

        public static void AddReadingRoomItem(Library arcanaeum)
        {
            Console.Clear();
            Console.WriteLine("Krant of maandblad?");
            string type = Console.ReadLine().ToUpper();

            if (type == "KRANT")
            {
                arcanaeum.AddNewsPaper();
            }
            else if (type == "MAANDBLAD")
            {
                arcanaeum.AddMagazine();
            }
        }

        public static void LoanBook(Library arcanaeum)
        {
            string title;
            string author;

            Console.Clear();
            Console.Write("Geef de titel van het boek: ");
            title = Console.ReadLine();
            Console.Write("Geef de auteur van het boek: ");
            author = Console.ReadLine();

            Book book = arcanaeum.SearchForBook(title, author);

            book.DisplayBook();
            Console.WriteLine("Wil je dit boek ontlenen?");

            string response = Console.ReadLine().ToUpper();
            if (response == "JA")
            {
                if (book.Genre == 0)
                {
                    Console.WriteLine("Dit boek heeft geen genre! Voeg een genre toe en probeer het dan terug te ontlenen.");
                }
                else
                {
                    book.Borrow();
                }
            }
            else if (response == "NO")
            {
                Console.WriteLine("Terug naar hoofdmenu: ");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ongeldige invoer!");
            }
        }

        public static void ReturnBook(Library arcanaeum)
        {
            string title;
            string author;

            Console.Clear();
            Console.Write("Geef de titel van het boek: ");
            title = Console.ReadLine();
            Console.Write("Geef de auteur van het boek: ");
            author = Console.ReadLine();

            Book book = arcanaeum.SearchForBook(title, author);

            book.DisplayBook();
            Console.WriteLine("Wil je dit boek terugbrengen?");

            string response = Console.ReadLine().ToUpper();
            if (response == "JA")
            {
                 book.Return();
            }
            else if (response == "NO")
            {
                Console.WriteLine("Terug naar hoofdmenu: ");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ongeldige invoer!");
            }
        }

        public static void AddBooksFromCSVInput(Library arcanaeum)
        {
            string[] lijnen = File.ReadAllLines(@"..\..\..\Data\books.csv");
            for (int i = 0; i < lijnen.Length; i++)
            {
                string[] kolomwaarden = lijnen[i].Split(';');

                Book newBook = new Book(kolomwaarden[0], kolomwaarden[1], arcanaeum);
            }
        }
    }
}
