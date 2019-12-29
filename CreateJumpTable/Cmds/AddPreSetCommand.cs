using System.Collections.ObjectModel;
using System.Linq;
using CreateJumpTable.Models;

namespace CreateJumpTable.Cmds
{
    public class AddPreSetCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return parameter != null && parameter is ObservableCollection<Inventory>;
        }

        public override void Execute(object parameter)
        {
            if (parameter is ObservableCollection<Inventory> SetupJump)
            {
                var maxCount = SetupJump?.Max(x => x.PreSetId) ?? 0;
                SetupJump?.Add(new Inventory { PreSetId = ++maxCount, PreSetName = "Default", CountInputI = 2, CountOutputI = 2, CountCycleI = 3, CountJumpI = 9 });
            }
        }
    }
}