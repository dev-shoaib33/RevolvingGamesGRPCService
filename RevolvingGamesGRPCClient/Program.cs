using Grpc.Net.Client;
using RevolvingGamesGRPCClient;
using System.Numerics;

var channel = GrpcChannel.ForAddress("http://localhost:5236");
var client = new PrimeNumber.PrimeNumberClient(channel);

Random rnd = new();

Int64 count = 0;

while (true)
{
    int primeNumber = rnd.Next(1, 1001);

    var primeNumberData = new PrimeNumberModel
    {
        Id = count,
        Timestamp = 2,
        Number = primeNumber
    };
    count++;
    var serverResponse = await client.IsPrimeNumberAsync(primeNumberData);
    Console.WriteLine($"Is {primeNumber} a Prime Number: {serverResponse.IsPrime_}");
}