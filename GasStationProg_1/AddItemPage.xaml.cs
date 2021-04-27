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

using System.Text.RegularExpressions;//.Regex;
using System.ComponentModel.DataAnnotations;
using System.IO;
using ValidationResult = System.Windows.Controls.ValidationResult;

namespace GasStationProg_1
{
    /// <summary>
    /// Логика взаимодействия для AddItemPage.xaml
    /// </summary>
    /// 

    public static class Photo 
    {
        public static string FileName;
    }

    public partial class AddItemPage : Page
    {
        public AddItemPage()
        {
            InitializeComponent();
            if (File.Exists(@"F:\OOP\ShopItemsList.xml"))
            {
                ShopItemsList = ReadData();
            }
            else
            {
                ShopItemsList = new List<ShopItem>();
            }
        }


        List<ShopItem> ShopItemsList;
        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            ShopItem shopItem = new ShopItem();

            shopItem.Name = Iname.Text;
            Int32.TryParse(Icost.Text, out int price);
            shopItem.Price = price;

            shopItem.Description = Idescr.Text;

            if (Photo.FileName != string.Empty)
            { shopItem.Photo = Photo.FileName; }

            ShopItemsList.Add((ShopItem)shopItem);

            var results = new List<ValidationResult>();
            var context = new ValidationContext(shopItem);

            string filename = @"F:\OOP\ShopItemList.xml";
            XmlSerializeWrapper.Serialize(ShopItemsList, filename);

            MessageBox.Show("Информация добавлена в файл ShopItemList.xml");
        }

        private void ChoosePhoto_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".png"; // Default file extension
                                     //    dlg.Filter = "Pictures (.png,jpg)|*.png,*.jpg"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(dlg.FileName);
                image.EndInit();
                ItemPicture.Source = image;

                Photo.FileName = dlg.FileName;
            }
        }

        private static List<ShopItem> ReadData()
        {
            string filename = @"F:\OOP\ShopItemsList.xml";

            List<ShopItem> deserializeDisciplines = new List<ShopItem>();
            deserializeDisciplines = XmlSerializeWrapper.Deserialize<List<ShopItem>>(filename);//.ToString();
            return deserializeDisciplines;
        }
    }
}
