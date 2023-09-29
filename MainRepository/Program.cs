while (true) {
   Console.Write ("Enter the total number of votes by the member ");
   string input = Console.ReadLine ().ToLower ().Replace (" ", "");
   if (input.ToLower () == "q") break;
   if (input == "") Console.WriteLine ("Enter the valid input");
   else {
      VotingContest (input, out int totalVotes);
      Console.WriteLine ($"The total votes is {totalVotes}");
   }
}

static void VotingContest (string s, out int votes) {
   Dictionary<char, int> voteCount = new ();
   foreach (char c in s) {
      if (voteCount.ContainsKey (c)) voteCount[c]++;
      else voteCount[c] = 1;
   }
   var winner = voteCount.OrderByDescending (x => x.Value).First ();
   Console.WriteLine ($"The winner is {winner.Key}");
   votes = winner.Value;
}