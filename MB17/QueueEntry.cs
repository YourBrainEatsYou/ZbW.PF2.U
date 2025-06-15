
namespace MB17
{
  public sealed class QueueEntry
  {
    public int Priority { get; set; }

    public string Name { get; set; }

    public QueueEntry(int priority, string name)
    {
      Priority = priority;
      Name = name;
    }
  }
}
