using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace practical8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            // populate imagelist with sample image paths
            ImageList.Items.Add("https://image.tmdb.org/t/p/w440_and_h660_bestv2/jcvJ2xcVWU9Wh0hZAxcs103s8nN.jpg");
            ImageList.Items.Add("https://image.tmdb.org/t/p/w440_and_h660_bestv2/miDoEMlYDJhOCvxlzI0wZqBs9Yt.jpg");
            ImageList.Items.Add("https://image.tmdb.org/t/p/w440_and_h660_bestv2/dM2w364MScsjFf8pfMbaWUcWrR.jpg");

        }

        // Add button click event handler
        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            // verify that the TbPath control contains a valid URI
            // If valid then add the path to the ImageList
            // else display an error MessageBox to the user
            var path = TbPath.Text;

            if (Uri.IsWellFormedUriString(path, UriKind.Absolute))
            {
                var uri = new Uri(path, UriKind.Absolute);
                ImageList.Items.Add(uri);
            }
            else
            {
                MessageBox.Show("Invalid url ", "Error");
            }

        }

        private void BDel_Click(object sender, RoutedEventArgs e)
        {
            // verify that an item is selected in the ImageList
            // if selected then create a url from the selected item
            // display the image from the url
            var selected = ImageList.SelectedIndex;
            if (selected != -1)
            {
                ImageList.Items.RemoveAt(selected);
            }

        }

        private void ImageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = ImageList.SelectedIndex;
            if (index != -1)
            {
                BDel.IsEnabled = true;
                var path = ImageList.Items[index].ToString();
                var uri = new Uri(path, UriKind.Absolute);
                Image.Source = new BitmapImage(uri);
            }
        }
    }
}
