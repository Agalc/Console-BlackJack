using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackJack
{
  abstract class Deck
  {

    protected readonly List<Card> _cards = new List<Card>();

    protected Deck()
    {
      CreateDeck();
    }

    protected abstract void CreateDeck();//Создание колоды

    public void Shuffle()//перемешивание колоды
    {
      Random rng = new Random();
      int n = _cards.Count;
      while (n > 1)
      {
        n--;
        int k = rng.Next(n + 1);
        Card card = _cards[k];
        _cards[k] = _cards[n];
        _cards[n] = card;
      }

    }

    public Card DrawCard()//взять карту
    {
      Card takenCard = _cards[_cards.Count - 1];
      _cards.RemoveAt(_cards.Count - 1);
      return takenCard;
    }

    //для тестов
    //public void Display()
    //{
    //  var counter = 1;
    //  foreach (var card in _cards)
    //  {
    //    Console.WriteLine(card.Face + " " + card.Suit + " " + card.Value);
    //    if (counter % 13 == 0)
    //      Console.WriteLine();
    //    counter++;
    //  }
    //}
  }
}
