//SWAP Indices
Random rand = new Random ();
int stringLen = rand.Next (3, 10);
string str = "";
for (int i = 0; i < stringLen; i++) {
   int randValue = rand.Next (1, 10);
   str += randValue;
}
Console.Write ("Series of random numbers: ");
for (int i = 0; i < str.Length; i++) Console.Write (str[i] + " ");
char[] randarr = str.ToCharArray ();
Console.Write ("\nEnter the index to be swapped: ");
int index1 = Convert.ToInt32 (Console.ReadLine ());
Console.Write ("Enter the index to be swapped: ");
int index2 = Convert.ToInt32 (Console.ReadLine ());
SwapIndices (index1, index2);
Console.Write ("Swapped series of random numbers: ");
foreach (var item in randarr) Console.Write (item + " ");

void SwapIndices (int a, int b) => (randarr[a], randarr[b]) = (randarr[b], randarr[a]);