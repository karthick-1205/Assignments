//Chocolate Wrappers
while (true) {
   int m = GetNumber ("Enter the money: ");
   int p = GetNumber ("Enter the the price of the chocolate: ");
   int w = GetNumber ("Enter the number chocolate wrapper in exchange: ");
   while (w == 1) {
      Console.WriteLine ("Enter the number greater than 1");
      w = GetNumber ("Enter the number chocolate wrapper in exchange: ");
   }
   ChocolateWrapper (m, p, w);
}

/// <summary> Displays total chocolate, remain balance amount and remain wrappers </summary>
void ChocolateWrapper (int money, int price, int wrapper) {
   int totalChocolate = money / price, remainWrappers = totalChocolate;
   int unusedMoney = money % price;
   while (remainWrappers > wrapper - 1) {
      int newChocolate = remainWrappers / wrapper;
      remainWrappers = remainWrappers - (newChocolate * wrapper) + newChocolate;
      totalChocolate += newChocolate;
   }
   Console.WriteLine ($"The total chocolate is {totalChocolate}");
   Console.WriteLine ($"The unused money is {unusedMoney}");
   Console.WriteLine ($"The remaining wrapper is {remainWrappers}");
}

/// <summary> Returns valid postive integer from the user for the given message </summary>
static int GetNumber (string message) {
   string response;
   int number = 0;
   do {
      if (number < 0) Console.WriteLine ("Enter the valid input");
      Console.Write (message);
      response = Console.ReadLine ();
   }
   while (int.TryParse (response, out number) && number <= 0);
   return number;
}