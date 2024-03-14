namespace DefaultNamespace
{
    public static class ScoreComputer
    {
        public static int PlayerScore { get; set; }
        public static int BotScore { get; set; }
        
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