using Microsoft.Maui.Controls;

namespace YourNamespace
{
    public partial class EmailPage : ContentPage
    {
        public EmailPage()
        {
            InitializeComponent();
            BindingContext = new EmailViewModel();
        }
    }
}
