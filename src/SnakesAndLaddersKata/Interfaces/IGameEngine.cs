namespace SnakesAndLaddersKata.Interfaces
{
    public interface IGameEngine
    {
        bool Start();
        bool Started { get; }
        int PlayerNumber { get; }
        bool Finished { get; }
        int Winner { get; }
        int RollDice();
        double GetPlayerProgress(int playerNumber);
    }
}
