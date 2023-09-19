using CloudSuite.Infrastructure.Data.Core.Context;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Modules.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Repositories.Core
{
    public class MediaRepository : IMediaRepository
    {

        protected readonly CloudSuiteDbContext Db;
        protected readonly DbSet<Media> DbSet;

        public MediaRepository(CloudSuiteDbContext context)
        {
            Db = context;
            DbSet = context.Medias;
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<Media> GetByCaption(string caption)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Caption == caption);
        }

        public async Task<Media> GetByFileName(string fileName)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.FileName == fileName);
        }

        public async Task<Media> GetByFileSize(int fileSize)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.FileSize == fileSize);
        }

        public async Task<IEnumerable<Media>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(Media media)
        {
            await Task.Run(() => {
                DbSet.Add(media);
                Db.SaveChanges();
            });
        }

        public void Update(Media media)
        {
            DbSet.Update(media);
        }

        public void Remove(Media media)
        {
            DbSet.Remove(media);
        }
    }
}
