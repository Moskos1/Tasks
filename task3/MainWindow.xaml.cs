using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace wpfForms
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OutputGrid();
        }
        public void OutputGrid()
        {
            // Чтение файла
            string jsonFilePath = "C:\\Users\\kvere\\source\\repos\\TsGmEnrg\\TsGmEnrg\\outages.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Десериализация JSON
            OutageData outageData = JsonConvert.DeserializeObject<OutageData>(jsonContent);

            grid.ItemsSource = outageData.AffectedAreas.Select(c => new
            {
                OutageStart = outageData.OutageStart,
                OutageEnd = outageData.OutageEnd,
                AffectedAreasName = c.AreaName,
                AffectedAreasCustomers = c.AffectedCustomers,
                AffectedAreasReason = c.Reason

            }).ToList(); ;
        }

    }
}
