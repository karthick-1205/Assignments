// Implementation of PriroityQueue using Binary Heap
var pq = new PriorityQueue<int> ();
pq.Enqueue (25);
pq.Enqueue (8);
Console.WriteLine (pq.Dequeue ());
pq.Enqueue (27);
pq.Enqueue (3);
Console.WriteLine (pq.Dequeue ());
pq.Enqueue (1);
pq.Enqueue (2);
pq.Enqueue (7);
foreach (var item in pq.data)
   Console.Write (item + " ");
Console.WriteLine ();

public class PriorityQueue<T> where T : IComparable<T> {

   public List<T> data = new List<T> ();

   // Element inserting function maintain min heap
   public void Enqueue (T item) {
      data.Add (item);
      int ci = data.Count - 1;
      while (ci > 0) {
         int pi = (ci - 1) / 2;
         if (data[ci].CompareTo (data[pi]) >= 0) break;
         T tmp = data[ci];
         data[ci] = data[pi];
         data[pi] = tmp;
         ci = pi;
      }
   }

   // Element deleting function maintain min heap
   public T Dequeue () {
      int li = data.Count - 1;
      T top = data[0];
      data[0] = data[li];
      data.RemoveAt (li);
      --li;
      int pi = 0;
      while (true) {
         int ci = pi * 2 + 1;
         if (ci > li) break;
         int rc = ci + 1;
         if (rc <= li && data[rc].CompareTo (data[ci]) < 0) ci = rc;
         if (data[pi].CompareTo (data[ci]) <= 0) break;
         T tmp = data[pi];
         data[pi] = data[ci];
         data[ci] = tmp;
         pi = ci;
      }
      return top;
   }
   public bool IsEmpty => mCount == 0;
   int mCount;
}