using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        public IndexLieux()
        {
            this.InitializeComponent();
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
