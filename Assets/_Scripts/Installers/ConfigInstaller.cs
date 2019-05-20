using UnityEngine;
using Zenject;
using _Scripts.Config;

namespace _Scripts.Installers
{
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/Config Installer")]
    public class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
    {
        [SerializeField] private BoardConfig _boardConfig;
        [SerializeField] private ShopConfig _shopConfig;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BoardConfig>().FromInstance(_boardConfig).AsSingle();
            Container.BindInterfacesTo<ShopConfig>().FromInstance(_shopConfig).AsSingle();
        }
    }
}