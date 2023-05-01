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
using Template_4335.Windows.Sal_4335;

namespace Template_4335.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Sal4335 : Window
    {
        public Sal4335()
        {
            InitializeComponent();
        }

        private void ExcelPageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ExcelPage());
        }

        private void WordPageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new WordPage());
        }

        private void DeleteDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Очистить данные?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (var isrpoEntities = new IsrpoEntities())
                {
                    isrpoEntities.employees.RemoveRange(isrpoEntities.employees.ToList());
                    isrpoEntities.SaveChanges();
                    IsrpoEntities.GetContext().employees.AsEnumerable().OrderBy(x => Convert.ToInt32(x.id_e)).ToList().Clear();
                    foreach (var uslugi in isrpoEntities.employees.AsEnumerable().OrderBy(x => Convert.ToInt32(x.id_e)).ToList())
                    {
                        IsrpoEntities.GetContext().employees.AsEnumerable().OrderBy(x => Convert.ToInt32(x.id_e)).ToList().Add(uslugi);
                    }
                }
            }
        }
    }
}
