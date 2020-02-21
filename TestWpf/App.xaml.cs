using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Reflection;

namespace TestWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        //    //kleuren inladen in de combobox
        //    foreach (PropertyInfo propInfo in typeof(Colors).GetProperties())     
        //    {
        //        //het kleur object aanmaken
        //        Kleur eenKleur = new Kleur();
                
        //        BrushConverter eenBrushConverter = new BrushConverter();
                
        //        SolidColorBrush deKleur = (SolidColorBrush)eenBrushConverter.ConvertFromString(propInfo.Name);

        //        eenKleur.Naam = propInfo.Name;
        //        eenKleur.Borstel = deKleur;
        //        eenKleur.Hex = deKleur.ToString();              //komt later goed van pas deze tostring van een solidcolorbrush object
        //        eenKleur.Blauw = deKleur.Color.B;               //allemaal via het solidColorBrush object  ...waarom niet via propInfo? heeft niet die props dus via een casting
        //        eenKleur.Groen = deKleur.Color.G;               //bytes
        //        eenKleur.Rood = deKleur.Color.R;

        //          //Inladen in de combobox
        //        ComboBoxKleuren.Items.Add(eenKleur);
                

        //        ////lettertypes alfabetisch laden
        //        ////LettertypeComboBox.Items.SortDescriptions.Add(
        //        ////new SortDescription("Source", ListSortDirection.Ascending));

        //    }


        //}
    }
}

