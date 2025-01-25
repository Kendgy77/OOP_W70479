using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Klasa Book dziedziczy LibraryItem

namespace project
{
    public class Book : LibraryItem
    {
        public string Author { get; set; }
        public int PublicationYear { get; set; }
    }
}
    