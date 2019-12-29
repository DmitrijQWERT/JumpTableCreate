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
using CreateJumpTable.Cmds;
using CreateJumpTable.Models;
using CreateJumpTable.ViewModels;

namespace CreateJumpTable
{
    /// <summary>
    /// Логика взаимодействия для SetupWindow.xaml
    /// </summary>
    public partial class SetupWindow : Window
    {
        public SetupWindow()
        {
            InitializeComponent();
        }
        public SetupWindowViewModel ViewModel { get; set; } = new SetupWindowViewModel();

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CreateTableString.CountInputI = Convert.ToInt32(CountInputI.Text);
            CreateTableString.CountOutputI = Convert.ToInt32(CountOutputI.Text);
            CreateTableString.CountCycleI = Convert.ToInt32(CountCycleI.Text);
            CreateTableString.CountJumpI = Convert.ToInt32(CountJumpI.Text);
        }
    }
}
