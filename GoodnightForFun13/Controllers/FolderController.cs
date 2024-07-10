using GoodnightForFun13.Data;
using GoodnightForFun13.Models;
using GoodnightForFun13.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodnightForFun13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly UOWRep rep;
        public FolderController(AppDbContext rep)
        {
            this.rep = new UOWRep(rep);
        }

        [HttpGet]
        public async Task<IEnumerable<Folder>> GetFolders()
        {
            return await rep.Folders.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<Folder> GetFolder(int id)
        {
            var folder = await rep.Folders.Get(id);
            if (folder == null)
                return null;
            return folder;
        }
        [HttpPost/*("{name}")*/]
        public async Task<IActionResult> AddFolder(/*Folder folder*/string name)
        {
            //if (string.IsNullOrEmpty(name) == true)
            //    return;

            Folder folder = new Folder(name);

            if (!ModelState.IsValid)
                return BadRequest();
            /*await*/ rep.Folders.Add(folder);
            rep.Save();
            return Ok();
        }
        [HttpDelete]
        public async Task DeleteFolder(int id)
        {
            await rep.Folders.Delete(id);
            rep.Save();
        }
        [HttpPut("{id},{newName}")]
        public async Task UpdateFolder(int id, string newName)
        {
            await rep.Folders.Update(id, new Folder(newName));
            rep.Save();
        }

    }
}
