TQueue<string> t = new ();
t.EnQueue ("Hello");
t.EnQueue ("Hi");
t.EnQueue ("Good");
t.EnQueue ("Wow");
Console.WriteLine ("Removing " + t.DeQueue ());
t.EnQueue ("Super");

/// <summary>Implementation of Circular Queue class using array</summary>
class TQueue<T> {
   /// <summary>Adds element in the queue</summary>
   public void EnQueue (T a) {
      if (((mRear + 1) % mQueueArray.Length) == mFront) throw new Exception ("Overflow");
      if (mFront == -1) mFront = 0;
      mRear = (mRear + 1) % mQueueArray.Length;
      mQueueArray[mRear] = a;
      Console.WriteLine ($"Inserting {a}");
   }

   /// <summary>Removes element in the queue</summary>
   public T DeQueue () {
      if (IsEmpty () == true) throw new Exception ("Underflow");
      T item = mQueueArray[mFront];
      if (mFront == mRear) mFront = mRear = -1;
      else mFront = (mFront + 1) % mQueueArray.Length;
      return item;
   }

   /// <summary>Checks element is present or not in the queue</summary>
   public bool IsEmpty () {
      if (mFront == -1 || mFront > mRear) return true;
      return false;
   }

   /// <summary>Intialize the array with size of 4</summary>
   T[] mQueueArray = new T[4];
   int mFront = -1;
   int mRear = -1;
}