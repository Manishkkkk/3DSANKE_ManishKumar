
namespace Core.ScoreSystem
{

    public interface IScoreManager
    {
        int CurrentScore { get; }
        int HighScore { get; }
        void Reset();
    }
}