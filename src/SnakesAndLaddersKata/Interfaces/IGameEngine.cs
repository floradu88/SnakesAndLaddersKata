namespace SnakesAndLaddersKata.Interfaces
{
    public interface IGameEngine
    {
        bool Start();
        bool Started { get; }
        int PlayerNumber { get; }
    }
}
