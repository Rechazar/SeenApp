using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;
using Xamarin.Essentials;
using System.IO;
using SQLite;

namespace SeenApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public interface ISQLite
        {
            SQLiteConnection GetConnection();
        }

        private async void TakeAPhotoButton_OnClicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();
            
            if(result != null)
            {
                var stream = await result.OpenReadAsync();

                image.Source = ImageSource.FromStream(() => stream);
            }
        }

        private async void PickAPhotoButton_OnClicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });

            if(result != null)
            {
                var stream = await result.OpenReadAsync();
                image.Source = ImageSource.FromStream(() => stream);
            }
        }

        private void UploadButton_OnClicked(object sender, EventArgs e)
        {

        }
    }
}
