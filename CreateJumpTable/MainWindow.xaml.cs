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
using CreateJumpTable.Models;
using CreateJumpTable.Cmds;

namespace CreateJumpTable
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindowViewModel ViewModel { get; set; } = new MainWindowViewModel();        
        
        public void TitleJumpTable(int CountInputI, int CountOutputI, int CountCycleI, int CountJumpI, Table table, FlowDocument document)
        {
            // Add Table to Doc
            document.Blocks.Add(table);
            // Properties Table
            table.CellSpacing = 10;
            table.Background = Brushes.White;
            table.BorderBrush = Brushes.Black;
            ThicknessConverter thicknessConverter = new ThicknessConverter();
            table.BorderThickness = (Thickness)thicknessConverter.ConvertFromString("1");
            // Create Column Table
            for (int i = 0; i <= Math.Pow(2, CountInputI); i++)
            {
                table.Columns.Add(new TableColumn());
                if (i > 0)
                {
                    if (i % 2 == 0)
                        table.Columns[i].Background = Brushes.LightBlue;
                    else
                        table.Columns[i].Background = Brushes.LightCoral;
                }

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
            currentRow.Cells[0].ColumnSpan = Convert.ToInt32(Math.Pow(2, CountInputI));
            // Add the second (header) row.
            table.RowGroups[0].Rows.Add(new TableRow());
            currentRow = table.RowGroups[0].Rows[1];
            // Global formatting for the header row.
            currentRow.FontSize = 10;
            currentRow.FontWeight = FontWeights.Bold;
            // Add cells with content to the second row.
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("S"))));
            for (int i = 0b_00; i < Math.Pow(2, CountInputI); i++)
            {
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(Convert.ToString(i, toBase: 2)))));
            }
            for (int i = 1; i <= CountJumpI; i++)
            {
                table.RowGroups[0].Rows.Add(new TableRow());
                currentRow = table.RowGroups[0].Rows[i + 1];
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(i.ToString()))));
            }
        }
        public void CreateTable(int CountInputI, int CountOutputI, int CountCycleI, int CountJumpI, Table table, string[,] StringTable)
        {
            for (int i = 1; i <= CountJumpI; i++)
            {
                TableRow currentRow = table.RowGroups[0].Rows[i + 1];
                for (int j = 1; j <= Math.Pow(2, CountInputI); j++)
                {
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(StringTable[i - 1, j - 1]))));
                }
            }
        }
        public void CreateText(int CountInputI, int CountOutputI, FlowDocument document)
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FlowDocument document = new FlowDocument();
            Table table = new Table();
            string[,] StringTable;
            CreateText(CreateTableString.CountInputI, CreateTableString.CountOutputI, document);
            StringTable = CreateTableString.StringTable(CreateTableString.CountInputI, CreateTableString.CountOutputI, CreateTableString.CountCycleI, CreateTableString.CountJumpI);
            TitleJumpTable(CreateTableString.CountInputI, CreateTableString.CountOutputI, CreateTableString.CountCycleI, CreateTableString.CountJumpI, table, document);
            CreateTable(CreateTableString.CountInputI, CreateTableString.CountOutputI, CreateTableString.CountCycleI, CreateTableString.CountJumpI, table, StringTable);
            MessageBox.Show("Генерация таблицы переходов и выходов.",
                            "Информация",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }
    }
}
