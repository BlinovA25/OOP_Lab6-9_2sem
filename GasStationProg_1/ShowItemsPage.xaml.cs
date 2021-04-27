using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace GasStationProg_1
{
    /// <summary>
    /// Логика взаимодействия для ShowItemsPage.xaml
    /// </summary>
    /// 
    public partial class ShowItemsPage : Page
    {
        public BindingList<Fuel> items = new BindingList<Fuel>();
        public ShowItemsPage()
        {
            InitializeComponent();

            try
            {
                items = XmlSerializeWrapper.Deserialize<BindingList<Fuel>>(@"F:\OOP\FuelList.xml"); 
                fuelGrid.ItemsSource = items;
            }
            catch
            { MessageBox.Show($"Десериализация была прервана."); }

        }

        private static List<Fuel> ReadData()
        {
            string filename = @"F:\OOP\FuelList.xml";

            List<Fuel> deserializeDisciplines = new List<Fuel>();
            deserializeDisciplines = XmlSerializeWrapper.Deserialize<List<Fuel>>(filename);//.ToString();
            return deserializeDisciplines;
        }
    }
}
