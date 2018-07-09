using System.Collections.Generic;

namespace ConsoleBlackJack
{
  enum PlayerResult//результат игрока
  {
    None = 0,
    BlackJack = 1,
    Busted = 2//перебор
  }
  abstract class User
  {
    public string Name { set; get; } = "Bot";
    public int Score { private set; get; }
    public PlayerResult Result { set; get; }
    protected List<Card> Hand { set; get; } = new List<Card>();
    public abstract void DecideWhetherTakeCard(Deck deck);//Решить, нужно ли брать карту

    public void PutCardInHand(Card c)//Добавить карту в руку
    {
      Hand.Add(c);//Добавить карту в руку
      //Если добавляем туз и получается перебор, то туз будет стоить 1 очко
      if (c.Face == Face.Ace && Score + 11 > 21)
      {
        Hand[Hand.Count - 1].Value = 1;
        Score += 1;
      }
      //Иначе просто добавляем значение к счету
      else
      {
        Score += c.Value;
      }
    }

    public override string ToString()
    {
      string res = $"User {Name} has cards in hand: \n";
      foreach (var h in Hand)
      {
        res += h + "\n";
      }
      res += $"Score is {Score}\n";
      return res;
    }
  }
}
