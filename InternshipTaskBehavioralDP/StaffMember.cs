namespace InternshipTaskBehavioralDP;

public class StaffMember(string name, DepartmentType departmentType) : IObserver
{
    public string Name { get; } = name;
    private DepartmentType DepartmentType { get; } = departmentType;

    public void Update(Order order)
    {
        if ((DepartmentType == DepartmentType.Orders && order.Status == OrderStatus.Placed) ||
            (DepartmentType == DepartmentType.Shipping && order.Status == OrderStatus.Processing))
        {
            Console.WriteLine($"Staff notification to {Name} ({DepartmentType}): Order #{order.OrderId} is {order.Status} and requires your attention");
        }
    }
}
