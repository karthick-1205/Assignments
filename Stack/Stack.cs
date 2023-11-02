public class TStack<T> {
   /// <summary>Inserts elements into the stack</summary>
   public void Push (T a) {
      if (mPointer == mStackArray.Length) {
         var tmp = new T[mPointer * 2];
         for (int i = 0; i < mPointer; i++) tmp[i] = mStackArray[i];
         mStackArray = tmp;
      }
      mStackArray[mPointer++] = a;
   }

   /// <summary>Removes elements from the stack</summary>
   public T Pop () {
      if (IsEmpty) throw new InvalidOperationException ("Stack empty");
      return mStackArray[--mPointer];
   }

   /// <summary>Returns top most element of the stack</summary>
   public T Peek () {
      if (IsEmpty) throw new InvalidOperationException ("Stack empty");
      T a = Pop ();
      Push (a);
      return a;
   }

   /// <summary>Returns true if the stack is empty</summary>
   public bool IsEmpty => mPointer == 0;

   T[] mStackArray = new T[4];
   int mPointer;
}