namespace MB17Test
{

  using MB17;
  using System.Diagnostics;

  [TestClass]
  public class PriorityQueueTest
  {
    [TestMethod]
    [DataRow(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)]
    public void Enqueue_MultipleValues_Success(params int[] values)
    {
      // arrange
      var queue = new PriorityQueue();

      // act
      foreach (var value in values)
      {
        queue.Enqueue(new QueueEntry(value, $"Todo-{value}"));
      }

      Assert.AreEqual(12, queue.Peek().Priority);
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
      Debug.WriteLine(queue.ToString());

    }
  }
}
