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
using CreateJumpTable.ViewModels;
using System.Collections.ObjectModel;
using CreateJumpTable.Models;

namespace CreateJumpTable.Cmds
{
    public class SaveCommand : CommandBase
    {
        public int CountInputI { get; set; }
        public int CountOutputI { get; set; }
        public int CountCycleI { get; set; }
        public int CountJumpI { get; set; }
        public override bool CanExecute(object parameter)
        {
            return parameter != null && parameter is ObservableCollection<Inventory>;
        }
        public override void Execute(object parameter)
        {
            CreateTableString.CountInputI = ((Inventory)parameter).CountCycleI;
            CreateTableString.CountOutputI = ((Inventory)parameter).CountOutputI;
            CreateTableString.CountCycleI = ((Inventory)parameter).CountCycleI;
            CreateTableString.CountJumpI = ((Inventory)parameter).CountJumpI;
        }


    }
}