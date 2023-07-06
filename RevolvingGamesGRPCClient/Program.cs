using Grpc.Net.Client;
using RevolvingGamesGRPCClient;
using System.Diagnostics;
using System.Numerics;

var channel = GrpcChannel.ForAddress("http://localhost:5236");
var client = new PrimeNumber.PrimeNumberClient(channel);

Random rnd = new();

Int64 count = 0;
var stopwatch = new Stopwatch();

while (true)
{
    stopwatch.Restart();
    int primeNumber = rnd.Next(1, 1001);

    var primeNumberData = new PrimeNumberModel
    {
        Id = count,
        Timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(),
        Number = primeNumber
    };
    count++;
    var serverResponse = await client.IsPrimeNumberAsync(primeNumberData);
    stopwatch.Stop();
    if(serverResponse != null)
    {
        Console.WriteLine($"Is {primeNumber} a Prime Number: {serverResponse.IsPrime_}");
        Console.WriteLine($"Time Taken: {stopwatch.ElapsedMilliseconds}");
    }
    else
    {
        Console.WriteLine("Response Missing!");
    }
}