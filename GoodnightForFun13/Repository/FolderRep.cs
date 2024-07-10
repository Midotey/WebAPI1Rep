using GoodnightForFun13.Data;
using GoodnightForFun13.Interfaces;
using GoodnightForFun13.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodnightForFun13.Repository
{
    public class FolderRep : IRep<Folder>
    {
        private AppDbContext _context;
        public FolderRep(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Folder>> GetAll()
        {
            return await _context.Folders.Include(f => f.Notes).ToListAsync();
        }
        public async Task<Folder> Get(int id)
        {
            var folder = await _context.Folders.Include(f => f.Notes).FirstOrDefaultAsync(f => f.Id == id);
            if (folder == null)
                return null;
            return folder;
        }
        public async Task Add(Folder folder)
        {
            if (folder == null)
                return;
            await _context.Folders.AddAsync(folder);
        }
        public async Task Delete(int id)
        {
            var folder = await _context.Folders.FirstOrDefaultAsync(f => f.Id == id);
            if (folder == null)
                return;
            _context.Folders.Remove(folder);
        }
        public async Task Update(int id, Folder newFolder)
        {
            var folder = await _context.Folders.Include(f => f.Notes).FirstOrDefaultAsync(f => f.Id == id);
            if (folder == null)
                return;
            folder.Name = newFolder.Name;
            folder.Notes = newFolder.Notes;
        }
        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
