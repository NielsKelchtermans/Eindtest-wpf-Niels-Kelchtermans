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
        public ObservableCollection<Kleur> KleurenLijst
        {
            get { return kleurLijst.KleurenLijst; }
            set { kleurLijst.KleurenLijst = value; RaisePropertyChanged("KleurenLijst"); }
        }
        public Kleur SelectedKleur
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
        public List<Model.Bal> Ballen
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
                        int startpunt = pad.LastIndexOf("images/") + 7;
                        int eindpunt = pad.Length - 4;
                        string naam = pad.Substring(startpunt, eindpunt);

                        bestand.WriteLine(pad + " " + naam);
                        bestand.WriteLine(Ballen.Count);

                        foreach (Model.Bal bal in Ballen)
                        {
                            bestand.WriteLine(bal.KleurBal.Naam + " " + bal.XPositie.ToString() + " " + bal.YPositie.ToString());
                        }

                        bestand.WriteLine(WensTekst);
                        bestand.WriteLine(SelectedFont.ToString());
                        bestand.WriteLine(LetterGrootte.ToString());

                    }
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
                        //Achtergrond pad en naam
                        string eersteLijn = bestand.ReadLine();
                        int eindePad = eersteLijn.IndexOf(" ") - 1;
                        Achtergrond = new BitmapImage(new Uri(eersteLijn.Substring(0, eindePad), UriKind.Absolute));
                        //AantalBallen
                        int aantalBallen = Convert.ToInt32(bestand.ReadLine());
                        //Lijst maken van Ballen met kleur en xpos, ypos
                        Ballen = null;

                        for (int i = 0; i < aantalBallen; i++)
                        {
                            string balLijn = bestand.ReadLine();
                            int indexEindeKleur = balLijn.IndexOf(" ") - 1;
                            string balKleur = balLijn.Substring(0, indexEindeKleur);
                            BrushConverter bc = new BrushConverter();
                            SolidColorBrush deKleur = (SolidColorBrush)bc.ConvertFromString(balKleur);
                            Kleur kleurke = new Kleur();
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
            if (LetterGrootte <=40 )
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
            if (LetterGrootte >= 10)
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
        }

        public RelayCommand GeboorteCommand
        {
            get { return new RelayCommand(GeboorteApp); }
        }
        private void GeboorteApp()
        {
            Achtergrond = new BitmapImage(new Uri("pack://application:,,,/images/geboortekaart.jpg", UriKind.Absolute));
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

    }
}
