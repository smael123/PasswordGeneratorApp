using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PasswordGeneratorApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGeneratePassword_Clicked(object sender, EventArgs e)
        {
            //check if number is inputted later
            var passwordGenerator = new PasswordGenerator(int.Parse(entryLength.Text), chkSpecialCharacters.IsChecked, chkNumbers.IsChecked);

            var generatedPassword = passwordGenerator.GeneratePassword();

            lblGeneratedPassword.Text = generatedPassword;
        }
    }
}
