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

namespace Mars_Rovers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var input = int.Parse(upperRight.Text);
            var width = input % 10;
            var height = input / 10;
            TwoRovers twoRovers = new TwoRovers();
            for (int i = 1; i < width; i++)
            {
                var newRow = new RowDefinition();
                newRow.Name = $"row{i}";
                twoRovers.TheGrid.RowDefinitions.Add(newRow);
            }
            for (int i = 1; i < height; i++)
            {
                var newColumn = new ColumnDefinition();
                newColumn.Name = $"col{i}";
                twoRovers.TheGrid.ColumnDefinitions.Add(newColumn);
            }



            twoRovers.Show();


        }
    }
}

