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
      if (mPointer == mQueueArray.Length) {
         var newArray = new T[mPointer * 2];
         for (int i = 0; i < mPointer; i++)
            newArray[i] = mQueueArray[(mFront + i) % mPointer];
         mQueueArray = newArray;
         mFront = 0;
         mRear = mPointer;
      }
      mQueueArray[mRear] = a;
      mRear = (mRear + 1) % mQueueArray.Length;
      mPointer++;
      Console.WriteLine ($"Inserting {a}");
   }

   /// <summary>Removes element in the queue</summary>
   public T DeQueue () {
      if (IsEmpty) throw new Exception ("Underflow");
      T item = mQueueArray[mFront];
      mFront = (mFront + 1) % mQueueArray.Length;
      mPointer--;
      return item;
   }

   /// <summary>Checks element is present or not in the queue</summary>
   public bool IsEmpty => mPointer == 0;

   /// <summary>Intialize the array with size of 4</summary>
   T[] mQueueArray = new T[4];
   int mPointer, mFront, mRear;
}