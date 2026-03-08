using System;

namespace UniversitetsSystem
{
    public class Loan
    {
        public string LoanId { get; set; }
        public Book Book { get; set; }
        public IBorrower Borrower { get; set; }
        public DateTime BorrowDate { get; set; }
        public bool IsReturned { get; set; }

        public Loan(string loanId, Book book, IBorrower borrower)
        {
            LoanId = loanId;
            Book = book;
            Borrower = borrower;
            BorrowDate = DateTime.Now;
            IsReturned = false;
        }

        public void PrintInfo()
        {
            string status = IsReturned ? "Returnert" : "Aktivt lån";
            Console.WriteLine($"{LoanId}: {Book.Title} lånt av {Borrower.GetBorrowerName()} ({Borrower.GetBorrowerId()}) - {status}");
        }
    }
}