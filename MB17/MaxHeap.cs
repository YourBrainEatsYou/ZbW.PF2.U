using System.Text;

namespace MB17
{
  public sealed class MaxHeap
  {
    private int[] _heap;

    public int Size { get; private set; }


    public MaxHeap(int capacity = 16) 
    {
      _heap = new int[capacity];
      Size = 0;
    }

    public void Enqueue(int value)
    {
      if (Size == _heap.Length)
      {
        Resize();
      }

      _heap[Size] = value;
      HeapifyUp(Size);
      Size++;
    }

    public int Dequeue()
    {
      if (Size == 0)
      {
        throw new InvalidOperationException("Heap is empty");
      }

      var result = _heap[0];
      Size--;
      _heap[0] = _heap[Size];
      _heap[Size] = 0;
      HeapifyDown(0);
      return result; 
    }

    public int Peek()
    {
      if (Size == 0)
      {
        throw new InvalidOperationException("Heap is empty");
      }

      return _heap[0];
    }

    public bool Validate()
    {
      for (var i = 0; i <= Size / 2 - 1; i++)
      {
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < Size && _heap[i] < _heap[left])
        {
          return false;
        }

        if (left < Size && _heap[i] < _heap[left])
        {
          return false;
        }
      }
      return true;
    }

    private void HeapifyUp(int index)
    { 
      while(index > 0)
      {
        var parentIndex = (index - 1) / 2;

        var doMoveUp = _heap[index] > _heap[parentIndex];

        if(!doMoveUp)
        {
          break;
        }

        Swap(index, parentIndex);

        index = parentIndex;
      }
    }

    private void HeapifyDown(int index)
    {
      while (true)
      {
        var leftChildIndex = 2 * index + 1;
        var rightChildIndex = 2 * index + 2;
        var largestIndex = index;

        if (leftChildIndex < Size && _heap[leftChildIndex] > _heap[largestIndex])
        {
          largestIndex = leftChildIndex;
        }

        if (rightChildIndex < Size && _heap[rightChildIndex] > _heap[largestIndex])
        {
          largestIndex = rightChildIndex;
        }

        if (largestIndex == index)
        {
          break;
        }

        Swap(index, largestIndex);
        index = largestIndex;
      }
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

      for (var i = 0; i < Size; i++)
      {
        sb.Append(_heap[i].ToString()).Append(" ");
      }

      return sb.ToString();
    }

  }
}
