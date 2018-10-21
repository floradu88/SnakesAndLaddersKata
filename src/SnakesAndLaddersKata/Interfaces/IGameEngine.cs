namespace SnakesAndLaddersKata.Interfaces
{
    public interface IGameEngine
    {
        bool Start();
        bool Started { get; }
        int PlayerNumber { get; }
        int RollDice();
        double GetPlayerProgress(int playerNumber);
    }
}
