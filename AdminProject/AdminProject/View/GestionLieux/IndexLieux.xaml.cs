using AdminProject.Model;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AdminProject.View.GestionLieux
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IndexLieux : Page
    {
        public bool testnom, testadresse , testville, testcodepostal , testpays ;
        private MobileServiceCollection<Lieu, Lieu> lieux;//instance de l'objet lieu
        private IMobileServiceTable<Lieu> lieutable = App.MobileService.GetTable<Lieu>();//declaration de la table de type lieu
        Lieu selectedlieu = new Lieu();//???

        public IndexLieux()
        {
            this.InitializeComponent();
            affiche();
        }
        private async void affiche()
        {
            try
            {
                lieux = await lieutable.ToCollectionAsync();
                AfficheLieux.ItemsSource = lieux;
            }
            catch (Exception ex)
            {

                MessageDialog msg = new MessageDialog("erreur de connexion");
                msg.ShowAsync();
            }


        }

        private void txtville_LostFocus(object sender, RoutedEventArgs e)
        {
            //tester le contenu de txtville
            if (txtville.Text.All(Char.IsLetter))
            {
                txtville.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtville.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testville = true;
            }
            else
            {
                txtville.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtville.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testville = false;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // specifier une location connue.
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 35.825603, Longitude = 10.608395 };
            Geopoint cityCenter = new Geopoint(cityPosition);

            //Définir l'emplacement de la carte.
            MapControl1.Center = cityCenter;
            MapControl1.ZoomLevel = 12;
            MapControl1.LandmarksVisible = true;
        }

        private void btnajout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Lieu lieu = new Lieu { nom = txtnom.Text, adresse = txtadresse.Text, codepostal = int.Parse(txtcodepostal.Text), ville = txtville.Text, pays = txtpays.Text, longitude = Double.Parse(txtlong.Text), latitude = Double.Parse(txtlat.Text) };
                lieutable.InsertAsync(lieu);
                MessageDialog msg = new MessageDialog("ajout avec succes");
                msg.ShowAsync();
                Frame.Navigate(typeof(IndexLieux));
            }
            catch (Exception)
            {
                MessageDialog msg = new MessageDialog("erreur ");
                msg.ShowAsync();
            }
        }

        private void btnmodifier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Lieu lieu = new Lieu {Id=selectedlieu.Id, nom = txtnom.Text, adresse = txtadresse.Text, codepostal = int.Parse(txtcodepostal.Text), ville = txtville.Text, pays = txtpays.Text, longitude = Double.Parse(txtlong.Text), latitude = Double.Parse(txtlat.Text) };
                lieutable.UpdateAsync(lieu);
                MessageDialog msg = new MessageDialog("modifié avec succes");
                msg.ShowAsync();
                Frame.Navigate(typeof(IndexLieux));
            }
            catch (Exception)
            {
                MessageDialog msg = new MessageDialog("erreur");
                msg.ShowAsync();
            }
            
        }

        private void btnsupp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lieutable.DeleteAsync(selectedlieu);
                MessageDialog msg = new MessageDialog("suprimé avec succes");
                msg.ShowAsync();
                Frame.Navigate(typeof(IndexLieux));
            }
            catch (Exception)
            {
                MessageDialog msg = new MessageDialog("erreur");
                msg.ShowAsync();
            }
        }

        private void AfficheLieux_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedlieu = AfficheLieux.SelectedItem as Lieu;
            txtnom.Text = selectedlieu.nom;
            txtadresse.Text = selectedlieu.adresse;
            txtville.Text = selectedlieu.ville;
            txtcodepostal.Text = selectedlieu.codepostal.ToString();
            txtpays.Text = selectedlieu.pays;
            txtlong.Text = selectedlieu.longitude.ToString();
            txtlat.Text = selectedlieu.latitude.ToString();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            // specifier une location connue.
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = Double.Parse(txtlat.Text), Longitude = Double.Parse(txtlong.Text) };
            Geopoint cityCenter = new Geopoint(cityPosition);

            //Définir l'emplacement de la carte.
            MapControl1.Center = cityCenter;
            MapControl1.ZoomLevel = 12;
            MapControl1.LandmarksVisible = true;
        }

        private void txtpays_LostFocus(object sender, RoutedEventArgs e)
        {
            //tester le contenu de txtpays
            if (txtpays.Text.All(Char.IsLetter))
            {
                txtpays.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtpays.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testpays = true;
            }
            else
            {
                txtpays.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtpays.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testpays = false;
            }

        }

        private void txtadresse_LostFocus(object sender, RoutedEventArgs e)
        {
            //tester le contenu de txtadresse
            if (txtadresse.Text.All(Char.IsLetter))
            {
                txtadresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtadresse.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testadresse = true;
            }
            else
            {
                txtadresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtadresse.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testadresse = false;
            }

        }

        private void txtnom_LostFocus(object sender, RoutedEventArgs e)
        {
            //tester le contenu de txtnom
            if (txtnom.Text.All(Char.IsLetter))
            {
                txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtnom.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testnom = true;
            }
            else
            {
                txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtnom.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testnom = false;
            }
        }

        private void txtcodepostal_LostFocus(object sender, RoutedEventArgs e)
        {
            //tester le contenu de txtcodepostal
            if (txtcodepostal.Text.All(Char.IsNumber))
            {
                txtcodepostal.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtcodepostal.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testcodepostal = true;
            }
            else
            {
                txtcodepostal.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtcodepostal.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testcodepostal = false;
            }
        }

    }
}
