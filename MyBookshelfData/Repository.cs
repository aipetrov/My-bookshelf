using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookshelfData
{
    public class Repository
    {
        public User AuthorisedUser { get; set; }

        public bool SignedIn(string login, string password)
        {
            Context context = new Context();
            var users = context.Users.ToList();
            var authorisedUser = from u in users
                                 where (u.Login == login && u.Password == password)
                                 select u;
            if (authorisedUser == null)
            {
                AuthorisedUser = authorisedUser as User;
                return true;                
            }
            else
            {
                return false;
            }
        }

        public void SignUp(string login, string password, string name, DateTime birth)
        {
            Context context = new Context();
            var users = context.Users.ToList();
            users.Add(new User { Login = login, Password = password, Name = name, Birth = birth });
            context.SaveChanges();
        }

        public List<string> GetBooks()
        {
            Context context = new Context();
            var books = context.Books.ToList();
            List<string> gotBooks = new List<string>();
            foreach (var book in books)
            {
                gotBooks.Add(string.Format("\"{0}\" - {1} ({2})", book.Title, book.Author, book.Genre));
            }
            return gotBooks;
        }
    }
}
