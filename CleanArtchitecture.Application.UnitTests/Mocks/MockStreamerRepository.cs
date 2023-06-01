using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArtchitecture.Application.UnitTests.Mocks
{
    public static class MockStreamerRepository
    {
        public static void AddDataStreamerRepository(StreamerDbContext streamerDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var streamer = fixture.CreateMany<Streamer>().ToList();

            streamer.Add(fixture.Build<Streamer>()
                .With(tr => tr.Id, 8001)
                .Without(tr => tr.Videos)
                .Create()
                );

            streamerDbContextFake.Streamers!.AddRange(streamer);
            streamerDbContextFake.SaveChanges();

        }
    }
}
