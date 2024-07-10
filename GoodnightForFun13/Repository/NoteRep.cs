using GoodnightForFun13.Data;
using GoodnightForFun13.Interfaces;
using GoodnightForFun13.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodnightForFun13.Repository
{
    public class NoteRep : IRep<Note>
    {
        private AppDbContext _context;
        public NoteRep(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Note>> GetAll()
        {
            return await _context.Notes.Include(n => n.Folder).ToListAsync();
        }
        public async Task<Note> Get(int id)
        {
            var note = await _context.Notes.Include(n => n.Folder).FirstOrDefaultAsync(n => n.Id == id);
            if (note == null)
                return null;
            return note;
        }
        public async Task Add(Note note)
        {
            if (note == null)
                return;
            await _context.Notes.AddAsync(note);
        }
        public async Task Delete(int id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
            if (note == null)
                return;
            _context.Notes.Remove(note);
        }
        public async Task Update(int id, Note newNote)
        {
            var note = await _context.Notes.Include(n => n.Folder).FirstOrDefaultAsync(n => n.Id == id);
            if (note == null)
                return;
            note.Title = newNote.Title;
            note.Text = newNote.Text;
            note.FolderId = newNote.FolderId;
            note.Folder = newNote.Folder;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
