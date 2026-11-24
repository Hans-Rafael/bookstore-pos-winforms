using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; } = 5;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
    }
}