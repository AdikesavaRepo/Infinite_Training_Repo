using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Models;

namespace CodeFirst
{
    class Program
    {
        static BooksDBContext db = new BooksDBContext();

        static void Main(string[] args)
        {
            Console.WriteLine("Insert a new Book to table");
            AddBooks();
            ShowAllBooks();

            Console.WriteLine("Updating/Modifying The Books");
            UpdateBook();
            ShowAllBooks();

            Console.WriteLine("Deleting particular Book Record");
            DeleteBook();
            ShowAllBooks();
            Console.Read();
        }

        public static void ShowAllBooks()
        {
            var bk = from b in db.book
                     select b;

            foreach (var item in bk)
            {
                Console.WriteLine(item.BookId + " " + item.BookName + " " + item.Price + " " + item.YearPublished);
            }
        }


        public static void AddBooks()
        {
            Books b = new Books();

            Console.WriteLine("Enter Books Details");

            Console.WriteLine("Enter BookId");
            b.BookId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter BookName");
            b.BookName = Console.ReadLine();

            Console.WriteLine("Enter Book Price");
            b.Price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter BookYear");
            b.YearPublished = Convert.ToDateTime(Console.ReadLine());
            db.book.Add(b);
            db.SaveChanges();
        }

        public static void UpdateBook()
        {
            Console.WriteLine("Enter BookId for what data has to be modified :");
            int BookId = Convert.ToInt32(Console.ReadLine());
            Books b = db.book.Find(BookId);
            

            if (b != null)
            {
                Console.WriteLine("Rename the book name for which booj id u want to modify");
                b.BookName = Console.ReadLine() ;
                
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Book Record not found");
            }
        }

        public static void DeleteBook()
        {
            Console.WriteLine("Enter BookID to delete");
            int BookId = Convert.ToInt32(Console.ReadLine());
            Books b1 = db.book.Find(BookId);
 
            db.book.Remove(b1);
            db.SaveChanges();
        }

    }
}
