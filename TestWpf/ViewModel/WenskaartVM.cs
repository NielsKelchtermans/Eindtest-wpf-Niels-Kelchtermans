using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging; //bitmapimage
using GalaSoft.MvvmLight; //viewModelBase
using GalaSoft.MvvmLight.Command; //voor RelayCommand
using Microsoft.Win32;
using System.IO;                //voor saveFiledialog etc
using System.Windows;
using System.ComponentModel; //voor cancelEventArghs
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Media;
using System.Reflection;
using System.Collections.ObjectModel;

namespace TestWpf.ViewModel
{
    class WenskaartVM : ViewModelBase
    {
        //aanmaken Model object Wenskaart 
        private Model.Wenskaart wenskaart;
        private KleurLijst kleurLijst;
        private LettertypenVM fontLijst;

        //ctor
        public WenskaartVM(Model.Wenskaart nWenskaart, KleurLijst nkleurLijst, LettertypenVM nfontLijst)
        {
            this.wenskaart = nWenskaart;
            this.kleurLijst = nkleurLijst;
            this.fontLijst = nfontLijst;
        }
        //props

        //fontLijst
        public ObservableCollection<FontFamily> FontLijst
        {
            get { return fontLijst.FontLijst; }
            set { fontLijst.FontLijst = value; RaisePropertyChanged("FontLijst"); }
        }
        public FontFamily SelectedFont
        {
            get { return fontLijst.SelectedFont; }
            set { fontLijst.SelectedFont = value; RaisePropertyChanged("SelectedFont"); }
        }

        //KleurenLijst
        public ObservableCollection<Model.Kleur> KleurenLijst
        {
            get { return kleurLijst.KleurenLijst; }
            set { kleurLijst.KleurenLijst = value; RaisePropertyChanged("KleurenLijst"); }
        }
        public Model.Kleur SelectedKleur
        {
            get { return kleurLijst.SelectedKleur; }
            set { kleurLijst.SelectedKleur = value; RaisePropertyChanged("SelectedKleur"); }
        }

        public BitmapImage Achtergrond
        {
            get
            {
                return wenskaart.Achtergrond;
            }
            set
            {
                wenskaart.Achtergrond = value;
                RaisePropertyChanged("Achtergrond");
            }
        }
        public string AchtergrondNaam
        {
            get
            {
                return wenskaart.AchtergrondNaam;
            }
            set
            {
                wenskaart.AchtergrondNaam = value;
                RaisePropertyChanged("AchtergrondNaam");
            }
        }
        private ObservableCollection<Model.Bal> ballen = new ObservableCollection<Model.Bal>();
        public ObservableCollection<Model.Bal> Ballen
        {
            get
            {
                return wenskaart.Ballen;
            }
            set
            {
                wenskaart.Ballen = value;
                RaisePropertyChanged("Ballen");
            }
        }
        public string WensTekst
        {
            get
            {
                return wenskaart.WensTekst;
            }
            set
            {
                wenskaart.WensTekst = value;
                RaisePropertyChanged("WensTekst");
            }
        }
        //public FontFamily LettertypeVanWens
        //{
        //    get
        //    {
        //        return wenskaart.LettertypeVanWens;
        //    }
        //    set
        //    {
        //        wenskaart.LettertypeVanWens = value;
        //        RaisePropertyChanged("LettertypeVanWens");
        //    }
        //}
        public int LetterGrootte
        {
            get
            {
                return wenskaart.LetterGrootte;
            }
            set
            {
                wenskaart.LetterGrootte = value;
                RaisePropertyChanged("LetterGrootte");
            }
        }
        public string StatusBarTekst
        {
            get
            {
                return wenskaart.StatusBarTekst;
            }
            set
            {
                wenskaart.StatusBarTekst = value;
                RaisePropertyChanged("StatusBarTekst");
            }

        }
        public int TempX
        {
            get
            {
                return wenskaart.TempX;
            }
            set
            {
                wenskaart.TempX = value;

                RaisePropertyChanged("TempX");
                
            }
        }
        public int TempY
        {
            get
            {
                return wenskaart.TempY;
            }
            set
            {
                wenskaart.TempY = value;

                RaisePropertyChanged("TempY");
            }
        }
        //Commands===============================================================================
        //Nieuw Command > Default(lege) Wenskaart en ook alles onzichtbaar!
        public RelayCommand NieuwCommand
        {
            get { return new RelayCommand(NieuweWenskaart); }
        }
        private void NieuweWenskaart()
        {
            Achtergrond = null;
            Ballen = null;
            WensTekst = string.Empty;
            SelectedFont = new FontFamily("Segoe UI");
            LetterGrootte = 20;
            StatusBarTekst = "Nieuw";
        }
        //OpslaanCommand >
        public RelayCommand OpslaanCommand
        {
            get { return new RelayCommand(OpslaanWenskaart); }
        }
        private void OpslaanWenskaart()
        {
            try
            {

                SaveFileDialog dlg = new SaveFileDialog
                {
                    FileName = "wenskaart",
                    DefaultExt = ".wns",
                    Filter = "Wenskaarten|*.wns"
                };
                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        string pad = Achtergrond.UriSource.AbsoluteUri.ToString();


                        bestand.WriteLine(AchtergrondNaam);
                        bestand.WriteLine(pad);

                        bestand.WriteLine(Ballen.Count);

                        foreach (Model.Bal bal in Ballen)
                        {
                            bestand.WriteLine(bal.KleurBal.Naam + " " + bal.XPositie.ToString() + " " + bal.YPositie.ToString());
                        }

                        bestand.WriteLine(WensTekst);
                        bestand.WriteLine(SelectedFont.ToString());
                        bestand.WriteLine(LetterGrootte.ToString());
                        //temp
                        bestand.WriteLine(TempX);

                    }
                    StatusBarTekst = dlg.FileName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Opslaan mislukt: " + ex.Message);
            }

        }
        public RelayCommand OpenenCommand
        {
            get { return new RelayCommand(OpenenWenskaart); }
        }
        private void OpenenWenskaart()
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog
                {

                    Filter = "Wenskaarten|*.wns"
                };
                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        //AchtergrondNaam
                        AchtergrondNaam = bestand.ReadLine();
                        //pad
                        string pad = bestand.ReadLine();
                        Achtergrond = new BitmapImage(new Uri(pad, UriKind.Absolute));
                        //AantalBallen
                        int aantalBallen = Convert.ToInt32(bestand.ReadLine());
                        //Lijst maken van Ballen met kleur en xpos, ypos
                        Ballen = new ObservableCollection<Model.Bal> { };

