using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyApp.Models
{
    public class Album
	{

		public Album()
		{
			DemoImage = Images[0].MyImageSource;
			Images.RemoveAt(0);
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public ObservableCollection<MyImage> Images { get; set; }
		public string Price { get; set; }

		public string DemoImage { get; set; }
	}
}
