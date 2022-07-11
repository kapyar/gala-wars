using Game.Controllers.Leaderboard.Data;
using Services;
using Services.Files;

namespace Game.Controllers.Leaderboard
{
    public class LeaderboardController : AbstractSerializableController<MutableLeaderboardData>
    {
        public ReadOnlyLeaderboardData Data => _data;

        public LeaderboardController(IFileService fileService) : base(fileService)
        {
            LoadData();
        }

        protected override string Filename => "leaderboard_data";

        protected override void SetInitialValues()
        {
            _data.Name = "";
            _data.Score = 0;
        }

        public void CheckAndSaveNewHighScore(string name, int score)
        {
            if (score > _data.Score)
            {
                _data.Name = name;
                _data.Score = score;

                SaveData();
            }
        }
    }
}