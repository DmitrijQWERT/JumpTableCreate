using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CreateJumpTable.Cmds;
using CreateJumpTable.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CreateJumpTable.ViewModels;

namespace CreateJumpTable.ViewModels
{
    public class MainWindowViewModel
    {
        //public IList<Inventory> MainSetupJump { get; } = new ObservableCollection<Inventory>();
        public MainWindowViewModel()
        {
        }

        private ICommand _createSetupCommand = null;
        public ICommand CreateSetupCmd => _createSetupCommand ?? (_createSetupCommand = new CreateSetupCommand());

        private ICommand _createTableCommand = null;
        public ICommand CreateTableCmd => _createTableCommand ?? (_createTableCommand = new CreateTableCommand());
    }
    
}
