namespace OJTMApp.Models
{
    public class EmailNotificationService : INotificationService
    {
        public string SendMessage(string to, string message)
        {
            //todo 寄電子郵件
            return ($"電子郵件寄給 {to} 內容是: {message}");
        }
    }
}
