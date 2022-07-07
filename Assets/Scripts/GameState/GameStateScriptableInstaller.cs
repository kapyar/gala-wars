using GameConfig;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameStateScriptableInstaller", menuName = "Installers/GameStateScriptableInstaller")]
public class GameStateScriptableInstaller : ScriptableObjectInstaller<GameStateScriptableInstaller>
{
    public GameStateDto GameStateDto = new GameStateDto();

    public override void InstallBindings()
    {
        Container.BindInstance(GameStateDto);
    }
}