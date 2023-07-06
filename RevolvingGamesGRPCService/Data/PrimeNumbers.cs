using Google.Protobuf.WellKnownTypes;

namespace RevolvingGamesGRPCService.Data
{
    // Static Prime Numbers Class to store highest 10 prime numbers and store new prime numbers
    static public class PrimeNumbers
    {
        static public Int64[] highestNums = new Int64[10];
        static public Int64 timestamp = 0; // Check if it's been 1 second, if yes, then we print list of highest 10


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
