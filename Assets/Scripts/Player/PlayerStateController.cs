using System.Linq;
using Currency;
using Player.Boosters.Signals;
using Services;
using Services.Files;
using Zenject;

namespace Player
{
    public class PlayerStateController : AbstractSerializableController<PlayerData>
    {
        protected override string Filename => "player_data";

        private readonly SignalBus _signalBus;

        private readonly CurrencyData _coinsBank;
        private readonly CurrencyData _experienceBank;

        public PlayerStateController(IFileService fileService, SignalBus signalBus) : base(fileService)
        {
            _signalBus = signalBus;

            LoadData();

            _coinsBank = _data.Bank.FirstOrDefault(x => x.Type == CurrencyType.Coins);
            _coinsBank.OnAmountChanged += OnCoinBalanceChanged;

            _experienceBank = _data.Bank.FirstOrDefault(x => x.Type == CurrencyType.Experience);
            _experienceBank.OnAmountChanged += OnExperienceBalanceChanged;
        }


        #region Debug

        public void AddCoins()
        {
            _coinsBank.Amount += 100;
        }

        #endregion


        protected override void SetInitialValues()
        {
            var dto = new PlayerDto
            {
                HighScore = 0
            };

            dto.Bank.Add(new CurrencyData
            {
                Type = CurrencyType.Coins,
                Amount = 100
            });

            dto.Bank.Add(new CurrencyData
            {
                Type = CurrencyType.Experience,
                Amount = 200
            });

            var data = new PlayerData();
            data.FromDto(dto);
            _data = data;
        }

        private void OnExperienceBalanceChanged(int newAmount)
        {
            var signal = new PlayerEarnCurrencySignal
            {
                Type = CurrencyType.Experience,
                Amount = newAmount
            };

            _signalBus.Fire(signal);
        }

        private void OnCoinBalanceChanged(int newAmount)
        {
            var signal = new PlayerEarnCurrencySignal
            {
                Type = CurrencyType.Coins,
                Amount = newAmount
            };

            _signalBus.Fire(signal);
        }
    }
}