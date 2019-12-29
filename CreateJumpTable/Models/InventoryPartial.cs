using System.ComponentModel;

namespace CreateJumpTable.Models
{
    public partial class Inventory : EntityBase, IDataErrorInfo
    {
        private string _error;
        public string Error => _error;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(PreSetId):
                        AddErrors(nameof(PreSetId), GetErrorsFromAnnotations(nameof(PreSetId), PreSetId));
                        break;
                    case nameof(CountInputI):
                            ClearErrors(nameof(CountInputI));
                            ClearErrors(nameof(CountOutputI));
                        AddErrors(nameof(CountInputI), GetErrorsFromAnnotations(nameof(CountInputI), CountInputI));
                        break;
                    case nameof(CountOutputI):
                            ClearErrors(nameof(CountInputI));
                            ClearErrors(nameof(CountOutputI));
                        AddErrors(nameof(CountOutputI), GetErrorsFromAnnotations(nameof(CountOutputI), CountOutputI));
                        break;
                    case nameof(PreSetName):
                        AddErrors(nameof(PreSetName), GetErrorsFromAnnotations(nameof(PreSetName), PreSetName));
                        break;
                }
                return string.Empty;
            }
        }
    }
}