                        for (int i = 0; i < aantalBallen; i++)
                        {
                            string balLijn = bestand.ReadLine();
                            int indexEindeKleur = balLijn.IndexOf(" ") - 1;
                            string balKleur = balLijn.Substring(0, indexEindeKleur);
                            BrushConverter bc = new BrushConverter();
                            SolidColorBrush deKleur = (SolidColorBrush)bc.ConvertFromString(balKleur);
                            Model.Kleur kleurke = new Model.Kleur();
                            kleurke.Borstel = deKleur;
                            kleurke.Naam = balKleur;
                            //Hex, Rood, Groen, Blauw niet nodig
                            int indexEindeXPos = balLijn.IndexOf(" ", indexEindeKleur + 2) - 1;
                            int xPos = Convert.ToInt32(balLijn.Substring(indexEindeKleur + 2, indexEindeXPos));
                            int yPos = Convert.ToInt32(balLijn.Substring(indexEindeXPos + 2));
                            Model.Bal bal = new Model.Bal(kleurke, xPos, yPos);
                            Ballen.Add(bal);
                        }
                        //wens
                        WensTekst = bestand.ReadLine();
                        //lettertype
                        SelectedFont = new FontFamily(bestand.ReadLine());
                        //lettergrootte
                        LetterGrootte = Convert.ToInt32(bestand.ReadLine());

                    }
                    StatusBarTekst = dlg.FileName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Openen mislukt: " + ex.Message);
            }

        }

        public RelayCommand PrintPreviewCommand
        {
            get { return new RelayCommand(PrintApp); }
        }
        private void PrintApp()
        {
            MessageBox.Show("Hier komt de printpreview");
        }

        public RelayCommand AfsluitenCommand
        {
            get { return new RelayCommand(AfsluitenWenskaart); }
        }
        private void AfsluitenWenskaart()
        {
            Application.Current.MainWindow.Close();
        }

        public RelayCommand MeerCommand
        {
            get { return new RelayCommand(MeerApp); }
        }
        private void MeerApp()
        {
            if (LetterGrootte < 40)
            {
                LetterGrootte += 1;
            }
        }

        public RelayCommand MinderCommand
        {
            get { return new RelayCommand(MinderApp); }
        }
        private void MinderApp()
        {
            if (LetterGrootte > 10)
            {
                LetterGrootte -= 1;
            }
        }

        public RelayCommand KerstCommand
        {
            get { return new RelayCommand(KerstApp); }
        }
        private void KerstApp()
        {
            Achtergrond = new BitmapImage(new Uri("pack://application:,,,/images/kerstkaart.jpg", UriKind.Absolute));
            AchtergrondNaam = "Kerstkaart";
        }

        public RelayCommand GeboorteCommand
        {
            get { return new RelayCommand(GeboorteApp); }
        }
        private void GeboorteApp()
        {
            Achtergrond = new BitmapImage(new Uri("pack://application:,,,/images/geboortekaart.jpg", UriKind.Absolute));
            AchtergrondNaam = "Geboortekaart";
        }
        public RelayCommand<CancelEventArgs> ClosingCommand
        {
            get { return new RelayCommand<CancelEventArgs>(OnWindowClosing); }
        }
        private void OnWindowClosing(CancelEventArgs e)
        {
            if (MessageBox.Show("Afsluiten", "Wilt u het programma afsluiten?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        //Drag/Drop
        //public RelayCommand<MouseEventArgs> MouseMoveCommand
        //{
        //    get { return new RelayCommand<MouseEventArgs>(MouseMouveApp); }

        //}
        //private void MouseMouveApp(MouseEventArgs e)
        //{

        //}
        //Drop
        public RelayCommand<DragEventArgs> DropCommand
        {
            get { return new RelayCommand<DragEventArgs>(DropApp); }
        }
        private void DropApp(DragEventArgs e)
        {
            Point positie = e.GetPosition(Application.Current.MainWindow);
            //int posx = Convert.ToInt32(TempX);
            //int posy = Convert.ToInt32(TempY);
            
            
            int posx = Convert.ToInt32(positie.X);
            int posy = Convert.ToInt32(positie.Y);
            Model.Bal nieuwBal = new Model.Bal(SelectedKleur, posx-20, posy-20);
            Ballen.Add(nieuwBal);
        }
        //private void MaakBal()
        //{
        //    int posX = Convert.ToInt32(TempX);
        //    int posY = Convert.ToInt32(TempY);
        //    Model.Bal nieuwBal = new Model.Bal(SelectedKleur, posX, posY);
        //    Ballen.Add(nieuwBal);
        //}
    }
}
