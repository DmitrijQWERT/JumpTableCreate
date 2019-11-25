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

namespace JumpTableCreate
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
        /// <summary>
        /// Обработка нажатия щапуска генерации.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            ArgToInt();
            MessageBox.Show("Генерация таблицы переходов и выходов.",
                            "Информация",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }
        /// <summary>
        /// Получение параметров таблицы переходов/выходов
        /// </summary>
        public void ArgToInt()
        {
            int countInputI = Convert.ToInt32(countInput.Text);
            int countOutputI = Convert.ToInt32(countOutput.Text);
            int countCycleI = Convert.ToInt32(countCycle.Text);
            int countJumpI = Convert.ToInt32(countJump.Text);
        }
    }
}
