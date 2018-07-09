using System;
using System.Collections.Generic;

namespace ConsoleBlackJack
{
  class Game
  {
    private static List<User> _users = new List<User>(7);
    private static ConsolePrinter _printer = new ConsolePrinter();

    public static void Setup()//регистрация игрока и добавление ботов
    {
      //Регистрация игрока
      _printer.Print("Enter your name, please: ");
      _users.Add(new Player() { Name = _printer.ReadLine() });
      _printer.Print("Please enter a count of bots (less than 5): ");
      int botCount;
      string str;
      do
      {
        str = _printer.ReadLine();
        try
        {
          botCount = Convert.ToInt16(str);
        }
        catch (Exception)
        {
          throw new Exception("Wrong charecter");
        }

        if (botCount <= 5)
        {
          break;
        }
        _printer.Print("Wrong number, try again: ");
      } while (true);

      //Добавление ботов в список игроков
      for (var i = 0; i < botCount; i++)
      {
        _users.Add(new Bot() { Name = "Bot " + (i + 1) });
      }
      //Добавить дилера в конец, т.к. он последний берет карты
      _users.Add(new Dealer() { Name = "Dealer" });
    }

    public static void PlaceCards(Deck deck)//раздача карт в руки
    {
      foreach (var u in _users)
      {
        //По две карты
        u.PutCardInHand(deck.DrawCard());
        u.PutCardInHand(deck.DrawCard());
      }
    }

    public static void CheckScore(User user)//Проверить счет
    {
      if (user.Score > 21)
      {
        _printer.Print($"{user.Name}'s score is {user.Score} and exceeds 21\n");//Перебор
        user.Result = PlayerResult.Busted;
      }
      if (user.Score == 21)
      {
        _printer.Print($"{user.Name} has a blackjack!\n");//Блэкджек
        user.Result = PlayerResult.BlackJack;
      }
    }

    public static void SumUp()//Результат матча
    {
      //Если у игрока не перебор и у него больше очков чем у дилера, то он победил
      //Или же если у игрока не перебор, а у дилера перебор, то он также победил
      if (_users[0].Score > _users[_users.Count - 1].Score && _users[0].Result != PlayerResult.Busted ||
          _users[0].Result != PlayerResult.Busted && _users[_users.Count - 1].Result == PlayerResult.Busted)
      {
        _printer.Print($"{_users[0].Name} has won the Dealer");
      }
      //Если у дилера не перебор и у него больше очков чем у игрока, то он победил
      //Если же у игрока пербеор, то он также победил
      else if (_users[_users.Count - 1].Result != PlayerResult.Busted && _users[0].Score < _users[_users.Count - 1].Score ||
               _users[0].Result == PlayerResult.Busted)
      {
        _printer.Print($"Dealer has won the player {_users[0].Name}");
      }

      else if (_users[0].Score == _users[_users.Count - 1].Score)
      {
        _printer.Print("Push");
      }
    }

    public static void PrintStats()//Вывод счета и карт в руке каждого игрока
    {
      foreach (var u in _users)
      {
        Console.ForegroundColor = ConsoleColor.Cyan;
        _printer.Print(u.ToString());
        Console.ForegroundColor = ConsoleColor.Red;
        CheckScore(u);
      }
    }

    public static void Play()//ход игры
    {
      //Новая колода
      Deck deck = new SingleDeck();
      //Регистрация и добавление ботов
      Setup();
      //Раздача
      PlaceCards(deck);
      _printer.Print(_users[0].ToString());
      //Добор карт
      foreach (var u in _users)
        u.DecideWhetherTakeCard(deck);
      //Вывод карт каждого игрока
      PrintStats();

      SumUp();//Итог матча
      _printer.Wait();
    }
  }
}
