using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PasswordGeneratorApp.ViewModels
{
    public class PasswordGeneratorViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;

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
        public ICommand CopyClipboardCommand { get; private set; }

        public PasswordGeneratorViewModel() {
            _pageService = new PageService();
            GeneratePasswordCommand = new Command(OnGenerateClick);
            CopyClipboardCommand = new Command(async () => await OnClipboardClick());
        }

        public async Task OnClipboardClick() {
            await _pageService.SetClipboardText(GeneratedPassword);

            _pageService.DisplayRegularToast("Copied to clipboard.");
        }

        public void OnGenerateClick() {
            if (Length <= 0) {
                _pageService.DisplayToastError("Please enter a length greater than 0.");
            }

            var passwordGenerator = new PasswordGenerator(Length, IncludeSpecialCharacters, IncludeNumbers);

            var generatedPassword = passwordGenerator.GeneratePassword();

            GeneratedPassword = generatedPassword;
        }
    }
}
