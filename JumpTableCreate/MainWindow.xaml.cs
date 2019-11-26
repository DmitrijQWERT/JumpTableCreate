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
        private int countInputI;
        private int countOutputI;
        private int countCycleI;
        private int countJumpI;

        public int CountInputI { get => countInputI; set => countInputI = value; }
        public int CountOutputI { get => countOutputI; set => countOutputI = value; }
        public int CountCycleI { get => countCycleI; set => countCycleI = value; }
        public int CountJumpI { get => countJumpI; set => countJumpI = value; }

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
            CreateText(CountInputI, CountOutputI, CountCycleI, CountJumpI);
            MessageBox.Show("Генерация таблицы переходов и выходов.",
                            "Информация",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }
        /// <summary>
        /// Работа с потоковым документом
        /// </summary>
        private void CreateText(int CountInputI, int CountOutputI, int CountCycleI, int CountJumpI)
        {
            Run runInputI = new Run();
            runInputI.Text ="Количество входных переменных: " + CountInputI;
            Run runCountOutputI = new Run();
            runCountOutputI.Text = "Количество выходных переменных: " + CountOutputI;
            Run runLast = new Run();
            runLast.Text = "документов";
            Paragraph paragraphOne = new Paragraph();
            Paragraph paragraphTwo = new Paragraph();
            paragraphOne.Inlines.Add(runInputI);
            paragraphTwo.Inlines.Add(runCountOutputI);
            FlowDocument document = new FlowDocument();
            document.Blocks.Add(paragraphOne);
            document.Blocks.Add(paragraphTwo);
            docViewer.Document = document;
        }

        /// <summary>
        /// Получение параметров таблицы переходов/выходов
        /// </summary>
        public void ArgToInt()
        {
            CountInputI = Convert.ToInt32(countInput.Text);
            CountOutputI = Convert.ToInt32(countOutput.Text);
            CountCycleI = Convert.ToInt32(countCycle.Text);
            CountJumpI = Convert.ToInt32(countJump.Text);
        }
    }
}
