using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(StreamerDbContext context) : base(context)
        {
        }

        public async Task<Video> GetVideoByName(string name)
        {
            return await _context.Videos!.Where(v => v.Nombre == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Video>> GetVideoByUsername(string username)
        {
            return await _context.Videos!.Where(v => v.CreatedBy == username).ToListAsync();
        }
    }
}
