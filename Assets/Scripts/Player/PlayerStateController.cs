using System.Linq;
using Currency;
using GameState;
using Player.Boosters.Signals;
using Player.Data;
using Player.Signals;
using Services;
using Services.Files;
using UI.EnterNameController.Signals;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerStateController : AbstractSerializableController<MutablePlayerData>
    {
        public ReadOnlyPlayerData PlayerData => _data;
        protected override string Filename => "player_data";


        private readonly SignalBus _signalBus;
        private MutableCurrencyData _coinsBank;
        private MutableCurrencyData _experienceBank;


        public PlayerStateController(IFileService fileService, SignalBus signalBus) : base(fileService)
        {
            _signalBus = signalBus;

            LoadData();
            InitBank();

            _signalBus.Subscribe<SubmitNameSignal>(OnNameSubmitted);
            _signalBus.Subscribe<SaveDataSignal>(OnSaveData);
        }

        private void OnSaveData(SaveDataSignal signal)
        {
            if (_data.HighScore < _experienceBank.Amount)
            {
                _data.SetHighScore(_experienceBank.Amount);
            }

            SaveData();
        }

        private void OnNameSubmitted(SubmitNameSignal signal)
        {
            _data.SetName(signal.Name);
        }

        private void InitBank()
        {
            _coinsBank = _data.Bank.FirstOrDefault(x => x.Id == CurrencyType.Coins);
            _coinsBank.OnAmountChanged += OnCoinBalanceChanged;

            _experienceBank = _data.Bank.FirstOrDefault(x => x.Id == CurrencyType.Experience);
            _experienceBank.OnAmountChanged += OnExperienceBalanceChanged;
        }


        #region Debug

        public void AddCoins()
        {
            _coinsBank.SetAmount(_coinsBank.Amount + Random.Range(1, 5));
        }

        public void AddExp()
        {
            _experienceBank.SetAmount(_experienceBank.Amount + Random.Range(100, 1500));
        }

        #endregion


        protected override void SetInitialValues()
        {
            var dto = new MutablePlayerData();
            dto.SetHighScore(0);

            dto.SetCombatSystemId(CombatSystemType.StartPlayer);
            dto.SetShipId("Eagle");

            var coins = new MutableCurrencyData();
            coins.SetAmount(123);
            coins.SetId(CurrencyType.Coins);

            dto.Bank.Add(coins);

            var experience = new MutableCurrencyData();
            experience.SetAmount(234);
            experience.SetId(CurrencyType.Experience);

            dto.Bank.Add(experience);

            _data = dto;
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