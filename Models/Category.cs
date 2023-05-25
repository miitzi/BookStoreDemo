using System.ComponentModel.DataAnnotations;

namespace BookStoreDemo.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [MaxLength(150)]
        public string CategoryName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public virtual List<Book> Book { get; set; }

        public Category()
        {
            
        }
    }
}
