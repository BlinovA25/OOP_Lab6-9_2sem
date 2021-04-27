using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
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
using System.Xml.Serialization;

namespace GasStationProg_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 


    public class Phone
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
    }


    [Serializable]
    //[XmlRoot(Namespace = "GasStationProg_1")]
    //[XmlType("Fuel")]
    public class Fuel
    {
        [XmlElement(ElementName = "name_of_fuel")]
        public string Name { get; set; }

        [XmlElement(ElementName = "price_of_fuel")]
        public int Price { get; set; }

        [XmlElement(ElementName = "type_of_fuel")]
        public string FuelType { get; set; }
        //public string Name;
        //public int Price;
        //public string FuelType;
    }


    [Serializable]
    //[XmlRoot(Namespace = "GasStationProg_1")]
    //[XmlType("ShopItem")]
    public class ShopItem 
    {
        [XmlElement(ElementName = "name_of_sitem")]
        public string Name { get; set; }

        [XmlElement(ElementName = "photo_of_sitem")]
        public string Photo { get; set; }

        [XmlElement(ElementName = "price_of_sitem")]
        public int Price { get; set; }

        [XmlElement(ElementName = "descr_of_sitem")]
        public string Description { get; set; }

        [XmlElement(ElementName = "type_of_sitem")]
        public string ItemType { get; set; }
    }


    public static class XmlSerializeWrapper
    {
        public static void Serialize<T>(T obj, string filename)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                formatter.Serialize(fs, obj);
            }
        }
        public static T Deserialize<T>(string filename)
        {
            T obj;
            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    obj = (T)serializer.Deserialize(fs);
                }
                return obj;
            }
            return default(T);
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new MainPage();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MainPage();
        }


        private void ShowShopItems_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ShowShopItemsPage();
        }

        private void ShowItems_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ShowItemsPage();
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AddItemPage();
        }

        private void AddFuel_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AddFuelPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonRU_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo lang = new CultureInfo("ru-RU");
            App.Language = lang;
        }

        private void ButtonEN_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo lang = new CultureInfo("en-US");
            App.Language = lang;
        }


    }
}
