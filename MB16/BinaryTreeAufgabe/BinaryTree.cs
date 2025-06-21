using System.Text;

namespace MB16.BinaryTreeAufgabe
{
  public class BinaryTree<T> where T : IComparable<T>
  {

    private Node<T> root;

    public int Count { get; private set; }

    public TraverseModeEnum TraverseMode { get; set; }

    public DisplayModeEnum DisplayMode { get; set; }

    public BinaryTree()
    {
      TraverseMode = TraverseModeEnum.PreOrder;
      DisplayMode = DisplayModeEnum.Linear;
    }

    /// <summary>
    /// Adds the provided item to the binary tree.
    /// </summary>
    /// <param name="item"></param>
    public void Add(T item)
    {
      // Case 1: The tree is empty - allocate the head
      if (root == null)
      {
        root = new Node<T>() { Item = item };
      }
      // Case 2: The tree is not empty so find the right location to insert
      else
      {
        AddTo(root, item);
      }

      Count++;
    }

    public void AddRange(T[] items)
    {
      foreach (var item in items)
        Add(item);
    }


    public void Balance()
    {
      if(root == null)
      {
        return;
      }

      var data = InOrder(root).ToList();

      root = BuildBalanced(data, 0, data.Count - 1)!;

    }

    private IEnumerable<T> InOrder<T>(Node<T>? node) where T : IComparable<T>
    {
      if (node == null)
      {
        yield break;
      }

      foreach (var v in InOrder(node.Left))
      {
        yield return v;       // 1) left
      }

      yield return node.Item; // 2) root
      foreach (var v in InOrder(node.Right))
      {
        yield return v;       // 3) right
      }
    }


    private Node<T>? BuildBalanced(IReadOnlyList<T> arr, int lo, int hi)
    {
      if (lo > hi)
      {
        return null;
      }

      var mid = lo + (hi - lo) / 2;

      var node = new Node<T>()
      {
        Item = arr[mid],
        Left = BuildBalanced(arr, lo, mid - 1)!,
        Right = BuildBalanced(arr, mid + 1, hi)!
      };

      return node;
    }

    // Recursive add algorithm
    private void AddTo(Node<T> node, T item)
    {
      // Case 1: item is less than the current node value
      if (item.CompareTo(node.Item) < 0)
      {
        // if there is no left child make this the new left
        if (node.Left == null)
        {
          node.Left = new Node<T>() { Item = item };
        }
        else
        {
          // else add it to the left node
          AddTo(node.Left, item);
        }
      }
      // Case 2: item is equal to or greater than the current value
      else
      {
        // If there is no right, add it to the right
        if (node.Right == null)
        {
          node.Right = new Node<T>() { Item = item };
        }
        else
        {
          // else add it to the right node
          AddTo(node.Right, item);
        }
      }
    }

    /// <summary>
    /// Determines if the specified item exists in the binary tree.
    /// </summary>
    /// <param name="item">The item to search for.</param>
    /// <returns>True if the tree contains the item, false otherwise</returns>
    public bool Contains(T item)
    {
      //var node = root;

      //while (node != null) {
      //    var c = node.Item.CompareTo(item);

      //    if (c == 0) {
      //        return true;
      //    }

      //    if (c > 0) {
      //        node = node.Left;
      //    } else {
      //        node = node.Right;
      //    }
      //}

      //return false;

      // defer to the node search helper function.
      return SearchWithParent(item, out _) != null;

    }

    public T Search(T item)
    {
      var node = SearchWithParent(item, out _);
      if (node != null)
      {
        return node.Item;
      }
      return default;
    }

    /// <summary>
    /// Finds and returns the first node containing the specified item.  If the item
    /// is not found, returns null.  Also returns the parent of the found node (or null)
    /// which is used in Remove.
    /// </summary>
    /// <param name="item">The item to search for</param>
    /// <param name="parent">The parent of the found node (or null)</param>
    /// <returns>The found node (or null)</returns>
    private Node<T> SearchWithParent(T item, out Node<T> parent)
    {
      // Now, try to find data in the tree
      var node = root;
      parent = null!;

      // while we don't have a match
      while (node != null)
      {
        var c = item.CompareTo(node.Item);

        if (c == 0)
        {
          // we have a match!
          return node;
        }

        parent = node;
        // if the item is less than current, go left.
        if (c < 0)
        {
          node = node.Left;
        }
        else
        {
          // if the item is more than current, go right.
          node = node.Right;
        }
      }

      return null!;
    }


