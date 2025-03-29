namespace OJTMApp.Models
{
    public class SMSNotificationService : INotificationService
    {
        public string SendMessage(string to, string message)
        {
            return($"簡訊寄給 {to} 內容是: {message}");
        }
    }
}
