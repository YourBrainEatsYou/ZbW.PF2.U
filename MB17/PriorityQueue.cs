
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

    }

    public QueueEntry Dequeue()
    {
      return _entries[0];
    }

    public QueueEntry Peek()
    {
      if (Count == 0)
      {
        throw new InvalidOperationException("Priority queue is empty");
      }

      return _entries[0];
    }

    private void HeapifyUp(int index)
    {
    }

    private void HeapifyDown(int index)
    {

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

      foreach (var entry in _entries)
      {
        sb.Append(entry.ToString()).Append(" ");
      }

      return sb.ToString();
    }
  }
}
