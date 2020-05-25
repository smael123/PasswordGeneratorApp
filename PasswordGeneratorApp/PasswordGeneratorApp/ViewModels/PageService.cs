using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PasswordGeneratorApp.ViewModels
{
    public class PageService : IPageService
    {
        public void DisplayToastError(string message) {
            CrossToastPopUp.Current.ShowToastError(message);
        }
    }
}
