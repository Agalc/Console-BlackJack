namespace ConsoleBlackJack
{
  class Player : User
  {
    private static ConsolePrinter _printer = new ConsolePrinter();
    public override void DecideWhetherTakeCard(Deck deck)
    {
      do
      {
        if (Result == PlayerResult.BlackJack)
        {
          _printer.Print($"You have a blackjack");
        }
        _printer.Print("Do You want to draw another one? y/n");
        string ch = _printer.ReadLine();
        if (ch[0] == 'y')
        {
          PutCardInHand(deck.DrawCard());
          _printer.Print(ToString());
        }
        else break;
      } while (Score<21);
    }
  }
}
