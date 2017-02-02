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

namespace AdminProject.View.GestionAbonnee
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IndexAbonnee : Page
    {
        private bool testcmdp,testemail,testnom,testprenom;
        private bool testmdp;
        private bool testdate;

        public IndexAbonnee()
        {
            this.InitializeComponent();
        }

        private void txtdate_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            //tester le contenu de date
            if (txtdate.Date.Year < DateTime.Now.Year - 14)
            {
                txtdate.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtdate.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testdate = true;
            }
            else
            {
                txtdate.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtdate.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testdate = false;
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

        private void txtprenom_LostFocus(object sender, RoutedEventArgs e)
        {
            //tester le contenu de txtprenom
            if (txtprenom.Text.All(Char.IsLetter))
            {
                txtprenom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtprenom.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testnom = true;
            }
            else
            {
                txtprenom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtprenom.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testnom = false;
            }
        }

        
    

        private void txtemail_LostFocus(object sender, RoutedEventArgs e)
        {
                //tester le contenu de email
                if (txtemail.Text.Contains("@") == true && txtemail.Text.Contains(".") == true)
                {
                    txtemail.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                    txtemail.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                    testemail = true;
                }
                else
                {
                    txtemail.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                    txtemail.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    testemail = false;
                }
            
        }
        

        private void mdp_LostFocus(object sender, RoutedEventArgs e)
        {

            //tester le contenu de mot de passe
            if (txtmdp.Password.Length >= 8)
            {
                txtmdp.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtmdp.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testmdp = true;
            }
            else
            {
                txtmdp.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtmdp.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testmdp = false;
            }
        }

        private void txtcmdp_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtcmdp.Password.Equals(txtmdp.Password) == true)
            {
                txtcmdp.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtcmdp.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testcmdp = true;
            }
            else
            {
                txtcmdp.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtcmdp.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testcmdp = false;
            }
        }
    }
    
    
}
