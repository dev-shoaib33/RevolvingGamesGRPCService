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
    // Start stopwatch to calculate RTT
    stopwatch.Restart();
    int primeNumber = rnd.Next(1, 1001); // Get Random number between 1 and 1000

    var primeNumberData = new PrimeNumberModel
    {
        Id = count,
        Timestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds(),
        Number = primeNumber
    };
    count++;

    // Send request to server to check if prime or not
    var serverResponse = await client.IsPrimeNumberAsync(primeNumberData);
    stopwatch.Stop(); // Stop stopwatch on response

    // Check if response received else show message
    if(serverResponse != null)
    {
        // Render response and RTT
        Console.WriteLine($"Is {primeNumber} a Prime Number: {serverResponse.IsPrime_}");
        Console.WriteLine($"Time Taken: {stopwatch.ElapsedMilliseconds}");
    }
    else
    {
        Console.WriteLine("Response Missing!");
    }
}