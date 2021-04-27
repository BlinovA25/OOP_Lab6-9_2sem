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
    /// Логика взаимодействия для AddFuelPage.xaml
    /// </summary>
    public partial class AddFuelPage : Page
    {
        public AddFuelPage()
        {
            InitializeComponent();

            if (File.Exists(@"F:\OOP\FuelList.xml"))
            {
                FuelList = ReadData();
            }
            else
            {
                FuelList = new List<Fuel>();
            }
        }

        List<Fuel> FuelList;
        //public int r;
        private void AddFuel_Click(object sender, RoutedEventArgs e)
        {
            Fuel fuel = new Fuel();

            fuel.Name = Fname.Text;
            Int32.TryParse(Fcost.Text, out int price);
            fuel.Price = price;

            FuelList.Add(fuel);

            var results = new List<ValidationResult>();
            var context = new ValidationContext(fuel);
         
                string filename = @"F:\OOP\FuelList.xml";
                XmlSerializeWrapper.Serialize(FuelList, filename);

            MessageBox.Show("Информация добавлена в файл FuelList.xml");
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
