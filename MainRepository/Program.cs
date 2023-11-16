namespace List;
internal class Program {
   private static void Main () {
   }
}

#region class List ---------------------------------------------------------------------
/// <summary>Implementation of list class</summary>
/// <typeparam name="T">T is type of variables declared in the List</typeparam>
public class MyList<T> {

   #region Constructor ------------------------------------------- 
   /// <summary>Constructor used to assign values to the list and count</summary>
   public MyList () {
      mList = new T[4];
      mCount = 0;
   }
   #endregion

   #region Properties ---------------------------------------------
   /// <summary>Gets the total number of elements in the list</summary>
   public int Capacity => mList.Length;

   /// <summary>Gets the number of elements in the list</summary>
   public int Count => mCount;
   #endregion

   #region Methods
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

   /// <summary>Clear all elements from the list</summary>
   public void Clear () {
      Array.Clear (mList);
      mCount = 0;
   }

   /// <summary>Inserts an element at the given index</summary>
   /// <param name="index">The index position from which the element is to be inserted</param>
   /// <param name="a">The element to be inserted</param>
   /// <exception cref="IndexOutOfRangeException">Throws exception when the given index below 0 (or) greater than or equal to the count</exception>
   public void Insert (int index, T a) {
      ValidateIndex (index);
      if (mCount == Capacity) {
         var tmp = new T[mCount * 2];
         for (int i = 0; i < mCount; i++) tmp[i] = mList[i];
         mList = tmp;
      }
      for (int i = mCount; i > index; i--) mList[i] = mList[i - 1];
      mList[index] = a;
      mCount++;
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

   /// <summary>Removes the element in the given index position</summary>
   /// <param name="index">The index position from which the element is to be removed</param>
   /// <exception cref="IndexOutOfRangeException">Throws exception when the given index below 0 (or) greater than or equal to the count</exception>

   public void RemoveAt (int index) {
      ValidateIndex (index);
      Remove (mList[index]);
   }

   /// <summary>Gets / sets the value in the given index</summary>
   /// <param name="index">The index position to get or set the value</param>
   /// <returns>The value in the given index position</returns>
   /// <exception cref="IndexOutOfRangeException">Throws exception when the given index below 0 (or) greater than or equal to the count</exception>
   public T this[int index] {
      get {
         if (ValidateIndex (index)) return mList[index];
         return default!;
      }
      set {
         if (ValidateIndex (index)) mList[index] = value;
      }
   }

   /// <summary>Checks whether a given index is valid range or not</summary>
   /// <param name="pos">The index is to be validated</param>
   /// <returns>Returns true if the index within the valid range</returns>
   /// <exception cref="IndexOutOfRangeException">Throws exception when the given index below 0 (or) greater than or equal to the count</exception>
   public bool ValidateIndex (int pos) {
      if (pos < 0 || pos >= mCount) throw new IndexOutOfRangeException ("Index out of valid range");
      return true;
   }
   #endregion

   T[] mList;
   int mCount; // Count of elements in the list
}
#endregion