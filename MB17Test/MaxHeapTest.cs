namespace MB17Test
{
  using MB17;
  using System.Diagnostics;

  [TestClass]
  public class MaxHeapTest
  {
    [TestMethod]
    [DataRow(9, 4, 3, 8, 10, 2, 5)]
    public void Enqueue_MultipleValues_Success(params int[] values)
    {
      // arrange
      var heap = new MaxHeap(16);

      // act
      foreach (var value in values)
      {
        heap.Enqueue(value);
      }

      // assert
      Assert.AreEqual(12, heap.Peek());
      Debug.WriteLine(heap.ToString());

    }

    [TestMethod]
    [DataRow(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)]
    public void Dequeue_SingleValue_Success(params int[] values)
    {
      // arrange
      var heap = new MaxHeap();

      // act
      var element = heap.Dequeue();


      // assert
      Assert.AreEqual(element, 12);
      Debug.WriteLine(heap.ToString());

    }
  }
}
