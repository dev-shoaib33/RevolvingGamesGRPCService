using Grpc.Core;
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
            return Task.FromResult(new IsPrime { IsPrime_ = true });
        }
    }
}
