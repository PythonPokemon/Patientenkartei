using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO; // Input/Output


namespace Patientenkartei
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string DIR_PATH = @"C:\Jakob_Derzapf_Dokumente\test\";// konstanter pfad: wichtig am anfang @ zeichen und am ende backslash damit es im letzten Ordner abgelegt wird!
        public const string FILE_EXT = ".txt"; // konstante datei endung, als .txt Format 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        // Methode zum Erstellen einer .txt Datei | Nativ | als Lowlever mit bytes und konvertierung
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string content = textBoxContent.Text;
            string filename = textBoxFileName.Text;
            // wichtig am anfang @ zeichen und am ende backslash damit es im letzten Ordner abgelegt wird!

            using (FileStream fs = File.Create(DIR_PATH + filename + FILE_EXT))   // Datei erstellen Methode | Stream nimmt nur primitive bytes entgegen!
            {
                byte[] contentConvertedToBytes = Encoding.ASCII.GetBytes(content); // soll also bytes bekommen aus der variable 'Content' 
                fs.Write(contentConvertedToBytes, 0, contentConvertedToBytes.Length);

            }

            MessageBox.Show("Datei wurde erfolgreich angelegt."); // Nutzerfeedback | es wird ein POP-UP fenster erzeugt, nachdem erstellen der Datei!
        }

        // Methode zum lesen einer .txt Datei | bequemer weg mit helfer klasse
        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            string filename = textBoxFileName.Text;

            using (FileStream fs = File.OpenRead(DIR_PATH + filename + FILE_EXT))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string content = sr.ReadToEnd();
                    textBoxContent.Text = content;
                }


            }
        }
    }
}