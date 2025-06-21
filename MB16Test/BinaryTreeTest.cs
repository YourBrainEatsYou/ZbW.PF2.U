
using MB16.BinaryTreeAufgabe;
using System.Diagnostics;

namespace MB16Test
{
  /// <summary>
  /// Sample tree for most test is
  /// 
  ///           4
  ///        /     \
  ///       2       8
  ///      / \     / 
  ///     1   3   6
  ///            / \
  ///           5   7
  /// 
  /// PreOrder:   4,2,1,3,8,6,5,7
  /// PostOrder:  1,3,2,5,7,6,8,4
  /// InOrder:    1,2,3,4,5,6,7,8
  /// LevelOrder: 4,2,8,1,3,6,5,7
  /// </summary>
  [TestClass]
  public class BinaryTreeTest
  {
    [TestMethod]
    [DataRow(4, 2, 1, 3, 8, 6, 5, 7)]
    public void Tree_AddNodes_Success(params int[] entries)
    {
      // arrange
     var tree = GetTree(entries);

      tree.TraverseMode = TraverseModeEnum.InOrder;
      tree.DisplayMode = DisplayModeEnum.Hierarchical;

      // assert
      Assert.AreEqual(8, tree.Count);
      Debug.WriteLine(tree.ToString());
    }

    [TestMethod]
    //[DataRow(4, 2, 1, 3, 8, 6, 5, 7)]
    [DataRow(6,2,1,4,3,5,8,7,9)]
    public void Tree_Traverse_PreOrder(params int[] entries)
    {
      // arrange
      var tree = GetTree(entries);

      // act
      tree.TraverseMode = TraverseModeEnum.PreOrder;

      // assert
      Debug.WriteLine(tree.ToString());

    }

    [TestMethod]
    [DataRow(4, 2, 1, 3, 8, 6, 5, 7)]
    public void Tree_FindNode_PostOrder(params int[] entries)
    {
      // arrange
      var tree = GetTree(entries);

      // act
      tree.TraverseMode = TraverseModeEnum.PostOrder;

      // assert
      Debug.WriteLine(tree.ToString());

    }

    [TestMethod]
    [DataRow(4, 2, 1, 3, 8, 6, 5, 7)]
    public void Tree_FindNode_InOrder(params int[] entries)
    {
      // arrange
      var tree = GetTree(entries);

      // act
      tree.TraverseMode = TraverseModeEnum.InOrder;

      // assert
      Debug.WriteLine(tree.ToString());

    }

    [TestMethod]
    [DataRow(4, 2, 1, 3, 8, 6, 5, 7)]
    public void Tree_FindNode_ReversInOrder(params int[] entries)
    {
      // arrange
      var tree = GetTree(entries);

      // act
      tree.TraverseMode = TraverseModeEnum.ReverseInOrder;

      // assert
      Debug.WriteLine(tree.ToString());

    }

    [TestMethod]
    [DataRow(4, 2, 1, 3, 8, 6, 5, 7)]
   public void Tree_FindNode_LevelOrder(params int[] entries)
    {
      // arrange
      var tree = GetTree(entries);

      // act
      tree.TraverseMode = TraverseModeEnum.LevelOrder;

      // assert
      Debug.WriteLine(tree.ToString());

    }

    [TestMethod]
    [DataRow(110, 130, 135, 140, 150, 160)]
    public void Tree_Balance_Success(params int[] entries)
    {
      // arrange
      var tree = GetTree(entries);

      // act
      tree.TraverseMode = TraverseModeEnum.InOrder;
      tree.DisplayMode = DisplayModeEnum.Hierarchical;

      tree.Balance();

      // assert
      Debug.WriteLine(tree.ToString());

    }

    [TestMethod]
    [DataRow(4, 2, 1, 3, 8, 6, 5, 7)]
    public void Tree_DeleteLeafNode_Case1(params int[] entries)
    {
      // arrange
      var tree = GetTree(entries);
      tree.TraverseMode = TraverseModeEnum.InOrder;
      tree.DisplayMode = DisplayModeEnum.Hierarchical;

      // act
      tree.Remove(1);

      // assert
      Assert.IsFalse(tree.Contains(1));
      Debug.WriteLine(tree.ToString());

    }

    [TestMethod]
    [DataRow(4, 2, 1, 3, 8, 6, 5, 7)]
    public void Tree_DeleteNoRightChild_Case2(params int[] entries)
    {
      // arrange
      var tree = GetTree(entries);
      tree.TraverseMode = TraverseModeEnum.InOrder;
      tree.DisplayMode = DisplayModeEnum.Hierarchical;

      // act
      tree.Remove(8);

      // assert
      Assert.IsFalse(tree.Contains(8));
      Debug.WriteLine(tree.ToString());

    }

    [TestMethod]
    [DataRow(4, 2, 1, 3, 8, 6, 7)]
    public void Tree_DeleteNoLeftChild_Case3(params int[] entries)
    {
      // arrange
      var tree = GetTree(entries);
      tree.TraverseMode = TraverseModeEnum.InOrder;
      tree.DisplayMode = DisplayModeEnum.Hierarchical;

      // act
      tree.Remove(6);

      // assert
      Assert.IsFalse(tree.Contains(6));
      Debug.WriteLine(tree.ToString());

    }

    [TestMethod]
    [DataRow(4, 2, 1, 3, 6, 5, 8, 7)]
    public void Tree_DeleteHasLeftAndRightChild_Case4(params int[] entries)
    {
      // arrange
      var tree = GetTree(entries);
      tree.TraverseMode = TraverseModeEnum.InOrder;
      tree.DisplayMode = DisplayModeEnum.Hierarchical;

      // act
      tree.Remove(6);

      // assert
      Assert.IsFalse(tree.Contains(6));
      Debug.WriteLine(tree.ToString());

    }


    private BinaryTree<T> GetTree<T>(params T[] entries) where T : IComparable<T>
    {
      var tree = new BinaryTree<T>();

      foreach (var entry in entries)
      {
        tree.Add(entry);
      }

      return tree;
    }


  }
}
