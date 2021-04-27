using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для ShowShopItemsPage.xaml
    /// </summary>
    public partial class ShowShopItemsPage : Page
    {
        public BindingList<ShopItem> shopItems = new BindingList<ShopItem>();
        public ShowShopItemsPage()
        {
            InitializeComponent();

            try
            {
                shopItems = XmlSerializeWrapper.Deserialize<BindingList<ShopItem>>(@"F:\OOP\ShopItemList.xml");
                shopItemsGrid.ItemsSource = shopItems;
            }
            catch
            { MessageBox.Show($"Десериализация была прервана."); }
        }
    }
}

