using UnityEngine;
using Zenject;
using _Scripts.Board;

namespace _Scripts.Installers
{
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/ConfigInstaller")]
    public class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
    {
        [SerializeField] private BoardConfig _boardConfig;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BoardConfig>().FromInstance(_boardConfig).AsSingle();
        }
    }
}