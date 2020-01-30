using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyApp.Models
{
    public class myImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public decimal Price { get; set; }
        public ImageSource imageSource { get; set; }
    }
}
