using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastruture;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.Create
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {

        //private readonly IStreamerRepository _streamerRepository;
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
        {
            //_streamerRepository = streamerRepository;
            _unitofWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);
            //var newStreamer = await _streamerRepository.AddAsync(streamerEntity);

            _unitofWork.StreamerRepository.AddEntity(streamerEntity);

            var  result = await _unitofWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el record de streamer");
            }

            _logger.LogInformation($"Streamer {streamerEntity.Nombre} fue creado exitosamente");

            await SendEmail(streamerEntity);

            return streamerEntity.Id;

        }

        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email
            {
                To = "andresfetiz@gmail.com",
                Body = $"La compañia de estreamer {streamer.Nombre} se creo correctamente",
                Subject = "Mensaje de alerta"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errores enviando el email del streamer {streamer.Nombre}");
            }

        }


    }
}
