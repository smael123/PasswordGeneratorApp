using System.Threading.Tasks;

namespace PasswordGeneratorApp.ViewModels
{
    public interface IPageService
    {
        void DisplayToastError(string message);
        void DisplayRegularToast(string message);
        Task SetClipboardText(string content);
    }
}