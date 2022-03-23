using Newtonsoft.Json;
using Srez.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Srez
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Sale> Sales { get; set; } = new ObservableCollection<Sale>();
        static HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void btnClick(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "btnGet":
                    string URI = $"https://localhost:7100/api/Sale";
                    Dictionary<string, string> parameters = new Dictionary<string, string> { { "param1", tbDateStart.Text }, { "param2", tbDateEnd.Text } };
                    FormUrlEncodedContent encodedContent = new FormUrlEncodedContent(parameters);
                    HttpResponseMessage response = await client.PostAsync(URI, encodedContent);
                    response.EnsureSuccessStatusCode();
                    string json = response.Content.ReadAsStringAsync().Result;
                    List<Sale> s = JsonConvert.DeserializeObject<List<Sale>>(json);
                    Sales.Clear();
                    s.ForEach(x => Sales.Add(x));
                    break;
                case "btnWordCheck":

                    break;
                case "btnExcelCheck":

                    break;
                case "btnPdfCheck":

                    break;
            }
        }
    }
}