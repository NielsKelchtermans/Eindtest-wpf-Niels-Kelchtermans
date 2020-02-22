using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestWpf.View
{
    /// <summary>
    /// Interaction logic for WenskaartenWindow.xaml
    /// </summary>
    public partial class WenskaartenWindow : Window
    {
        public WenskaartenWindow()
        {
            InitializeComponent();
            ////we gaan al de kleuren in de combobox toevoegen (al de kleuren die de class Colors heeft als props
            //foreach (PropertyInfo propInfo in typeof(Colors).GetProperties())     //Getproperties haalt al de props uit een type. Daarom typeof(colors). Returns een propertyInfo list
            //{
            //    //het kleur object aanmaken
            //    Kleur eenKleur = new Kleur();
            //    //om de prop Borstel een waarde te geven moeten we een type SolidColorBrush hebben die gemaakt wordt van prop van colors
            //    //moet via een BrushConverter
            //    BrushConverter eenBrushConverter = new BrushConverter();
            //    //eenKleur.Borstel = (SolidColorBrush)eenBrushConverter.ConvertFromString(propInfo.Name);
            //    SolidColorBrush deKleur = (SolidColorBrush)eenBrushConverter.ConvertFromString(propInfo.Name);

            //    eenKleur.Naam = propInfo.Name;
            //    eenKleur.Borstel = deKleur;
            //    eenKleur.Hex = deKleur.ToString();              //komt later goed van pas deze tostring van een solidcolorbrush object
            //    eenKleur.Blauw = deKleur.Color.B;               //allemaal via het solidColorBrush object  ...waarom niet via propInfo? heeft niet die props dus via een casting
            //    eenKleur.Groen = deKleur.Color.G;               //bytes
            //    eenKleur.Rood = deKleur.Color.R;

            //    //Inladen in de combobox
            //    comboBoxKleuren.Items.Add(eenKleur);
            //}
            ////lettertypes alfabetisch laden
            //LettertypeComboBox.Items.SortDescriptions.Add(
            //new SortDescription("Source", ListSortDirection.Ascending));
        }
    }
}
