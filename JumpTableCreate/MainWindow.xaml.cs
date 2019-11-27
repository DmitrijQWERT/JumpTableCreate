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
        public int CountInputI { get; set; }
        public int CountOutputI { get; set; }
        public int CountCycleI { get; set; }
        public int CountJumpI { get; set; }

        FlowDocument document = new FlowDocument();

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
            CreateText(CountInputI, CountOutputI);
            JumpTable(CountInputI);
            MessageBox.Show("Генерация таблицы переходов и выходов.",
                            "Информация",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }
        /// <summary>
        /// Создание таблицы переходов
        /// </summary>
        private void JumpTable(int CountInputI)
        {
            // Create Table
            Table table = new Table();
            // Add Table to Doc
            document.Blocks.Add(table);
            // Properties Table
            table.CellSpacing = 10;
            table.Background = Brushes.White;
            // Create Column Table
            for (int i = 0; i < CountInputI; i++)
            {
                table.Columns.Add(new TableColumn());
                if (i % 2 == 0)
                    table.Columns[i].Background = Brushes.Beige;
                else
                    table.Columns[i].Background = Brushes.LightSteelBlue;
            }
            // Create and add an empty TableRowGroup to hold the table's Rows.
            table.RowGroups.Add(new TableRowGroup());
            // Add the first (title) row.
            table.RowGroups[0].Rows.Add(new TableRow());
            // Alias the current working row for easy reference.
            TableRow currentRow = table.RowGroups[0].Rows[0];
            // Global formatting for the title row.
            currentRow.Background = Brushes.Silver;
            currentRow.FontSize = 10;
            currentRow.FontWeight = FontWeights.Bold;
            // Add the header row with content, 
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Таблица переходов и выходов"))));
            // and set the row to span all columns.
            currentRow.Cells[0].ColumnSpan = CountInputI;
            // Add the second (header) row.
            table.RowGroups[0].Rows.Add(new TableRow());
            currentRow = table.RowGroups[0].Rows[1];
            // Global formatting for the header row.
            currentRow.FontSize = 10;
            currentRow.FontWeight = FontWeights.Bold;
            // Add cells with content to the second row.
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("S"))));
            for (int i = 0; i < CountInputI; i++)
            {
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("X"+ i))));
            }

        }

        /// <summary>
        /// Работа с потоковым документом
        /// </summary>
        private void CreateText(int CountInputI, int CountOutputI)
        {
            Run runInputI = new Run
            {
                Text = "Количество входных переменных: " + CountInputI
            };
            Run runCountOutputI = new Run
            {
                Text = "Количество выходных переменных: " + CountOutputI
            };
            Paragraph paragraphOne = new Paragraph();
            Paragraph paragraphTwo = new Paragraph();
            paragraphOne.Inlines.Add(runInputI);
            paragraphTwo.Inlines.Add(runCountOutputI);
            
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
