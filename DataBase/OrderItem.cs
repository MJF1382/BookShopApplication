using System;
using System.Collections.Generic;

namespace BookShopApplication.Database
{
    public partial class OrderItem
    {
        public int OrderId { get; set; }
        public string BookIsbn { get; set; } = null!;
        public int Qty { get; set; }

        public virtual Book BookIsbnNavigation { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
