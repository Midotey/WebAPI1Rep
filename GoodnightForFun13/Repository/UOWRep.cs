using GoodnightForFun13.Data;

namespace GoodnightForFun13.Repository
{
    public class UOWRep : IDisposable
    {
        private AppDbContext context;
        private NoteRep noteRep;
        private FolderRep folderRep;
        public NoteRep Notes
        {
            get
            {
                if (noteRep == null)
                    noteRep = new NoteRep(context);
                return noteRep;
            }
        }
        public FolderRep Folders
        {
            get
            {
                if (folderRep == null)
                    folderRep = new FolderRep(context);
                return folderRep;
            }
        }
        public UOWRep(AppDbContext context)
        {
            this.context = context;
        }
        public void Save()
        {
            context.SaveChanges();
        }


        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }





    }
}
