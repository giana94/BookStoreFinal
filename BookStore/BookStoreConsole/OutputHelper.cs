using BookStore.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreConsole
{
    public class OutputHelper
    {
        //public void WriteToConsole(List<Book> books)
        //{
        //    Console.WriteLine("List of Books:");
        //    foreach (var book in books)
        //    {
        //        Console.WriteLine($"BookID: {book.BookId}    Title: {book.BookTitle}     Author: {book.Author.AuthorFirst} {book.Author.AuthorLast}   Release Year: {book.YearOfRelease}");
        //    }

        //}

        //public void WriteToCSV(List<Book> books)
        //{
        //    using (var writer = new StreamWriter(@"..\file.csv"))
        //    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        //    {
        //        csv.WriteRecords(books);
        //    }

        //}

        public void Output(List<Book> books, string outputType)
        {
            if (outputType.Equals("CSV", StringComparison.OrdinalIgnoreCase))
            {
                WriteToCSV(books);
            }
            else if (outputType.Equals("Console", StringComparison.OrdinalIgnoreCase))
            {
                WriteToConsole(books);
            }
            else
            {
                Console.WriteLine("Invalid output type. Please specify 'CSV' or 'Console'.");
            }
        }

        public void WriteToConsole(List<Book> books)
        {

            Console.WriteLine("List of Books:");
            foreach (var book in books)
            {
                Console.WriteLine($"BookID: {book.BookId}    Title: {book.BookTitle}     Author: {book.Author.AuthorFirst} {book.Author.AuthorLast}   Release Year: {book.YearOfRelease}");
            }

        }

        public void WriteToCSV(List<Book> books)
        {
            using (var writer = new StreamWriter(@"..\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(books);
            }

        }

    }
}
