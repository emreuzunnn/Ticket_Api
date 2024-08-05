using api.Models;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class peoplecardsController
    {
        databaseController databaseController=new databaseController();

        [HttpPost("tckimlik")]
        public peoplecards cardscontrol(string tckimlik)
        {
            return databaseController.cards_query(tckimlik);
        }
    }
}
