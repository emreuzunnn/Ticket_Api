using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class people_cards_add
    {
        databaseController databaseController =new databaseController();


        [HttpPost]
        public String add_cards(peoplecards cards)
        {
            try
            {
                databaseController.add_cards(cards);
                return "Sucsess";
            }
            catch (Exception e) { return "Failed " + e.Message; }
            
        }
    }
}
