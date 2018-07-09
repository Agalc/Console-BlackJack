using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.DAL.EF;
using BlackJack.DAL.Enteties;


namespace BlackJack.DAL.Repositories
{
  public class GameRepository
  {
    private BjContext db;

    public GameRepository(BjContext context)
    {
      this.db = context;
    }

    public IEnumerable<GameDAL> GetAll()
    {
      return db.Games;
    }

    public GameDAL Get(int id)
    {
      return db.Games.Find(id);
    }

    public void Create(GameDAL game)
    {
      db.Games.Add(game);
    }

    public void Update(GameDAL game)
    {
      db.Entry(game).State = EntityState.Modified;
    }
    public IEnumerable<GameDAL> Find(Func<GameDAL, Boolean> predicate)
    {
      return db.Games.Where(predicate).ToList();
    }
    public void Delete(int id)
    {
      GameDAL game = db.Games.Find(id);
      if (game != null)
        db.Games.Remove(game);
    }
  }
}
