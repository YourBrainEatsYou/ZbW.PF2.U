
using System.Drawing;
using System.Text;

namespace MB17
{
  /// <summary>
  /// is internally a min-heap
  /// </summary>
  public sealed class PriorityQueue
  {
    private QueueEntry[] _entries;

    public int Count { get; private set; } 

    public PriorityQueue(int capacity = 16) 
    {
      _entries = new QueueEntry[capacity];
      Count = 0;
    }

    public void Enqueue(QueueEntry value)
    {
      if (Count == _entries.Length)
      {
        Resize();
      }

      _entries[Count] = value;
      HeapifyUp(Count);
      Count++;
    }

    public QueueEntry Dequeue()
    {
      if (Count == 0)
      {
        throw new InvalidOperationException("PriorityQueue is empty.");
      }

      var result = _entries[0];
      Count--;
      _entries[0] = _entries[Count];
      HeapifyDown(0);
      return result;
    }

    public QueueEntry Peek()
    {
      if (Count == 0)
      {
        throw new InvalidOperationException("Priority queue is empty");
      }

      return _entries[0];
    }

    public bool Validate()
    {
      for (var i = 0; i <= Count / 2 - 1; i++)
      {
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < Count && _entries[i].Priority > _entries[left].Priority)
        {
          return false;
        }

        if (left < Count && _entries[i].Priority > _entries[left].Priority)
        {
          return false;
        }
      }
      return true;
    }

    private void HeapifyUp(int index)
    {
      while (index > 0)
      {
        var parentIndex = (index - 1) / 2;

        var doMoveUp = _entries[index].Priority < _entries[parentIndex].Priority;

        if (!doMoveUp)
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

        if (leftChildIndex < Count && 
            _entries[leftChildIndex].Priority < _entries[largestIndex].Priority)
        {
          largestIndex = leftChildIndex;
        }

        if (rightChildIndex < Count && 
          _entries[rightChildIndex].Priority < _entries[largestIndex].Priority)
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
      QueueEntry temp = _entries[index];
      _entries[index] = _entries[parentIndex];
      _entries[parentIndex] = temp;
    }

    private void Resize()
    {
      Array.Resize(ref _entries, _entries.Length * 2);
    }

    public override string ToString()
    {
      if(Count == 0)
      {
        return string.Empty;
      }

      var sb = new StringBuilder();

      for(var i = 0; i < Count; i++)
      {
        //sb.Append($"[{_entries[i].Priority}-{_entries[i].Name}]").Append(" ");
        sb.Append($"{_entries[i].Priority}").Append(" ");
      }

      return sb.ToString();
    }
  }
}
