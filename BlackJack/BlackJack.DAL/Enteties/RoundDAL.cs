namespace BlackJack.DAL.Enteties
{
  public class RoundDAL
  {
    public int? Id { set; get; }

    public int? GameId { set; get; }
    public int? UserId { set; get; }
    public int? WinnerId { set; get; }
  }
}
