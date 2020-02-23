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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //test aanmaak van een bal
            //Model.Kleur kleurtje = new Model.Kleur();
            //kleurtje.Borstel = new SolidColorBrush(Colors.Red);
            //kleurtje.Naam = "Red";
            //Model.Bal bal1 = new Model.Bal(kleurtje, 100, 100);
            //Model.Bal bal2 = new Model.Bal(kleurtje, 150, 150);
            //aanmaken wenskaart
            Model.Wenskaart wenskaartStart = new Model.Wenskaart();
            //wenskaartStart.TempX = 250;
            //wenskaartStart.TempY = 250;
            
            //invoegen bal in wenskaart
            //wenskaartStart.Ballen = new System.Collections.ObjectModel.ObservableCollection<Model.Bal> { bal1, bal2 };

            //viewModel wenskaart
            ViewModel.KleurLijst kleurLijst = new ViewModel.KleurLijst();
            ViewModel.LettertypenVM fontLijst = new ViewModel.LettertypenVM();
            ViewModel.WenskaartVM wenskaartVMStart = new ViewModel.WenskaartVM(wenskaartStart, kleurLijst, fontLijst);

            //View
            View.WenskaartenWindow wenskaartenWindow = new View.WenskaartenWindow();
            
           

            //datacontext
            wenskaartenWindow.DataContext = wenskaartVMStart;
            wenskaartenWindow.Show();



            
            
        }
    }
}

