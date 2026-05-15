using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue 3 items with different priorities: "low"(1), "high"(3), "mid"(2)
    // Expected Result: "high" is dequeued first, then "mid", then "low"
    // Defect(s) Found: Dequeue never removes the item from the queue (missing RemoveAt).
    //                  Also, the loop uses Count-1 so it skips the last element.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 3);
        priorityQueue.Enqueue("mid", 2);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("mid", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue 3 items where two share the highest priority: "first"(5), "second"(5), "third"(1)
    // Expected Result: "first" is dequeued before "second" (FIFO tiebreaker)
    // Defect(s) Found: The ">=" condition in the loop causes the last high-priority item
    //                  to win instead of the first one, breaking FIFO order.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("second", 5);
        priorityQueue.Enqueue("third", 1);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue 3 items where the highest priority is the last one added: "a"(1), "b"(2), "c"(5)
    // Expected Result: "c" is dequeued first (it has the highest priority and is at the end)
    // Defect(s) Found: The loop condition "index < _queue.Count - 1" skips the last element,
    //                  so "c" is never considered as the highest priority.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 1);
        priorityQueue.Enqueue("b", 2);
        priorityQueue.Enqueue("c", 5);

        Assert.AreEqual("c", priorityQueue.Dequeue());
    }
}