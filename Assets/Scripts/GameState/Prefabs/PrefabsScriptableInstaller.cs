using GameState.Prefabs;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PrefabsScriptableInstaller", menuName = "Installers/PrefabsScriptableInstaller")]
public class PrefabsScriptableInstaller : ScriptableObjectInstaller<PrefabsScriptableInstaller>
{
    public PrefabsMapDto PrefabsMap = new PrefabsMapDto();

    public override void InstallBindings()
    {
        Container.BindInstance(PrefabsMap);
    }
}