namespace BlackJack.Enums
{
  public enum PlayerResult//результат игрока
  {
    None = 0,
    BlackJack = 1,
    Busted = 2//перебор
  }

  public enum Face//лицо карты
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

  public enum Suit//масть
  {
    None = 0,
    Hearts = 1,
    Diamonds = 2,
    Spades = 3,
    Clubs = 4
  }
}
