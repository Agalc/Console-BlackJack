using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.DAL.EF;
using BlackJack.DAL.Enteties;
using BlackJack.DAL.Interfaces;

namespace BlackJack.DAL.Repositories
{
  public class UserRepository : IRepository<UserDAL>
  {
    private BjContext db;
    public UserRepository(BjContext context)
    {
      db = context;
    }

    public IEnumerable<UserDAL> GetAll()
    {
      return db.Users;
    }

    public UserDAL Get(int id)
    {
      return db.Users.Find(id);
    }

    public void Create(UserDAL user)
    {
      db.Users.Add(user);
    }

    public void Update(UserDAL user)
    {
      db.Entry(user).State = EntityState.Modified;
    }

    public IEnumerable<UserDAL> Find(Func<UserDAL, Boolean> predicate)
    {
      return db.Users.Where(predicate).ToList();
    }

    public void Delete(int id)
    {
      UserDAL user = db.Users.Find(id);
      if (user != null)
        db.Users.Remove(user);
    }
  }
}
