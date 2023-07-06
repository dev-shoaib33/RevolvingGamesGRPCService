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
            bool result = PrimeNumbers.NewPrimeNumber(request.Number);
            if (PrimeNumbers.timestamp + request.Timestamp > 1)
            {
                PrimeNumbers.timestamp = 0;
                for(int i = 0; i<PrimeNumbers.highestNums.Length; i++)
                {
                    Console.Write($"{PrimeNumbers.highestNums[i]}, ");
                }
                Console.WriteLine();
            }
            return Task.FromResult(new IsPrime { IsPrime_ = true });
        }
    }
}
