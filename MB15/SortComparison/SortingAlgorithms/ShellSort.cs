using System.Collections.Generic;

namespace MB15.SortComparison.SortingAlgorithms
{
    internal class ShellSort : SortAlgorithm
    {
        public override string Name => "ShellSort";

        public override void Sort(IList<int> arrayToSort)
        {
            var length = arrayToSort.Count;

            /*
             * create gaps based on the length of the array
             * for each step divide the gap in half
             *
             * ex. 16 -> 8 -> 4 -> 2 -> 1
             */
            for (var gapSize = length / 2; gapSize > 0; gapSize /= 2)
            {
                // Basic gapped "Insertion Sort" implementation
                for (var index = gapSize; index < length; index += 1)
                {
                    // This element needs to be sorted, put it into a variable
                    var itemToInsert = arrayToSort[index];

                    // init the targetIndex with our gap index.
                    var targetIndex = index;

                    // While our targetIndex is greater than our gap
                    // and the other (targetIndex - gapSize) element is greater than our element
                    while (targetIndex >= gapSize && arrayToSort[targetIndex - gapSize] > itemToInsert)
                    {
                        // Shift elements until we find the correct position for our "itemToInsert" element
                        arrayToSort[targetIndex] = arrayToSort[targetIndex - gapSize];
                        targetIndex -= gapSize;
                    }

                    // yay! we found a correct location for our item.
                    // put our element here so we won't lose it.
                    arrayToSort[targetIndex] = itemToInsert;
                }
            }
        }
    }
}
