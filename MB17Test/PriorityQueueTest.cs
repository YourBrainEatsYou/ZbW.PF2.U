namespace MB17Test
{

  using MB17;
  using System.Diagnostics;

  [TestClass]
  public class PriorityQueueTest
  {
    [TestMethod]
    [DataRow(12, 1, 10, 3, 4, 11, 6, 7, 8, 2, 10, 5, 0)]
    public void Enqueue_MultipleValues_Success(params int[] values)
    {
      // arrange
      var queue = new PriorityQueue();

      // act
      foreach (var value in values)
      {
        queue.Enqueue(new QueueEntry(value, $"Todo-{value}"));
      }
      var isValid = queue.Validate();
      Assert.IsTrue(isValid);
      Assert.AreEqual(0, queue.Peek().Priority);
      Debug.WriteLine(queue.ToString());
    }

    [TestMethod]
    public void Dequeue_SingleValue_Success()
    {
      // arrange
      var queue = new PriorityQueue();

      queue.Enqueue(new QueueEntry(1, "Notfall"));
      queue.Enqueue(new QueueEntry(2, "Drigend"));
      queue.Enqueue(new QueueEntry(5, "Routine"));

      // act
      var entry = queue.Dequeue();

      Assert.AreEqual("Notfall", entry.Name);
      Assert.AreEqual(1, entry.Priority);
      Debug.WriteLine(queue.ToString());

    }
  }
}
