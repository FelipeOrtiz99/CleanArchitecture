using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastruture;
using CleanArchitecture.Application.Features.Streamers.Commands.Create;
using CleanArchitecture.Application.Features.Streamers.Commands.Update;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Infrastructure.Repositories;
using CleanArtchitecture.Application.UnitTests.Mocks;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CleanArtchitecture.Application.UnitTests.Features.Streamers.UpdateStreamer
{
    public class UpdateStreamerCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<IEmailService> _emailService;
        private readonly Mock<ILogger<UpdateStreamerCommandHandler>> _logger;

        public UpdateStreamerCommandHandlerXUnitTests()
        {

            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _emailService = new Mock<IEmailService>();
            _logger = new Mock<ILogger<UpdateStreamerCommandHandler>>();

            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);

        }

        [Fact]
        public async Task UpdateStreamerCommand_InputStreamer_ReturnsUnit()
        {
            var streamerInput = new UpdateStreamerCommand
            {
                Id = 8001,
                Nombre = "Vaxi Stream Max",
                Url = "maximo.com"
            };

            var handler = new UpdateStreamerCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(streamerInput, CancellationToken.None);

        }

    }
}
