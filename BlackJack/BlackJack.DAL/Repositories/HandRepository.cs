using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.DAL.EF;
using BlackJack.DAL.Enteties;

namespace BlackJack.DAL.Repositories
{
  public class HandRepository
  {
    private BjContext db;

    public HandRepository(BjContext context)
    {
      db = context;
    }

    public IEnumerable<HandDAL> GetAll()
    {
      return db.Hands;
    }

    public HandDAL Get(int id)
    {
      return db.Hands.Find(id);
    }

    public void Create(HandDAL hand)
    {
      db.Hands.Add(hand);
    }

    public void Update(HandDAL hand)
    {
      db.Entry(hand).State = EntityState.Modified;
    }
    public IEnumerable<HandDAL> Find(Func<HandDAL, Boolean> predicate)
    {
      return db.Hands.Where(predicate).ToList();
    }
    public void Delete(int id)
    {
      HandDAL hand = db.Hands.Find(id);
      if (hand != null)
        db.Hands.Remove(hand);
    }
  }
}
