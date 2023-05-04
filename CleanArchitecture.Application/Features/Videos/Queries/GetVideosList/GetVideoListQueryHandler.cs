using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideoListQueryHandler : IRequestHandler<GetVideoListQuery, List<VideosVm>>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public GetVideoListQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<List<VideosVm>> Handle(GetVideoListQuery request, CancellationToken cancellationToken)
        {
             var videoList = await _videoRepository.GetVideoByUsername(request._Username);
            return _mapper.Map<List<VideosVm>>(videoList);

        }
    }
}
