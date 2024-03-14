namespace DefaultNamespace
{
    public static class ScoreComputer
    {
        public static int PlayerScore { get; private set; }
        public static int BotScore { get; private set; }
        
        public static void AddPlayerScore()
        {
            PlayerScore++;
        }
        
        public static void AddBotScore()
        {
            BotScore++;
        }
    }
}