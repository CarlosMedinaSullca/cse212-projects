/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(20);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1 
        // Scenario: The user specify 0 as the maximum size of the customer service queue.
        // Expected Result: Queue size equal to 10.

        Console.WriteLine("Test 1");

        var cs = new CustomerService(0);
        Console.WriteLine($"The maximum size is: {cs._maxSize}");

        // Defect(s) Found: No defects

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Enqueue a new customer with the AddNewCustomer method
        // Expected Result: The number of customers in the queue is 1.
        Console.WriteLine("Test 2");

        cs = new CustomerService(4);
        cs.AddNewCustomer();

        Console.WriteLine($"The numbers of customers added is {cs._queue.Count}");

        // Defect(s) Found: No Errors detected

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Adding more customers than the maximum size
        // Expected Result: An error message is displayed
        Console.WriteLine("Test 3");

        var cs1 = new CustomerService(2);
        cs1.AddNewCustomer();
        cs1.AddNewCustomer();
        cs1.AddNewCustomer();

        Console.WriteLine($"The number of customers is {cs1._queue.Count} and the maximum size of customers i {cs1._maxSize}");

        // Defect(s) Found: The condition in the if statement was set to display an error message only when the items in the queue were bigger than the maximum size not equal to.

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Dequeue a customer with the ServeCustomer function
        // Expected Result: Displaying the customer dequeued details
        Console.WriteLine("Test 4");

        var cs2 = new CustomerService(2);
        cs2.AddNewCustomer();
        cs2.AddNewCustomer();

        Console.WriteLine("The item dequeued is:");
        cs2.ServeCustomer();

        // Defect(s) Found: After dequeing the item in the front the function gets the item in the index 0 wich was located in the index 1 before the deque. This is why it is displaying that item and not the item dequeued.
        Console.WriteLine("=================");

        // Test 5
        // Scenario: Try to serve a customer when the queue is empty
        // Expected Result: An error message is displayed
        Console.WriteLine("Test 5");

        cs2.ServeCustomer();
        cs2.ServeCustomer();

        // Defect(s) Found: There is no code to display a message if the queue is empty
        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count > 0)
        {
            var customer = _queue[0];
            Console.WriteLine(customer);
            _queue.RemoveAt(0);
        }
        else { Console.WriteLine("There are no customer to serve"); }
                
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}