using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreDemo.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public int CategoryId { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Author { get; set; }

        public virtual Category Category { get; set; }

        public Book()
        {
            
        }
    }
}
