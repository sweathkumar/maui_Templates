using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

public class EmailViewModel : INotifyPropertyChanged
{
    private string _email;
    private bool _isUpdating;

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    public bool IsUpdating
    {
        get => _isUpdating;
        set
        {
            _isUpdating = value;
            OnPropertyChanged(nameof(IsUpdating));
        }
    }

    public ICommand UpdateEmailCommand { get; }

    public EmailViewModel()
    {
        UpdateEmailCommand = new RelayCommand(async () => await UpdateEmailAsync());
        LoadEmail(); // Load the existing email when the ViewModel is instantiated.
    }

    private void LoadEmail()
    {
        // Load the email from your data source (e.g., application settings, database, etc.)
        Email = Application.Current.Properties.ContainsKey("UserEmail")
            ? Application.Current.Properties["UserEmail"].ToString()
            : string.Empty;
    }

    private async Task UpdateEmailAsync()
    {
        IsUpdating = true;

        // Simulate a delay for the update process
        await Task.Delay(1000);

        // Here you would typically call a service to update the email in the backend.
        // For this example, we're just saving it to application properties.
        Application.Current.Properties["UserEmail"] = Email;

        // Optionally, show a success message
        await Application.Current.MainPage.DisplayAlert("Success", "Email updated successfully.", "OK");

        IsUpdating = false;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
