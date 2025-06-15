using MB17.PriorityQueue.MaxHeap;

namespace MB17Test
{

  [TestClass]
  public class MaxHeapTest
  {
    [TestMethod]
    [DataRow(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)]
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
      heap.PrintHeap();

    }
  }
}
