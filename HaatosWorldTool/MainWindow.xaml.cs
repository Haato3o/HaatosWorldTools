using System.Windows;
using HaatosWorldTool.Core;
using Microsoft.Win32;
using System.Linq;
using static HaatosWorldTool.Core.Native;


namespace HaatosWorldTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnOpenItemsDataClick(object sender, RoutedEventArgs e)
        {
            string filepath = OpenFile();

            if (filepath is null)
                return;

            cItemDataFile parsedFile = new cItemDataFile();

            ItemsData.Deserialize(filepath, ref parsedFile);

            Native.MarshalToArray(parsedFile.items, parsedFile.header.nItemDataArrayLength, out cItemData[] items);
            
            // Deallocate the items array malloced by the C++ runtime
            ItemsData.Free(ref parsedFile);

            DisplayData.ItemsSource = items.AsEnumerable();
        }

        private string OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }

            return null;
        }
    }
}
