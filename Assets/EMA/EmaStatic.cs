
namespace EMA
{
    public static class EmaStatic
    {
        public static bool IsGamePaused = true;
        public static int FinalMultiplier;
        public static int CoinAmount;
        public static int DoTweenId;

        public static void ResetValues()
        {
            IsGamePaused = true;
            DoTweenId = 0;
            CoinAmount = 0;
        }
    }
}
