TQueue<string> t = new ();
t.EnQueue ("Hello");
t.EnQueue ("Hi");
t.EnQueue ("Good");
t.EnQueue ("Wow");
t.EnQueue ("Super");
t.EnQueue ("WellDone");
Console.WriteLine ("Removing " + t.DeQueue ());

/// <summary>Implementation of Circular Queue class using array</summary>
class TQueue<T> {
   /// <summary>Adds element in the queue</summary>
   public void EnQueue (T a) {
      if (((mRear + 1) % mQueueArray.Length) == mFront) {
         int newSize = mQueueArray.Length * 2;
         T[] newArray = new T[newSize];
         int index = 0;
         int oldSize = mQueueArray.Length;
         for (int i = mFront; index < oldSize; i = (i + 1) % oldSize) {
            newArray[index] = mQueueArray[i];
            index++;
         }
         mFront = 0;
         mRear = oldSize - 1;
         mQueueArray = newArray;
      }
      if (mFront == -1) mFront = 0;
      mRear = (mRear + 1) % mQueueArray.Length;
      mQueueArray[mRear] = a;
      Console.WriteLine ($"Inserting {a}");
   }

   /// <summary>Removes element in the queue</summary>
   public T DeQueue () {
      if (IsEmpty) throw new Exception ("Underflow");
      T item = mQueueArray[mFront];
      if (mFront == mRear) mFront = mRear = -1;
      else mFront = (mFront + 1) % mQueueArray.Length;
      return item;
   }

   /// <summary>Checks element is present or not in the queue</summary>
   public bool IsEmpty => mFront == -1 || mFront > mRear;

   /// <summary>Intialize the array with size of 4</summary>
   T[] mQueueArray = new T[4];
   int mFront = -1;
   int mRear = -1;
}