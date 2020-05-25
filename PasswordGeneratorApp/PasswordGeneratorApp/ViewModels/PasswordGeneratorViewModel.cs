using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PasswordGeneratorApp.ViewModels
{
    public class PasswordGeneratorViewModel : BaseViewModel
    {
        private string _generatedPassword;
        public string GeneratedPassword {
            get => _generatedPassword;
            set => SetValue(ref _generatedPassword, value);
        }
        
        private int _length;
        public int Length
        {
            get => _length;
            set => SetValue(ref _length, value);
        }

        private bool _includeSpecialCharacters;
        public bool IncludeSpecialCharacters
        {
            get => _includeSpecialCharacters;
            set => SetValue(ref _includeSpecialCharacters, value);
        }

        private bool _includeNumbers;
        public bool IncludeNumbers
        {
            get => _includeNumbers;
            set => SetValue(ref _includeNumbers, value);
        }

        public ICommand GeneratePasswordCommand { get; private set; }

        public PasswordGeneratorViewModel() {
            GeneratePasswordCommand = new Command(OnGenerateClick);
        }

        public void OnGenerateClick() {
            var passwordGenerator = new PasswordGenerator(Length, IncludeSpecialCharacters, IncludeNumbers);

            var generatedPassword = passwordGenerator.GeneratePassword();

            GeneratedPassword = generatedPassword;
        }
    }
}
