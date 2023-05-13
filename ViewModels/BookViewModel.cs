using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApplication.ViewModels
{
    public class BookViewModel
    {
        public string Isbn { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string CategoryName { get; set; }
        public int Price { get; set; }
    }
}
