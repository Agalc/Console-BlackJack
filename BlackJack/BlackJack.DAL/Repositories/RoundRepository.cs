using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.DAL.EF;
using BlackJack.DAL.Enteties;

namespace BlackJack.DAL.Repositories
{
  public class RoundRepository
  {
    private BjContext db;

    public RoundRepository(BjContext context)
    {
      db = context;
    }

    public IEnumerable<RoundDAL> GetAll()
    {
      return db.Rounds;
    }

    public RoundDAL Get(int id)
    {
      return db.Rounds.Find(id);
    }

    public void Create(RoundDAL round)
    {
      db.Rounds.Add(round);
    }

    public void Update(RoundDAL round)
    {
      db.Entry(round).State = EntityState.Modified;
    }
    public IEnumerable<RoundDAL> Find(Func<RoundDAL, Boolean> predicate)
    {
      return db.Rounds.Where(predicate).ToList();
    }
    public void Delete(int id)
    {
      RoundDAL round = db.Rounds.Find(id);
      if (round != null)
        db.Rounds.Remove(round);
    }
  }
}
