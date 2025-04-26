using InternshipTaskBehavioralDP;

var bookstore = new BookstoreOrderSystem();

bookstore.RegisterCustomer("John Smith", NotificationType.Email);
bookstore.RegisterCustomer("Mary Johnson", NotificationType.Sms);
            
var orderProcessor = bookstore.AddStaffMember("Bob Wilson", DepartmentType.Orders);
bookstore.AddStaffMember("Alice Brown", DepartmentType.Shipping);
            
var order1 = bookstore.PlaceOrder("John Smith", "Design Patterns: Elements of Reusable Object-Oriented Software");
order1.UpdateStatus(OrderStatus.Processing);
            
BookstoreOrderSystem.UnsubscribeFromNotifications(order1, orderProcessor);
            
order1.UpdateStatus(OrderStatus.Shipped);
order1.UpdateStatus(OrderStatus.Delivered);
            
var order2 = bookstore.PlaceOrder("Mary Johnson", "Clean Code: A Handbook of Agile Software Craftsmanship");
order2.UpdateStatus(OrderStatus.Processing);
order2.UpdateStatus(OrderStatus.Cancelled);
            
Console.ReadLine();