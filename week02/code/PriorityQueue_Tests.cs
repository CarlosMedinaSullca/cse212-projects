using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following items with its values and priorities: 300 (1), 2500 (3), 1100 (2) and
    // run until the queue is empty
    // Expected Result: 2500, 1100 300
    // Defect(s) Found: The Dequeue method does not have the logic to remove the item from the queue. 
    // The condition in the for loop stops the loop when the queue has two items.It prevents to find the next item with the highest priority between the last two items.
    public void TestPriorityQueue_1()
    {
        var item1 = new PriorityItem("300", 1);
        var item2 = new PriorityItem("2500", 3);
        var item3 = new PriorityItem("1100", 2);

        PriorityItem[] expectedResult = [item2, item3, item1];

        var items = new PriorityQueue();
        items.Enqueue(item1.Value, item1.Priority);
        items.Enqueue(item2.Value, item2.Priority);
        items.Enqueue(item3.Value, item3.Priority);

        int i = 0;

        while (items.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now");
            }

            var item = items.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following items with its values and priorities: 300 (1), 2500 (3), 1100 (2), 800 (1), 1600 (2), 2100(3) and
    // run until the queue is empty 
    // Expected Result: 2500, 2100, 1100, 1600, 300, 800
    // Defect(s) Found: The conditional if statement, inside the for loop to find the index of the item with the highest priority, prioritize the last item with the highest priority by replacing the first item if the current item's priority is highest or equal to it. It should replace it only if the current item has highest than the previous item. 
    public void TestPriorityQueue_2()
    {
        var item1 = new PriorityItem("300", 1);
        var item2 = new PriorityItem("2500", 3);
        var item3 = new PriorityItem("1100", 2);
        var item4 = new PriorityItem("800", 1);
        var item5 = new PriorityItem("1600", 2);
        var item6 = new PriorityItem("2100", 3);

        PriorityItem[] expectedResult = [item2, item6, item3, item5, item1, item4];

        var items = new PriorityQueue();
        items.Enqueue(item1.Value, item1.Priority);
        items.Enqueue(item2.Value, item2.Priority);
        items.Enqueue(item3.Value, item3.Priority);
        items.Enqueue(item4.Value, item4.Priority);
        items.Enqueue(item5.Value, item5.Priority);
        items.Enqueue(item6.Value, item6.Priority);

        int i = 0;

        while (items.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now");
            }

            var item = items.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
            i++;
        }
    }

        [TestMethod]
    // Scenario: Try to dequeue the next item from an empty queue
    // Expected Result: An error exception shall be thrown. This exception should be an InvalidOperationException with a message of "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        var items = new PriorityQueue();

        try
        {
            items.Dequeue();
            Assert.Fail("Exception should have been thrown");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                e.GetType(), e.Message)
            );
        }
    }

    // Add more test cases as needed below.
}