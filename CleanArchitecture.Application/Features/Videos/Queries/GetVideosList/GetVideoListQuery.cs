using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideoListQuery : IRequest<List<VideosVm>>
    {
        public string _Username { get; set; } = string.Empty;


        public GetVideoListQuery(string username) 
        {
            this._Username = username ?? throw new ArgumentNullException(nameof(username));

        }


    }
}
