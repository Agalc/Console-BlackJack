using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.DAL.EF;
using BlackJack.DAL.Enteties;

namespace BlackJack.DAL.Repositories
{
  public class CardRepository
  {
    private BjContext db;

    public CardRepository(BjContext context)
    {
      db = context;
    }

    public IEnumerable<CardDAL> GetAll()
    {
      return db.Cards;
    }

    public CardDAL Get(int id)
    {
      return db.Cards.Find(id);
    }

    public void Create(CardDAL card)
    {
      db.Cards.Add(card);
    }

    public void Update(CardDAL card)
    {
      db.Entry(card).State = EntityState.Modified;
    }
    public IEnumerable<CardDAL> Find(Func<CardDAL, Boolean> predicate)
    {
      return db.Cards.Where(predicate).ToList();
    }
    public void Delete(int id)
    {
      CardDAL card = db.Cards.Find(id);
      if (card != null)
        db.Cards.Remove(card);
    }
  }
}
