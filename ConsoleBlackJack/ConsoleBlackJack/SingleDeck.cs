using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackJack
{
  class SingleDeck : Deck
  {
    public SingleDeck() : base()
    { }
    protected override void CreateDeck()
    {
      for (var i = 0; i < 4; i++)
      {
        for (var j = 0; j < 13; j++)
        {
          // +2 к значению из-за None и отсутствия единицы в колоде, +1 к масти из-за None
          _cards.Add(new Card() { Face = (Face)j + 1, Suit = (Suit)i + 1, Value = Math.Min(j + 2, 10) });
        }
        _cards[_cards.Count - 1].Value = 11;//для туза задать 11
      }
      Shuffle();
    }
  }
}
