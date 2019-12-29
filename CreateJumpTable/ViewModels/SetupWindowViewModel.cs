using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CreateJumpTable.Cmds;
using CreateJumpTable.Models;

namespace CreateJumpTable.ViewModels
{
    public class SetupWindowViewModel
    {
        public IList<Inventory> SetupJump { get; } = new ObservableCollection<Inventory>();

        public SetupWindowViewModel()
        {
            SetupJump.Add(
                new Inventory { PreSetId = 1, PreSetName = "Отладка", CountInputI = 2, CountOutputI = 2, CountCycleI = 1, CountJumpI = 9, IsChanged = false });
            SetupJump.Add(
                new Inventory { PreSetId = 2, PreSetName = "Стандарт", CountInputI = 2, CountOutputI = 2, CountCycleI = 3, CountJumpI = 9, IsChanged = false });
        }
        //private ICommand _saveCommand = null;
        //public ICommand SaveCmd => _saveCommand ?? (_saveCommand = new SaveCommand());

        private ICommand _addPreSetCommand = null;
        public ICommand AddPreSetCmd => _addPreSetCommand ?? (_addPreSetCommand = new AddPreSetCommand());

        private RelayCommand<Inventory> _deletePreSetCommand = null;
        public RelayCommand<Inventory> DeletePreSetCmd
            => _deletePreSetCommand ?? (_deletePreSetCommand = new RelayCommand<Inventory>(DeletePreSet, CanDeletePreSet));
        private bool CanDeletePreSet(Inventory setupJump) => setupJump != null;
        private void DeletePreSet(Inventory setupJump)
        {
            SetupJump.Remove(setupJump);
        }
    }
}
