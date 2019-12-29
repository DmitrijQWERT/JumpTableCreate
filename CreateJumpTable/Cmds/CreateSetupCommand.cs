using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CreateJumpTable.Models;

namespace CreateJumpTable.Cmds
{
    public class CreateSetupCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            SetupWindow Setup = new SetupWindow();
            Setup.Show();
            //Setup.Owner = this;
        }
    }
}
