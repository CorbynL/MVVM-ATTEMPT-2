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
using System.Windows.Shapes;

namespace aGame
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class StartingMenu : Window
    {
        public string NameChoice;
        public string ClassChoice;
        private string[] Classes;

        public StartingMenu()
        {
            InitializeComponent();

            Classes = new string[] { "Mage", "Warrior", "Theif" };
            ClassSelection.ItemsSource = Classes;
        }



        //public void button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (NameChoiceTxt.Text == null || NameChoiceTxt.Text == "") { MessageBox.Show("Choose a name"); return; }
        //    NameChoice = NameChoiceTxt.Text;

        //    if (ClassSelection.SelectedItem == null) { MessageBox.Show("Choose a class"); return; }
        //    ClassChoice = (string)ClassSelection.SelectedItem;
        //}
    }
}
