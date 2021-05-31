using System;
using System.Collections.Generic;
using System.Text;
using L11.Context;

namespace L11.Models
{
    public class UnitOfWork : IDisposable
    {
        private MyDb db = new MyDb();
        private WorkersRepository workerRepository;
        private PlaneRepository planeRepository;

        public WorkersRepository Workers
        {
            get
            {
                if (workerRepository == null)
                    workerRepository = new WorkersRepository(db);
                return workerRepository;
            }
        }

        public PlaneRepository Planes
        {
            get
            {
                if (planeRepository == null)
                    planeRepository = new PlaneRepository(db);
                return planeRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
