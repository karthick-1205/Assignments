using PQueue;
namespace PriorityQueueTest {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void TestPriorityQueue () {
         PriorityQueue<int> pQueue = new ();
         var testData = new List<int> () { 0 };
         var listData = new List<int> { 4, 7, 1, 3, 8, 5, 9, 6 };
         foreach (var v in listData) {
            pQueue.EnQueue (v);
            testData.Add (v);
         }
         testData.Sort ();
         for (int i = 1; i <= testData.Count - 1; i++) {
            Assert.AreEqual (testData.ElementAt (i), pQueue.DeQueue ());
         }
      }
   }
}