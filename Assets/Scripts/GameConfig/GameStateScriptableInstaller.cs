using GameConfig;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameStateScriptableInstaller", menuName = "Installers/GameStateScriptableInstaller")]
public class GameStateScriptableInstaller : ScriptableObjectInstaller<GameStateScriptableInstaller>
{
    [SerializeField] private GameStateDto _gameStateDto;

    public override void InstallBindings()
    {
        Container.BindInstance(_gameStateDto);
    }
}