using System;
using System.Data.Entity;
using BlackJack.DAL.Enteties;
using BlackJack.DAL.Enums;


namespace BlackJack.DAL.EF
{
  public class BjContext : DbContext
  {
    public DbSet<GameDAL> Games { get; set; }
    public DbSet<UserDAL> Users { get; set; }
    public DbSet<CardDAL> Cards { get; set; }
    public DbSet<RoundDAL> Rounds { get; set; }
    public DbSet<HandDAL> Hands { get; set; }

    static BjContext()
    {
      Database.SetInitializer(new StoreDbInitializer());
    }

    //public BjContext(string connectionString)
    //  : base(connectionString)
    //{ }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<BjContext>
    {
      protected override void Seed(BjContext db)
      {
        db.Users.Add(new UserDAL() { Id = 1, HandId = 1, Name = "Tom", Score = 21, Type = PlayerType.Player, RoundId = 1 });
        db.Users.Add(new UserDAL() { Id = 2, HandId = 2, Name = "Bot", Score = 19, Type = PlayerType.Dealer, RoundId = 1 });
        db.Users.Add(new UserDAL() { Id = 3, HandId = 3, Name = "Dealer", Score = 20, Type = PlayerType.Dealer, RoundId = 1 });
        db.Games.Add(new GameDAL() { Id = 1, DateTime = DateTime.Now });
        db.SaveChanges();
      }
    }
  }
}