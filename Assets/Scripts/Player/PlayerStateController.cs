using System.Linq;
using Currency;
using Player.Boosters.Signals;
using Services;
using Services.Files;
using UI.EnterNameController.Signals;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerStateController : AbstractSerializableController<PlayerData>
    {
        protected override string Filename => "player_data";

        private readonly SignalBus _signalBus;

        public CurrencyData CoinsBank { get; private set; }

        public CurrencyData ExperienceBank { get; private set; }

        public PlayerStateController(IFileService fileService, SignalBus signalBus) : base(fileService)
        {
            _signalBus = signalBus;

            LoadData();
            InitBank();

            _signalBus.Subscribe<SubmitNameSignal>(OnNameSubmitted);
        }

        private void OnNameSubmitted(SubmitNameSignal signal)
        {
            _data.Name = signal.Name;
        }

        private void InitBank()
        {
            CoinsBank = _data.Bank.FirstOrDefault(x => x.Type == CurrencyType.Coins);
            CoinsBank.OnAmountChanged += OnCoinBalanceChanged;

            ExperienceBank = _data.Bank.FirstOrDefault(x => x.Type == CurrencyType.Experience);
            ExperienceBank.OnAmountChanged += OnExperienceBalanceChanged;
        }


        #region Debug

        public void AddCoins()
        {
            CoinsBank.Amount += Random.Range(1, 5);
        }

        public void AddExp()
        {
            ExperienceBank.Amount += Random.Range(100, 1500);
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