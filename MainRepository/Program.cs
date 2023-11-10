internal class Program {
   private static void Main () {
   }
}

/// <summary>Implementation of circular queue class using array</summary>
public class TQueue<T> {
   /// <summary>Inserts elements into the queue</summary>
   public void EnQueue (T a) {
      if (mCount == mQueueArray.Length) {
         var newArray = new T[mCount * 2];
         for (int i = 0; i < mCount; i++)
            newArray[i] = mQueueArray[(mFront + i) % mCount];
         (mQueueArray, mFront, mRear) = (newArray, 0, mCount);
      }
      mQueueArray[mRear] = a;
      mRear = (mRear + 1) % mQueueArray.Length;
      mCount++;
   }

   /// <summary>Remove elements from the queue</summary>
   public T DeQueue () {
      if (IsEmpty) throw new InvalidOperationException ("Queue empty");
      T a = mQueueArray[mFront];
      mFront = (mFront + 1) % mQueueArray.Length;
      mCount--;
      return a;
   }

   /// <summary>Returns first element of the queue</summary>
   public T Peek () {
      if (IsEmpty) throw new InvalidOperationException ("Queue empty");
      T a = mQueueArray[mFront];
      return a;
   }

   /// <summary>Returns true if the queue is empty</summary>
   public bool IsEmpty => mCount == 0;

   T[] mQueueArray = new T[4];
   int mCount, mFront, mRear;

}