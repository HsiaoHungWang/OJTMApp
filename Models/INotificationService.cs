namespace OJTMApp.Models
{
    public interface INotificationService
    {
        string SendMessage(string to, string message);
    }
}
