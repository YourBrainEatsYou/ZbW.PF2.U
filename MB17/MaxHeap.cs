using System.Text;

namespace MB17
{
  public sealed class MaxHeap
  {
    private int[] _heap;

    public int Size { get; private set; }

    private int Capacity { get; set; }

    public MaxHeap(int capacity = 16) 
    {
      Capacity = capacity;
      _heap = new int[capacity];
      Size = 0;
    }

    public void Enqueue(int value)
    {

    }

    public int Dequeue()
    {
      return _heap[0];
    }

    public int Peek()
    {
      if (Size == 0)
      {
        throw new InvalidOperationException("Heap is empty");
      }

      return _heap[0];
    }

    private void HeapifyUp(int index)
    { 
    }

    private void HeapifyDown(int index)
    {

    }

    private void Swap(int index, int parentIndex)
    {
      int temp = _heap[index];
      _heap[index] = _heap[parentIndex];
      _heap[parentIndex] = temp;
    }

    private void Resize()
    {
      Array.Resize(ref _heap, _heap.Length * 2);
    }

    public override string ToString()
    {
      if (Size == 0)
      {
        return string.Empty;
      }

      var sb = new StringBuilder();

      foreach(int i in _heap)
      {
        sb.Append(i.ToString()).Append(" ");
      }

      return sb.ToString();
    }

  }
}
