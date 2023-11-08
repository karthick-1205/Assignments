var pq = new PriorityQueue<int> ();
pq.EnQueue (25);
pq.EnQueue (8);
Console.WriteLine (pq.DeQueue ());
pq.EnQueue (27);
pq.EnQueue (3);
Console.WriteLine (pq.DeQueue ());
pq.EnQueue (1);
pq.EnQueue (2);
pq.EnQueue (7);
foreach (var item in pq.mData)
   Console.Write (item + " ");
Console.WriteLine ();

/// <summary>Implementation of PriroityQueue using Binary Min Heap</summary>
public class PriorityQueue<T> where T : IComparable<T> {

   public List<T> mData = new();

   /// <summary>Adds element in the priority queue</summary>
   public void EnQueue (T item) {
      mData.Add (item);
      int ci = mData.Count - 1;
      while (ci > 0) {
         int pi = (ci - 1) / 2;
         if (mData[ci].CompareTo (mData[pi]) >= 0) break;
         (mData[pi], mData[ci]) = (mData[ci], mData[pi]);
         ci = pi;
      }
   }

   /// <summary>Removes element in the priority queue</summary>
   public T DeQueue () {
      int li = mData.Count - 1;
      T top = mData[0];
      mData[0] = mData[li];
      mData.RemoveAt (li);
      --li;
      int pi = 0;
      while (true) {
         int ci = pi * 2 + 1;
         if (ci > li) break;
         int rc = ci + 1;
         if (rc <= li && mData[rc].CompareTo (mData[ci]) < 0) ci = rc;
         if (mData[pi].CompareTo (mData[ci]) <= 0) break;
         (mData[ci], mData[pi]) = (mData[pi], mData[ci]);
         pi = ci;
      }
      return top;
   }

   /// <summary>Checks element is present or not in the priority queue</summary>
   public bool IsEmpty => mCount == 0;

   int mCount;
}