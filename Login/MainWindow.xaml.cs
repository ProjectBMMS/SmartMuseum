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
using System.Xml.Linq;

namespace Login
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

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            string path = "registro.xml";
            XDocument xmlDoc = XDocument.Load(path);
            XElement xmlListaPersone = xmlDoc.Element("persone");
            var xmlPersona = xmlListaPersone.Elements("persona");
            foreach (var item in xmlPersona)
            {
                XElement xmlEmail = item.Element("email");
                XElement xmlUsername = item.Element("username");
                XElement xmlPassword = item.Element("password");
                //Persona p = new Persona();
                //p.NomeCompleto = xmlUsername.Value;
                //p.Password = xmlPassword.Value;

                if (xmlUsername.Value == Txt_Username.Text || xmlEmail.Value == Txt_Username.Text && xmlPassword.Value == Txt_Password.Text)
                    MessageBox.Show($"congratulazioni {xmlUsername.Value}, funziona");
            }
        }
    }
}
