using List;
namespace ListTest {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void TestIndex () {
         MyList<int> tList = new ();
         List<int> list = new ();
         var listData = new List<int> { 4, 7, 1, 3, 8, 5, 9, 6 };
         foreach (var v in listData) {
            tList.Add (v);
            list.Add (v);
         }
         tList[3] = 33;
         list[3] = 33;
         Assert.AreEqual (list[3], tList[3]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => tList[12]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => tList[-3]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => tList[17] = 10);
         Assert.ThrowsException<IndexOutOfRangeException> (() => tList[-1] = 2);
      }

      [TestMethod]
      public void TestAdd () {
         MyList<int> tList = new ();
         List<int> list = new ();
         var listData = new List<int> { 4, 7, 1, 3, 8, 5, 9, 6 };
         foreach (var v in listData) {
            tList.Add (v);
            list.Add (v);
         }
         for (int i = 0; i < tList.Count; i++) Assert.AreEqual (list[i], tList[i]);
      }

      [TestMethod]
      public void TestRemove () {
         MyList<int> tList = new ();
         List<int> list = new ();
         var listData = new List<int> { 4, 7, 1, 3, 8, 5, 9, 6 };
         foreach (var v in listData) {
            tList.Add (v);
            list.Add (v);
         }
         Assert.AreEqual (list.Remove (7), tList.Remove (7));
         Assert.ThrowsException<InvalidOperationException> (() => tList.Remove (-2));
      }

      [TestMethod]
      public void TestClear () {
         MyList<int> tList = new ();
         List<int> list = new ();
         var listData = new List<int> { 4, 7, 1, 3, 8, 5, 9, 6 };
         foreach (var v in listData) {
            tList.Add (v);
            list.Add (v);
         }
         list.Clear ();
         tList.Clear ();
         Assert.AreEqual (list.Count, tList.Count);
      }

      [TestMethod]
      public void TestInsert () {
         MyList<int> tList = new ();
         List<int> list = new ();
         var listData = new List<int> { 4, 7, 1, 3, 8, 5, 9, 6 };
         foreach (var v in listData) {
            tList.Add (v);
            list.Add (v);
         }
         list.Insert (0, 13);
         tList.Insert (0, 13);
         Assert.AreEqual (list[0], tList[0]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => tList.Insert (-2, 15));
         Assert.ThrowsException<IndexOutOfRangeException> (() => tList.Insert (11, 23));
      }
      [TestMethod]
      public void TestRemoveAt () {
         MyList<int> tList = new ();
         List<int> list = new ();
         var listData = new List<int> { 4, 7, 1, 3, 8, 5, 9, 6 };
         foreach (var v in listData) {
            tList.Add (v);
            list.Add (v);
         }
         Assert.ThrowsException<IndexOutOfRangeException> (() => tList.RemoveAt (-1));
         Assert.ThrowsException<IndexOutOfRangeException> (() => tList.RemoveAt (11));
         tList.RemoveAt (3);
         Assert.AreNotEqual (list.Count, tList.Count);
      }
   }
}