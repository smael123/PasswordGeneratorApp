using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PasswordGeneratorApp.ViewModels
{
    public class PageService : IPageService
    {
        public void DisplayToastError(string message) {
            CrossToastPopUp.Current.ShowToastError(message);
        }

        public void DisplayRegularToast(string message)
        {
            CrossToastPopUp.Current.ShowToastMessage(message);
        }

        public Task SetClipboardText(string content) {
            return Clipboard.SetTextAsync(content);
        }
    }
}
