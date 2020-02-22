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
            
        }
        private Ellipse sleepEllipse = new Ellipse();
        private void Ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            sleepEllipse = (Ellipse)sender;
            if ((e.LeftButton == MouseButtonState.Pressed) && (sleepEllipse.Fill != null))
            {
                DataObject sleepKleur = new DataObject("deKleur", sleepEllipse.Fill);
                DragDrop.DoDragDrop(sleepEllipse, sleepKleur, DragDropEffects.Move);
            }

        }
        private Ellipse bal = new Ellipse();
        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("deKleur"))
            {
                Brush gesleepteKleur = (Brush)e.Data.GetData("deKleur");
                Canvas canvasje = (Canvas)sender;
                bal.Fill = gesleepteKleur;
                Point punt = e.GetPosition(CanvasPrikker);
                Canvas.SetLeft(bal, punt.X-20);
                Canvas.SetTop(bal, punt.Y-20);
                //int xpos = Convert.ToInt32(punt.X) - 20;
                //int ypos = Convert.ToInt32(punt.Y) - 20;
                //ViewModel.WenskaartVM.ToevoegenBal(xpos, ypos);
                CanvasPrikker.Children.Add(bal);
            }
        }

       
    }
}
