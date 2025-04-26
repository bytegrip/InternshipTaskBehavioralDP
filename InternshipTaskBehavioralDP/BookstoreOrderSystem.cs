namespace InternshipTaskBehavioralDP;

public class BookstoreOrderSystem
    {
        private readonly List<Order> _orders = [];
        private readonly List<Customer> _customers = [];
        private readonly List<StaffMember> _staff = [];
        private int _nextOrderId = 1001;

        public Customer RegisterCustomer(string name, NotificationType preferredNotification)
        {
            var customer = new Customer(name, preferredNotification);
            _customers.Add(customer);
            Console.WriteLine($"Customer {name} registered with {preferredNotification} notifications");
            return customer;
        }

        public StaffMember AddStaffMember(string name, DepartmentType department)
        {
            var staffMember = new StaffMember(name, department);
            _staff.Add(staffMember);
            Console.WriteLine($"Staff member {name} added to {department} department");
            return staffMember;
        }

        public Order PlaceOrder(string customerName, string bookTitle)
        {
            var order = new Order(_nextOrderId++, customerName, bookTitle);
            
            var orderingCustomer = _customers.Find(c => c.Name == customerName);
            if (orderingCustomer != null) order.RegisterObserver(orderingCustomer);
            
            foreach (var staffMember in _staff)
            {
                order.RegisterObserver(staffMember);
            }
            
            _orders.Add(order);
            Console.WriteLine($"\nNew order #{order.OrderId} placed for '{bookTitle}' by {customerName}");
            order.NotifyObservers();
            
            return order;
        }

        public static void UnsubscribeFromNotifications(Order order, IObserver observer)
        {
            order.RemoveObserver(observer);
            switch (observer)
            {
                case Customer customer:
                    Console.WriteLine($"Customer {customer.Name} unsubscribed from order #{order.OrderId} notifications");
                    break;
                case StaffMember member:
                    Console.WriteLine($"Staff member {member.Name} unsubscribed from order #{order.OrderId} notifications");
                    break;
            }
        }
    }