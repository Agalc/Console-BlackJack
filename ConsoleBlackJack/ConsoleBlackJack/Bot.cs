using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackJack
{
  class Bot : User
  {
    public override void DecideWhetherTakeCard(Deck deck)
    {
      do
      {
        PutCardInHand(deck.DrawCard());
      } while ((this.Score <=19));
    }
  }
}
