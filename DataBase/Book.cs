using System;
using System.Collections.Generic;

namespace BookShopApplication.Database
{
    public partial class Book
    {
        public Book()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public string Isbn { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int CategoryId { get; set; }
        public int Price { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
