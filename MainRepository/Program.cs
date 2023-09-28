//Chocolate Wrappers
while (true) {
   GetNumber ("Enter the money: ", out int n);
   GetNumber ("Enter the the price of the chocolate: ", out int n1);
   GetNumber ("Enter the number chocolate wrapper in exchange: ", out int n2);
   while (n2 == 1) {
      Console.WriteLine ("Enter the number greater than 1");
      GetNumber ("Enter the number chocolate wrapper in exchange: ", out n2);
   }
   ChocolateWrapper (n, n1, n2);
}

/// <summary> Displays total chocolate, remain balance amount and remain wrappers </summary>
void ChocolateWrapper (int money, int price, int wrapper) {
   int totalChocolate = money / price, remainWrappers = totalChocolate, newChocolate;
   int unusedMoney = money % price;
   while (remainWrappers > wrapper - 1) {
      newChocolate = remainWrappers / wrapper;
      remainWrappers = remainWrappers - (newChocolate * wrapper) + newChocolate;
      totalChocolate += newChocolate;
   }
   Console.WriteLine ($"The total chocolate is {totalChocolate}");
   Console.WriteLine ($"The unused money is {unusedMoney}");
   Console.WriteLine ($"The remaining wrapper is {remainWrappers}");
}

/// <summary> Returns valid postive integer from the user for the given message </summary>
static void GetNumber (string message, out int number) {
   string response;
   number = 0;
   do {
      if (number < 0) Console.WriteLine ("Enter the valid input");
      Console.Write (message);
      response = Console.ReadLine ();
      while (!response.All (char.IsDigit)) {
         Console.WriteLine ("Enter the valid input");
         Console.Write (message);
         response = Console.ReadLine ();
      }
   }
   while (int.TryParse (response, out number) && number <= 0);
}