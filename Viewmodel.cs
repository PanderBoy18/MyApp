using MyApp;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    public class VM_AlbumList : BindableObject
    {
        public ICommand LoadAlbums => new Command(MyHandler);

        bool handling = false;
		
        private ObservableCollection<Album> _albumList;
        public ObservableCollection<Album> albumList
        {
            get
            {
                return _albumList;
            }
            set
            {
                if (_albumList != value)
                {
                    _albumList = value;
                    OnPropertyChanged();
                }
            }
        }

        public VM_AlbumList()
        {
            albumList = new ObservableCollection<Album>();
            MyHandler();
        }

        public async Task LoadAlbumList()
        {
			List<Album> lstAlbums = new List<Album>();
			
			Album myAlbum = new Album
			{
				Id = 1,
				Name = Album1,
				Images = new myImage {
								Id = 1,
								Name = "image.png",
								price = "15",
								Format = "15cm X 30cm"
				},
				Price = 15
			}
			
			lstAlbums.Add(myAlbum)
            
            if (lstAlbums.Count != 0)
            {
                foreach (var album in lstAlbums)
                {
                    foreach (var image in album.Images)
                    {
                        ImageSource source = ImageSource.FromUri(new Uri("http://mysite.com/media/" + image.Name));
                        image.imageSource = source;
                    }

                    album.DemoImage = album.Images[0].imageSource;
                    albumList.Add(album);
                }
            }       
        }

        public async void MyHandler()
        {
            // already handling an event, ignore the new one
            if (handling) return;

            handling = true;

            await LoadAlbumList();

            handling = false;
        }
    }
}