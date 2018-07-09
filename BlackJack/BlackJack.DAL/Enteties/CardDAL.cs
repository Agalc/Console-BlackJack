using BlackJack.DAL.Enums;

namespace BlackJack.DAL.Enteties
{
  public class CardDAL
  {
    public int? Id { set; get; }

    public Face Face { set; get; }
    public Suit Suit { set; get; }
  }
}
