using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;

StreamerDbContext dbContext = new();

await TrackingAndNotTraking();
//await QueyLinq();
//await QueryMethods();
//await QueryFilter();
//await AddNewRecods();
//getStreaming();


async Task TrackingAndNotTraking()
{
    var streamerWithTracking = await dbContext!.Streamers!.FirstOrDefaultAsync(x=> x.Id == 1);
    var streamerNoTracking = await dbContext!.Streamers!.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == 2);


    streamerWithTracking.Nombre = "Netflix Super";
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