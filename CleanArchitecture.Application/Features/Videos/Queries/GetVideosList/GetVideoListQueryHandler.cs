using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideoListQueryHandler : IRequestHandler<GetVideoListQuery, List<VideosVm>>
    {
        //private readonly IVideoRepository _videoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetVideoListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_videoRepository = videoRepository;
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        }

        public async Task<List<VideosVm>> Handle(GetVideoListQuery request, CancellationToken cancellationToken)
        {
             var videoList = await _unitOfWork.VideoRepository.GetVideoByUsername(request._Username);
            return _mapper.Map<List<VideosVm>>(videoList);

        }
    }
}
