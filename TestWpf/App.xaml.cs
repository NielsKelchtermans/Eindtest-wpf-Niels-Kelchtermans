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
            //aanmaken wenskaart
            Model.Wenskaart wenskaartStart = new Model.Wenskaart();
            //viewModel wenskaart
            ViewModel.KleurLijst kleurLijst = new ViewModel.KleurLijst();
            ViewModel.LettertypenVM fontLijst = new ViewModel.LettertypenVM();
            ViewModel.WenskaartVM wenskaartVMStart = new ViewModel.WenskaartVM(wenskaartStart, kleurLijst, fontLijst);
            //View
            View.WenskaartenWindow wenskaartenWindow = new View.WenskaartenWindow();
            
           

            //datacontext
            wenskaartenWindow.DataContext = wenskaartVMStart;
            wenskaartenWindow.Show();



            
            ////lettertypes alfabetisch laden
            //LettertypeComboBox.Items.SortDescriptions.Add(
            //new SortDescription("Source", ListSortDirection.Ascending));
        }
    }
}

