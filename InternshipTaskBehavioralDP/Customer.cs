namespace InternshipTaskBehavioralDP;

public class Customer(string name, NotificationType preferredNotification) : IObserver
{
    public string Name { get; } = name;
    private NotificationType PreferredNotification { get; } = preferredNotification;

    public void Update(Order order)
    {
        if (Name != order.CustomerName) return;
        var notificationMethod = PreferredNotification == NotificationType.Email ? "Email" : "SMS";
        Console.WriteLine($"{notificationMethod} sent to customer {Name}: Your order #{order.OrderId} for" +
                          $" '{order.BookTitle}' is now {order.Status}");
    }
}