using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add 3 items with different priorities and remove them in order.
    // Expected Result: Dequeue returns items in order of priority: High (5), Medium (3), Low (1)
    // Defect(s) Found: Original Dequeue loop skipped last item, so highest priority might be missed.
    public void TestPriorityQueue_DescendingPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 3);
        pq.Enqueue("High", 5);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items with the same priority.
    // Expected Result: Items should be dequeued in the order they were added (FIFO for same priority)
    // Defect(s) Found: Works correctly.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 2);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from empty queue.
    // Expected Result: Should throw InvalidOperationException.
    // Defect(s) Found: Correctly throws exception.
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Add elements with negative priorities.
    // Expected Result: Still works – higher number is still considered higher priority.
    // Defect(s) Found: Negative priorities are allowed and work logically.
    public void TestPriorityQueue_NegativePriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", -5);
        pq.Enqueue("Medium", 0);
        pq.Enqueue("High", 10);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Add just one item, then remove it.
    // Expected Result: Should dequeue that item.
    // Defect(s) Found: Works as expected.
    public void TestPriorityQueue_SingleItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("OnlyItem", 100);

        Assert.AreEqual("OnlyItem", pq.Dequeue());
    }
}