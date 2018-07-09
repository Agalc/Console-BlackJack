using BlackJack.DAL.Enums;

namespace BlackJack.DAL.Enteties
{
  public class UserDAL
  {
    public int? Id { set; get; }
    public string Name { set; get; }
    public int? Score { get; set; }
    public PlayerType Type { get; set; }

    public int? HandId { set; get; }
    public int? RoundId { set; get; }
  }
}
