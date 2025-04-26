namespace InternshipTaskBehavioralDP;

public class Order(int orderId, string customerName, string bookTitle) : ISubject
{
    private readonly List<IObserver> _observers = [];
    public int OrderId { get; } = orderId;
    public string CustomerName { get; private set; } = customerName;
    public string BookTitle { get; private set; } = bookTitle;
    public OrderStatus Status { get; private set; } = OrderStatus.Placed;

    public void UpdateStatus(OrderStatus newStatus)
    {
        Status = newStatus;
        Console.WriteLine($"\nOrder #{OrderId} status updated to: {Status}");
        NotifyObservers();
    }

    public void RegisterObserver(IObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }
}