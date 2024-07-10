using GoodnightForFun13.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GoodnightForFun13.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly UOWRep rep;
        public NoteController(UOWRep rep)
        {
            this.rep = rep;
        }


    }

}
