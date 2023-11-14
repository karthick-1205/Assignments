using Queue;
namespace QueueTest {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void TestEnqueueAndDequeue () {
         TQueue<int> tQueue = new ();
         Queue<int> queue = new ();
         var listData = new List<int> { 4, 7, 1, 3, 8, 5, 9, 6 };
         foreach (var v in listData) {
            tQueue.EnQueue (v);
            queue.Enqueue (v);
         }
         for (int i = 0; i < listData.Count; i++)
            Assert.AreEqual (queue.Dequeue (), tQueue.DeQueue ());
      }

      [TestMethod]
      public void TestPeek () {
         TQueue<Double> tQueue = new ();
         Queue<Double> queue = new ();
         var listData = new List<Double> { 4.5, 7.2, 1.6, 3.1, 8.9, 5.3, 9.4, 6.8 };
         foreach (var v in listData) {
            tQueue.EnQueue (v);
            queue.Enqueue (v);
         }
         Assert.AreEqual (queue.Peek (), tQueue.Peek ());
      }

      [TestMethod]
      public void IsEmptyTest () {
         TQueue<char> queue = new ();
         Assert.IsTrue (queue.IsEmpty);
         queue.EnQueue ('a');
         Assert.IsFalse (queue.IsEmpty);
         queue.DeQueue ();
         Assert.IsTrue (queue.IsEmpty);
      }

      [TestMethod]
      public void PopEmptyQueueTest () =>
         Assert.ThrowsException<InvalidOperationException> (() => new TQueue<string> ().DeQueue ());

      [TestMethod]
      public void PeekEmptyQueueTest () =>
         Assert.ThrowsException<InvalidOperationException> (() => new TQueue<string> ().Peek ());
   }
}