using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Xml.Linq;

namespace Museo
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Carica_Click(object sender, RoutedEventArgs e)
        {
            Lst_ListaOpere.Items.Clear();
            Mtd_CaricaDati();
        }

        private void Mtd_CaricaDati()
        {
            List<string> elements = new List<string>();
            string path = @"lista_opere.xml";
            XDocument xmlDoc = XDocument.Load(path);
            XElement xmlListaOpere = xmlDoc.Element("opere");
            var xmlOpera = xmlListaOpere.Elements("opera");
            foreach (var item in xmlOpera)
            {
                XElement xmlNome = item.Element("nome");
                XElement xmlAutore = item.Element("autore");
                XElement xmlAnno = item.Element("anno");
                Opera o = new Opera();
                o.Nome = xmlNome.Value;
                o.Autore = xmlAutore.Value;
                o.Anno = xmlAnno.Value;
                elements.Add(Convert.ToString(o));
            }

            if (Opt_OperaCrescente.IsChecked == true)
            {
                elements.Sort();
            }
            else if (Opt_OperaDecrescente.IsChecked == true)
            {
                elements.Sort();
                elements.Reverse();
            }
            else if (Opt_AutoreCrescente.IsChecked == true)
            {
                //List<string> autoreSort = new List<string>();
                //foreach (var item in xmlOpera)
                //{
                //    XElement xmlAutore = item.Element("autore");
                //    Opera o = new Opera();
                //    o.Autore = xmlAutore.Value;
                //    autoreSort.Add(Convert.ToString(o));
                //}
                //autoreSort.Sort();
                //elements.OrderBy(x => x.Contains(autoreSort[]));
            }
            else
            {

            }


            for (int i = 0; i < elements.Count; i++)
                Dispatcher.Invoke(() => Lst_ListaOpere.Items.Add(elements[i]));
        }

        private void Btn_ApriBrowser_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(Mtd_ApriBrowserLink);
        }

        private void Mtd_ApriBrowserLink()
        {
            if (Convert.ToString(Lst_ListaOpere.SelectedItem) != "")
            {
                string path = @"lista_opere.xml";
                XDocument xmlDoc = XDocument.Load(path);
                XElement xmlListaOpere = xmlDoc.Element("opere");
                var xmlOpera = xmlListaOpere.Elements("opera");
                foreach (var item in xmlOpera)
                {
                    XElement xmlNome = item.Element("nome");
                    XElement xmlLink = item.Element("link");
                    Opera o = new Opera();
                    o.Nome = xmlNome.Value;
                    o.Link = xmlLink.Value;
                    if (Convert.ToString(Lst_ListaOpere.SelectedItem).Contains(o.Nome))
                    {
                        System.Diagnostics.Process.Start(o.Link);
                    }
                }

            }
            else
            {
                MessageBox.Show("Seleziona un elemento");
            }
        }
    }
}
