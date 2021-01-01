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

        private void SetupConsole()
        {
            console.ItemsSource = Logger.Logs;
        }

        #region Data Deserialization

        private void OnOpenItemsDataClick(object sender, RoutedEventArgs e)
        {
            string filepath = OpenFile();

            if (filepath is null)
                return;

            cItemDataFile parsedFile = new cItemDataFile();

            if (ItemsData.Deserialize(filepath, ref parsedFile))
            {

                Native.MarshalToArray(parsedFile.items, parsedFile.header.nItemDataArrayLength, out cItemData[] items);

                // Deallocate the items array malloced by the C++ runtime
                ItemsData.Free(ref parsedFile);

                Logger.WriteLine($"Found {parsedFile.header.nItemDataArrayLength} elements");

                DisplayData.ItemsSource = items.AsEnumerable();
                return;
            }
            Logger.WriteLine($"{filepath} is not a valid ItemsData file");
        }


        private void OnOpenItemsMakeClick(object sender, RoutedEventArgs e)
        {
            string filepath = OpenFile();

            if (filepath is null)
                return;

            cItemMakeFile parsedFile = new cItemMakeFile();

            if (ItemMake.Deserialize(filepath, ref parsedFile))
            {

                Native.MarshalToArray(parsedFile.items, parsedFile.header.nElements, out cItemMake[] items);

                Logger.WriteLine($"Found {parsedFile.header.nElements} elements");

                // Deallocate the items array malloced by the C++ runtime
                ItemMake.Free(ref parsedFile);

                DisplayData.ItemsSource = items.AsEnumerable();
                return;
            }
            Logger.WriteLine($"{filepath} is not a valid ItemsMake file");
        }

        #endregion

        #region Windows Events

        private void OnWindowInitialized(object sender, System.EventArgs e)
        {
            SetupConsole();
            Logger.WriteLine("Console initialized succesfully");
        }

        #endregion

        #region Helpers

        private string OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }

            return null;
        }

        #endregion

    }
}
