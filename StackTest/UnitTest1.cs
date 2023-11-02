namespace StackTest {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void TestPushAndPop () {
         TStack<int> tStack = new ();
         Stack<int> stack = new ();
         var vals = new int[] { 1, 2, 3 };
         foreach (var v in vals) {
            tStack.Push (v);
            stack.Push (v);
         }
         Assert.AreEqual (stack.Pop (), tStack.Pop ());
      }

      [TestMethod]
      public void TestPeek () {
         TStack<string> tStack = new ();
         Stack<string> stack = new ();
         var vals = new string[] { "Hi", "Hello", "Super" };
         foreach (var v in vals) {
            tStack.Push (v);
            stack.Push (v);
         }
         Assert.AreEqual (stack.Peek (), tStack.Peek ());
      }

      [TestMethod]
      public void IsEmptyTest () {
         TStack<char> stack = new ();
         Assert.IsTrue (stack.IsEmpty);
         stack.Push ('a');
         Assert.IsFalse (stack.IsEmpty);
         stack.Pop ();
         Assert.IsTrue (stack.IsEmpty);
      }

      [TestMethod]
      public void PopEmptyStackTest () {
         TStack<double> stack = new ();
         Assert.ThrowsException<InvalidOperationException> (() => stack.Pop ());
      }

      [TestMethod]
      public void PeekEmptyStackTest () {
         TStack<double> stack = new ();
         Assert.ThrowsException<InvalidOperationException> (() => stack.Peek ());
      }
   }
}