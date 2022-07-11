using System;
using System.Linq;
using Currency;
using Game.Controllers.Leaderboard;
using Game.Enemy.Signals;
using GameState.Combat;
using PlayerState.Boosters.Signals;
using PlayerState.Data;
using PlayerState.Signals;
using Services;
using Services.Files;
using UI.EnterNameController.Signals;
using Zenject;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerStateController : AbstractSerializableController<MutablePlayerData>
    {
        public ReadOnlyPlayerData PlayerData => _data;
        protected override string Filename => "player_data";


        private readonly SignalBus _signalBus;
        private MutableCurrencyData _coinsBank;
        private MutableCurrencyData _experienceBank;
        
        public ReadonlyCurrencyData ExperienceBank => _experienceBank;

        private readonly LeaderboardController _leaderboardController;


        public PlayerStateController(IFileService fileService, SignalBus signalBus, LeaderboardController leaderboardController) : base(fileService)
        {
            _signalBus = signalBus;
            _leaderboardController = leaderboardController;

            LoadData();
            InitBank();

            _signalBus.Subscribe<SubmitNameSignal>(OnNameSubmitted);
            _signalBus.Subscribe<EnemyRewardDroppedSignal>(OnRewardDropped);
            _signalBus.Subscribe<SaveDataSignal>(OnSaveData);
        }


        private void OnSaveData(SaveDataSignal signal)
        {
            if (_data.HighScore < _experienceBank.Amount)
            {
                _data.SetHighScore(_experienceBank.Amount);
            }

            _leaderboardController.CheckAndSaveNewHighScore(_data.Name, _experienceBank.Amount);

            SaveData();
        }

        private void OnNameSubmitted(SubmitNameSignal signal)
        {
            _data.SetName(signal.Name);
            ResetData();
        }

        private void ResetData()
        {
            _data.SetHighScore(0);
            _coinsBank.SetAmount(0);
            _experienceBank.SetAmount(0);
        }

        private void InitBank()
        {
            _coinsBank = _data.Bank.FirstOrDefault(x => x.Id == CurrencyType.Coins);
            _coinsBank.OnAmountChanged += OnCoinBalanceChanged;

            _experienceBank = _data.Bank.FirstOrDefault(x => x.Id == CurrencyType.Experience);
            _experienceBank.OnAmountChanged += OnExperienceBalanceChanged;
        }

        private void OnRewardDropped(EnemyRewardDroppedSignal signal)
        {
            switch (signal.Type)
            {
                case CurrencyType.Coins:
                    _coinsBank.SetAmount(_coinsBank.Amount + signal.Amount);
                    break;
                case CurrencyType.Experience:
                    _experienceBank.SetAmount(_experienceBank.Amount + signal.Amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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