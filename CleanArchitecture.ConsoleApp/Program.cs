using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;

StreamerDbContext dbContext = new();

await MultipleEntitiesQuery();
//await AddNewDirectorWithVideo();
//await AddNewActorWithVideo();
//await AddNewStreamerWithVideoId();
//await AddNewStreamerWithVideo();
//await TrackingAndNotTraking();
//await QueyLinq();
//await QueryMethods();
//await QueryFilter();
//await AddNewRecods();
//getStreaming();


async Task MultipleEntitiesQuery()
{
    //var VideoWithActors = await dbContext!.Videos!.Include(q => q.Actores).FirstOrDefaultAsync(q => q.Id ==1);

    //var Actores = await dbContext!.Actor!.Select(q => q.Nombre).ToListAsync();

    var VideoWithDirector = dbContext!.Videos!.Where(q => q.Director != null)
        .Include(q => q.Director).Select(q => new { Director_Mio = $"{q.Director.Nombre}  {q.Director.Apellido}", Movie = q.Nombre }  );

    foreach ( var video in VideoWithDirector )
    {
        Console.WriteLine($"{video.Movie} - {video.Director_Mio}");
    }
}

async Task AddNewDirectorWithVideo()
{

    var Actor = new Director 
    { 
        Nombre = "Lorenzo",
        Apellido = "Basteri",
        VideoId = 1
    };

    await dbContext.AddAsync(Actor);
    await dbContext.SaveChangesAsync();

}
async Task AddNewActorWithVideo()
{

    var Actor = new Actor 
    { 
        Nombre = "Brad",
        Apellido = "Pitt"
    };

    await dbContext.AddAsync(Actor);
    await dbContext.SaveChangesAsync();

    var VideoActor = new VideoActor
    {
        ActorId = Actor.Id,
        VideoId = 1
    
    };

    await dbContext.AddAsync(VideoActor);
    await dbContext.SaveChangesAsync();

}

async Task AddNewStreamerWithVideoId() {


    var BatmanForever = new Video
    {
        Nombre = "Batman Forever",
        StreamerId = 4
        
    };

    await dbContext.AddAsync(BatmanForever);
    await dbContext.SaveChangesAsync();

}

async Task AddNewStreamerWithVideo() {

    var Pantalla = new Streamer
    {
        Nombre = "Pantalla"
    };

    var HungerGame = new Video
    {
        Nombre = "Hunger Games",
        Streamer = Pantalla
        
    };

    await dbContext.AddAsync(HungerGame);
    await dbContext.SaveChangesAsync();

}


async Task TrackingAndNotTraking()
{
    var streamerWithTracking = await dbContext!.Streamers!.FirstOrDefaultAsync(x=> x.Id == 1);
    var streamerNoTracking = await dbContext!.Streamers!.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == 2);


    streamerWithTracking.Nombre = "Disney Super";
    streamerNoTracking.Nombre = "Amazon Plus";


    await dbContext.SaveChangesAsync();
}

async Task QueyLinq()
{
    Console.WriteLine($"Ingrese una compañia de streaming:");
    var streamingNombre = Console.ReadLine();

    var streamers = await (from i in dbContext!.Streamers! where EF.Functions.Like(i.Nombre, $"%{streamingNombre}%") select i).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");

    }

}

async Task QueryMethods()
{
    var streamer = dbContext!.Streamers!;

    var firstAsync = await streamer.Where(x => x.Nombre.Contains("a")).FirstAsync();   
    
    var firstOrDefaultAsync = await streamer.Where(x => x.Nombre.Contains("a")).FirstOrDefaultAsync();    

    var firstOrDefault_v2 = await streamer.FirstOrDefaultAsync(x => x.Nombre.Contains("a"));

    var singleAsync = await streamer.Where(x => x.Id == 1).SingleAsync();

    var singleOrDefaultAsync = await streamer.Where(x => x.Id == 1).SingleOrDefaultAsync();


    var resultado = await streamer.FindAsync(1);

}

async Task QueryFilter()
{

    Console.WriteLine($"Ingrese una compañia de streaming:");
    var streamingNombre = Console.ReadLine();    
    var streamers = await dbContext.Streamers.Where(x => x.Nombre.Equals(streamingNombre)).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }

    //var streamerPartialResults = await dbContext!.Streamers!.Where(x => x.Nombre.Contains(streamingNombre)).ToListAsync();
    var streamerPartialResults = await dbContext!.Streamers!.Where(x => EF.Functions.Like(x.Nombre, $"%{streamingNombre}%")).ToListAsync();

    foreach (var streamer in streamerPartialResults)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }

}

void getStreaming()
{
    var streamers = dbContext!.Streamers!.ToList(); 

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }

}

async Task AddNewRecods()
{
    Streamer streamer = new()
    {
        Nombre = "Disney",
        Url = "https://www.disney.com",
    };


    dbContext!.Streamers!.Add(streamer);
    await dbContext!.SaveChangesAsync();


    var movies = new List<Video>
{
    new Video
    {
        Nombre = "La cenicienta",
        StreamerId = streamer.Id,
    },
    new Video
    {
        Nombre = "101 dalmatas",
        StreamerId = streamer.Id,
    },
    new Video
    {
        Nombre = "El jorobado de Notredame",
        StreamerId = streamer.Id,
    },
    new Video
    {
        Nombre = "Star Wars",
        StreamerId = streamer.Id,
    }
};

    await dbContext.AddRangeAsync(movies);
    await dbContext!.SaveChangesAsync();
    
}