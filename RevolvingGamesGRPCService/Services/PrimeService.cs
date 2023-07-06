using Grpc.Core;
using RevolvingGamesGRPCService.Data;
using RevolvingGamesGRPCService.PrimeNumberProto;

namespace RevolvingGamesGRPCService.Services
{
    public class PrimeService : PrimeNumber.PrimeNumberBase
    {
        private readonly ILogger<PrimeService> _logger;

        public PrimeService(ILogger<PrimeService> logger)
        {
            _logger = logger;
        }

        public override Task<IsPrime> IsPrimeNumber(PrimeNumberModel request, ServerCallContext context)
        {
            // Check if prime number
            if(request.Number < 2)
            {
                return Task.FromResult(new IsPrime { IsPrime_ = false }); 
            }
            for(int  i = 2; i <= Math.Sqrt(request.Number); i++)
            {
                if(request.Number % i == 0)
                {
                    return Task.FromResult(new IsPrime { IsPrime_ = false });
                }
            }
            // If not prime number, check if among highest 10 then store
            bool result = PrimeNumbers.NewPrimeNumber(request.Number);
            // if timestamp 0, then store timestamp from request
            if (PrimeNumbers.timestamp == 0)
            {
                PrimeNumbers.timestamp = request.Timestamp;
            }else if(request.Timestamp - PrimeNumbers.timestamp > 1) // check if timestamp passed
            {
                // print highest 10 prime numbers when 1 second passed
                for (int i = 0; i < PrimeNumbers.highestNums.Length; i++)
                {
                    Console.Write($"{PrimeNumbers.highestNums[i]}, ");
                }
                Console.WriteLine();
            }
            return Task.FromResult(new IsPrime { IsPrime_ = true });
        }
    }
}
