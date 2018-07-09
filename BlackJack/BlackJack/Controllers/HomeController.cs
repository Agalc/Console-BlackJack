using System.Web.Mvc;
using BlackJack.DAL.EF;
using BlackJack.DAL.Enteties;
using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Repositories;

namespace BlackJack.Controllers
{
  public class HomeController : Controller
  {
    private IRepository<UserDAL> db = new UserRepository(new BjContext());

    public ActionResult Index()
    {
      return View(ViewBag.User=db.GetAll());
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}