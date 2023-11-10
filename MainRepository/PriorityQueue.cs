namespace PQueue {
   /// <summary>Implementation of PriroityQueue using "Binary Min Heap" concept</summary>
   public class PriorityQueue<T> where T : IComparable<T> {

      List<T> mData = new () { default! };

      /// <summary>Adds element in the priority queue</summary>
      public void EnQueue (T item) {
         mData.Add (item);
         int child = mData.Count - 1;
         while (child > 1) {
            int parent = child / 2;
            if (mData[child].CompareTo (mData[parent]) >= 0) break;
            (mData[parent], mData[child]) = (mData[child], mData[parent]);
            child = parent;
         }
      }

      /// <summary>Removes element in the priority queue</summary>
      public T DeQueue () {
         int lastIndex = mData.Count - 1;
         T top = mData[1];
         mData[1] = mData[lastIndex];
         mData.RemoveAt (lastIndex);
         --lastIndex;
         int parent = 1;
         while (true) {
            int child = parent * 2;
            if (child > lastIndex) break;
            int right = child + 1;
            if (right <= lastIndex && mData[right].CompareTo (mData[child]) < 0) child = right;
            if (mData[parent].CompareTo (mData[child]) <= 0) break;
            (mData[child], mData[parent]) = (mData[parent], mData[child]);
            parent = child;
         }
         return top;
      }
   }
}
