namespace StackTest {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void TestPushAndPop () {
         TStack<int> stack = new ();
         stack.Push (1);
         stack.Push (2);
         stack.Push (3);
         stack.Push (4);
         stack.Push (5);
         stack.Push (6);
         int popValue = stack.Pop ();
         Assert.AreEqual (6, popValue);
      }

      [TestMethod]
      public void TestPeek () {
         TStack<string> stack = new ();
         stack.Push ("Hello");
         stack.Push ("Hi");
         string peekValue = stack.Peek ();
         Assert.AreEqual ("Hi", peekValue);
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