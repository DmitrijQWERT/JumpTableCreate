using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace CreateJumpTable.Models
{
    public partial class Inventory : INotifyPropertyChanged
    {
        public bool IsChanged { get; set; }
        [Required]
        public int PreSetId { get; set; }
        [Required]
        public int CountInputI { get; set; }
        [Required]
        public int CountOutputI { get; set; }
        [Required]
        public int CountCycleI { get; set; }
        [Required]
        public int CountJumpI { get; set; }
        [Required, StringLength(50)]
        public string PreSetName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != nameof(IsChanged))
            {
                IsChanged = true;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }

    }

}
