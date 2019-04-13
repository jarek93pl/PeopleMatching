using PeopleMatching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeopleMatching.Logic;
namespace PeopleMatching.Controllers
{
    public class HomeController : Controller
    {
        const string KeyMatcherData = "PeopleMatching.Controllers.HomeController.MatcherData";
        public MatcherData SesionMatcherData
        {
            get
            {
                MatcherData matcherData = Session[KeyMatcherData] as MatcherData;
                if (matcherData == null)
                {
                    matcherData = new MatcherData();
                    Session[KeyMatcherData] = matcherData;
                    return matcherData;
                }
                else
                {
                    return matcherData;
                }

            }
        }
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Men");
        }

        [HttpGet()]
        public ActionResult Men()
        {
            if (SesionMatcherData.Men == null)
            {
                return View();
            }
            else
            {
                return FindNextPage();
            }
        }
        [HttpPost()]
        public ActionResult Men(Men men)
        {
            return ComonPersonPost(men);
        }

        [HttpGet()]
        public ActionResult Women()
        {
            if (SesionMatcherData.Women == null)
            {
                return View();
            }
            else
            {
                return FindNextPage();
            }
        }
        [HttpPost()]
        public ActionResult Women(Women Women)
        {
            return ComonPersonPost(Women);
        }
        [HttpGet()]
        public ActionResult Result()
        {
            MatcherData matcherData = SesionMatcherData;
            return FindNextPage(true);
        }
        [HttpGet()]
        public PartialViewResult PeopleData()
        {
            return PartialView();
        }
        private ActionResult ComonPersonPost(Person person)
        {
            if (!Validation.ValidationPerson(person, ModelState))
            {
                return View(person);
            }
            else
            {
                if (person is Men men)
                {
                    SesionMatcherData.Men = men;
                }
                else if (person is Women Women)
                {
                    SesionMatcherData.Women = Women;
                }
                return FindNextPage();
            }
        }
        private ActionResult FindNextPage(bool isResult = false)
        {
            MatcherData matcherData = SesionMatcherData;
            if (matcherData.Men == null)
            {
                return RedirectToAction("Men");
            }
            else if (matcherData.Women == null)
            {
                return RedirectToAction("Women");
            }
            else if (isResult)
            {
                matcherData.Matched = MatcherPeople.MatchCouple(matcherData.Men, matcherData.Women);
                return View(matcherData);
            }
            else
            {
                return RedirectToAction("Result");
            }
        }
    }
}