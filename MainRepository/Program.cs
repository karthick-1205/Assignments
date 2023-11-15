namespace List;
internal class Program {
   private static void Main () {
   }
}

/// <summary>Implementation of list class</summary>
/// <typeparam name="T">T is type of variables declared in the List</typeparam>
public class MyList<T> {

   /// <summary>Constructor used to assign values to the list and count</summary>
   public MyList () {
      mList = new T[4];
      mCount = 0;
   }

   /// <summary>Gets the number of elements in the list</summary>
   public int Count => mCount;

   /// <summary>Gets the total number of elements in the list</summary>
   public int Capacity => mList.Length;

   /// <summary>To get the value in the given index and to set an value to the given index</summary>
   /// <param name="index">The index position to get or set the value</param>
   /// <returns>The value in the given index position</returns>
   /// <exception cref="IndexOutOfRangeException">Throws exception when the given index below 0 (or) greater than or equal to the count</exception>
   public T this[int index] {
      get {
         return index < 0 || index >= mCount ? throw new IndexOutOfRangeException ("Index out of valid range") : mList[index];
      }
      set {
         if (index < 0 || index >= mCount) throw new IndexOutOfRangeException ("Index out of valid range");
         mList[index] = value;
      }
   }

   /// <summary>Adds an element to the list and increase its size if required</summary>
   /// <param name="a">The element to be added</param>
   public void Add (T a) {
      if (mCount == Capacity) {
         var tmp = new T[mCount * 2];
         for (int i = 0; i < mCount; i++) tmp[i] = mList[i];
         mList = tmp;
      }
      mList[mCount++] = a;
   }

   /// <summary>Removes an element from the list</summary>
   /// <param name="a">The element to be removed</param>
   /// <returns>Returns true if the element is removed</returns>
   /// <exception cref="InvalidOperationException">Throws exception when the element is not found in the list</exception>
   public bool Remove (T a) {
      int index = Array.IndexOf (mList, a, 0, mCount);
      if (index == -1) throw new InvalidOperationException ("Item not found in the list");
      for (int i = index; i < mCount - 1; i++) mList[i] = mList[i + 1];
      mCount--;
      mList[mCount] = default!;
      return true;
   }

   /// <summary>Clear all elements from the list</summary>
   public void Clear () {
      Array.Clear (mList, 0, mCount);
      mCount = 0;
   }

   /// <summary>Inserts an element between two elements in the list</summary>
   /// <param name="index">The index posistion from which the element is to be inserted</param>
   /// <param name="a">The element to be inserted</param>
   /// <exception cref="IndexOutOfRangeException">Throws exception when the given index below 0 (or) greater than or equal to the count</exception>
   public void Insert (int index, T a) {
      if (index < 0 || index >= mCount) throw new IndexOutOfRangeException ("Index out of valid range");
      if (mCount == Capacity) {
         var tmp = new T[mCount * 2];
         for (int i = 0; i < mCount; i++) tmp[i] = mList[i];
         mList = tmp;
      }
      for (int i = mCount; i > index; i--) mList[i] = mList[i - 1];
      mList[index] = a;
      mCount++;
   }

   /// <summary>Removes the element in the given index posistion</summary>
   /// <param name="index">The index posistion from which the element is to be removed</param>
   /// <exception cref="IndexOutOfRangeException">Throws exception when the given index below 0 (or) greater than or equal to the count</exception>

   public void RemoveAt (int index) {
      if (index < 0 || index >= mCount) throw new IndexOutOfRangeException ("Index out of valid range");
      for (int i = index; i < mCount - 1; i++) mList[i] = mList[i + 1];
      mCount--;
      mList[mCount] = default!;
   }

   T[] mList;
   int mCount;// Count of elements in the list
}