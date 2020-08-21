using Microsoft.AspNetCore.Mvc;
using ReplayFx.Models;

namespace ReplayFx.Controllers
{
    [Route("api/[controller]")]
    public class DbController : Controller
    {
        public IActionResult<GameData> InsertGameData()
        {

        }
    }
}