    /// <summary>
    /// Removes the first occurance of the specified value from the tree.
    /// </summary>
    /// <param name="item">The value to remove</param>
    /// <returns>True if the value was removed, false otherwise</returns>
    public bool Remove(T item)
    {
      var current = SearchWithParent(item, out var parent);

      if (current == null)
      {
        return false;
      }

      Count--;

      // Case 1: If current has no right child, then current's left replaces current
      if (current.Right == null)
      {
        if (parent == null)
        {
          // removing node is root
          root = current.Left;
        }
        else
        {
          // Determine, if the current node (which will be removed) is left or right of its parent
          var result = current.CompareTo(parent.Item);
          if (result < 0)
          {
            // if parent value is less than current value
            // make the current left child a left child of parent
            parent.Left = current.Left;
          }
          else if (result > 0)
          {
            // if parent value is greater than current value
            // make the current left child a right child of parent
            parent.Right = current.Left;
          }
        }
      }
      // Case 2: If current has no left child, then current's right replaces current
      else if (current.Left == null)
      {
        if (parent == null)
        {
          // removing node is root
          root = current.Right;
        }
        else
        {
          // Determine, if the current node (which will be removed) is left or right of its parent
          var result = current.CompareTo(parent.Item);
          if (result < 0)
          {
            // if parent value is less than current value
            // make the current right child a left child of parent
            parent.Left = current.Right;
          }
          else if (result > 0)
          {
            // if parent value is greater than current value
            // make the current right child a right child of parent
            parent.Right = current.Right;
          }
        }
      }
      // Case 3: If current's right child has a left child, replace current with current's
      //         right child's left-most child
      else
      {
        // find the right's left-most child
        var leftmost = current.Right.Left;
        var leftmostParent = current.Right;

        if (leftmost == null)
        {
          leftmost = current.Right;
          // assign leftmost's left and right to current's left and right children
          leftmost.Left = current.Left;
        }
        else
        {
          while (leftmost.Left != null)
          {
            leftmostParent = leftmost;
            leftmost = leftmost.Left;
          }

          // the parent's left subtree becomes the leftmost's right subtree
          leftmostParent.Left = leftmost.Right;

          // assign leftmost's left and right to current's left and right children
          leftmost.Left = current.Left;
          leftmost.Right = current.Right;
        }

        if (parent == null)
        {
          // removing node is root
          root = leftmost;
        }
        else
        {
          // Determine, if the current node (which will be removed) is left or right of its parent
          var result = current.CompareTo(parent.Item);
          if (result < 0)
          {
            // if parent value is less than current value
            // make leftmost the parent's left child
            parent.Left = leftmost;
          }
          else if (result > 0)
          {
            // if parent value is greater than current value
            // make leftmost the parent's right child
            parent.Right = leftmost;
          }
        }
      }

      return true;
    }

    public void Clear()
    {
      root = null;
      Count = 0;
    }

    private void LevelOrder(Node<T> root, List<Node<T>> result)
    {
      if (root == null)
      {
        return;
      }

      var queue = new Queue<Node<T>>();
      queue.Enqueue(root);

      while (queue.Count > 0)
      {
        var node = queue.Dequeue();
        result.Add(node); // Aktuellen Knoten ausgeben

        if (node.Left != null)
        {
          queue.Enqueue(node.Left); // Kinder anstellen
        }

        if (node.Right != null)
        {
          queue.Enqueue(node.Right);
        }
      }
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      int level = 0;

      //if(TraverseMode == TraverseModeEnum.LevelOrder)
      //{
      //  var list = new List<Node<T>>();
      //  LevelOrder(root, list);

      //  foreach(var node in list)
      //  {
      //    sb.Append(node.Item.ToString()).Append(" -> ");
      //  }
      //}
      //else
      //{
      //  Traverse(root, sb, level);
      //}

      //if(DisplayMode == DisplayModeEnum.Linear || TraverseMode == TraverseModeEnum.LevelOrder)
      //{
      //  var output = sb.ToString();
      //  output = output.Remove(output.LastIndexOf(" -> "));
      //  return output;
      //}

      TraverseHierarchical(root, sb, level);


      return sb.ToString();
    }

    private void TraverseHierarchical(Node<T> node, StringBuilder sb, int level)
    {
      if (node != null)
      {
        if (level == 0)
        {
          sb.AppendLine($"{"".PadLeft(level, ' ')}{node.Item}");
        }
        else
        {
          sb.AppendLine($"{"".PadLeft(level, ' ')}|_{node.Item}");
        }

        TraverseHierarchical(node.Left, sb, level + 1);
        TraverseHierarchical(node.Right, sb, level + 1);
      }
    }

    private void Traverse(Node<T> node, StringBuilder sb, int level)
    {
      if (node != null)
      {

        switch (TraverseMode)
        {
          case TraverseModeEnum.PreOrder:
            if (DisplayMode == DisplayModeEnum.Hierarchical)
            {
              sb.AppendLine($"{"".PadLeft(level, ' ')}{node.Item}-{level}");
            }
            else
            {
              sb.Append(node.Item.ToString()).Append(" -> ");
            }
            Traverse(node.Left!, sb, level + 1);
            Traverse(node.Right!, sb, level + 1);
            break;

          case TraverseModeEnum.PostOrder:
            Traverse(node.Left!, sb, level + 1);
            Traverse(node.Right!, sb, level + 1);
            if (DisplayMode == DisplayModeEnum.Hierarchical)
            {
              sb.AppendLine($"{"".PadLeft(level, ' ')}{node.Item}-{level}");
            }
            else
            {
              sb.Append(node.Item.ToString()).Append(" -> ");
            }
            break;

          case TraverseModeEnum.InOrder:
            Traverse(node.Left!, sb, level + 1);
            if(DisplayMode == DisplayModeEnum.Hierarchical)
            { 
              sb.AppendLine($"{"".PadLeft(level, ' ')}{node.Item}-{level}");
            }
            else
            {
              sb.Append(node.Item.ToString()).Append(" -> ");
            }
            Traverse(node.Right!, sb, level + 1);
            break;

          case TraverseModeEnum.ReverseInOrder:
            Traverse(node.Right!, sb, level + 1);
            if(DisplayMode == DisplayModeEnum.Hierarchical)
            { 
              sb.AppendLine($"{"".PadLeft(level, ' ')}{node.Item}-{level}");
            }
            else
            {
              sb.Append(node.Item.ToString()).Append(" -> ");
            }
            Traverse(node.Left!, sb, level + 1);
            break;

        }
      }
    }
  }
}