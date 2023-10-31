public class TStack<T> {
   /// <summary>Inserts elements into the stack</summary>
   public void Push (T a) {
      if (mPointer == stackArray.Length) {
         var tmp = new T[mPointer * 2];
         for (int i = 0; i < mPointer; i++) tmp[i] = stackArray[i];
         stackArray = tmp;
      }
      stackArray[mPointer++] = a;
   }

   /// <summary>Remove elements from the stack</summary>
   public T Pop () {
      if (mPointer == 0) throw new InvalidOperationException ("Stack empty");
      return stackArray[--mPointer];
   }

   /// <summary>Returns top most element of the stack</summary>
   public T Peek () {
      if (mPointer == 0) throw new InvalidOperationException ("Stack empty");
      T a = Pop ();
      Push (a);
      return a;
   }

   /// <summary>Returns true if the stack is empty</summary>
   public bool IsEmpty => mPointer == 0;

   T[] stackArray = new T[4];
   int mPointer;
}