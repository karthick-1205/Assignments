// Implementation of Circular Queue using array
TQueue<string> t = new ();
t.EnQueue ("Hello");
t.EnQueue ("Hi");
t.EnQueue ("Good");
t.EnQueue ("Wow");
Console.WriteLine ("Removing " + t.DeQueue ());
t.EnQueue ("Super");

class TQueue<T> {
   // Add element in the queue
   public void EnQueue (T a) {
      if (((rear + 1) % arr.Length) == front)
         throw new Exception ("Overflow");
      if (front == -1)
         front = 0;
      rear = (rear + 1) % arr.Length;
      arr[rear] = a;
      Console.WriteLine ($"Inserting {a}");
   }

   // Remove element in the queue
   public T DeQueue () {
      T item;
      if (IsEmpty () == true)
         throw new Exception ("Underflow");
      item = arr[front];
      if (front == rear)
         front = rear = -1;
      else
         front = (front + 1) % arr.Length;
      return item;
   }

   // Check element is present or not in the queue
   public bool IsEmpty () {
      if (front == -1 || front > rear)
         return true;
      return false;
   }
   int front = -1;
   int rear = -1;
   // Intialize the array
   T[] arr = new T[4];
}