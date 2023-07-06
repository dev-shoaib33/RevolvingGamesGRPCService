using Google.Protobuf.WellKnownTypes;

namespace RevolvingGamesGRPCService.Data
{
    static public class PrimeNumbers
    {
        static public Int64[] highestNums = new Int64[10];
        static public Int64 timestamp = 0;

        static public bool NewPrimeNumber(Int64 number)
        {
            if(number > highestNums[9])
            {
                highestNums[9] = number;
                highestNums = highestNums.OrderByDescending(x => x).ToArray();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
