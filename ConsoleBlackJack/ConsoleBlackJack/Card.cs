using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackJack
{
  public enum Face
  {
    None = 0,
    Two = 1,
    Three = 2,
    Four = 3,
    Five = 4,
    Six = 5,
    Seven = 6,
    Eight = 7,
    Nine = 8,
    Ten = 9,
    Fool = 10,
    Queen = 11,
    King = 12,
    Ace = 13
  }

  public enum Suit
  {
    None = 0,
    Hearts,
    Diamonds,
    Spades,
    Clubs
  }
  class Card
  {
    public Suit Suit { get; set; }
    public Face Face { get; set; }
    public int Value { get; set; }

    public override string ToString()
    {
      return string.Format($"{Face}-{Suit} {Value}");
    }
  }
}
