namespace Queue;
internal class Program {
   private static void Main () {
   }
}

/// <summary>Implementation of circular queue class using array</summary>
public class TQueue<T> {
   /// <summary>Inserts elements into the queue</summary>
   public void EnQueue (T a) {
      if (mCount == mQueue.Length) {
         var tmp = new T[mCount * 2];
         for (int i = 0; i < mCount; i++)
            tmp[i] = mQueue[(mFront + i) % mCount];
         (mQueue, mFront, mRear) = (tmp, 0, mCount);
      }
      mQueue[mRear] = a;
      mRear = (mRear + 1) % mQueue.Length;
      mCount++;
   }

   /// <summary>Remove elements from the queue</summary>
   public T DeQueue () {
      if (IsEmpty) throw new InvalidOperationException ("Queue empty");
      T a = mQueue[mFront];
      mFront = (mFront + 1) % mQueue.Length;
      mCount--;
      return a;
   }

   /// <summary>Returns first element of the queue</summary>
   public T Peek () {
      if (IsEmpty) throw new InvalidOperationException ("Queue empty");
      return mQueue[mFront];
   }

   /// <summary>Returns true if the queue is empty</summary>
   public bool IsEmpty => mCount == 0;

   T[] mQueue = new T[4];
   int mRear; // Position where the next Enqueue will happen
   int mFront; // Position where the next Dequeue will happen
   int mCount; // Count of elements in the queue
}