using UnityEngine;
using Zenject;
using _Scripts.Config;
using _Scripts.PlayAreas;

namespace _Scripts.Installers
{
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/Config Installer")]
    public class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
    {
        [SerializeField] private BoardConfig _boardConfig;
        [SerializeField] private FieldConfig _fieldConfig;
        [SerializeField] private ShopConfig _shopConfig;
        [SerializeField] private UnitConfig _unitConfig;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BoardConfig>().FromInstance(_boardConfig).AsSingle();
            Container.BindInterfacesTo<FieldConfig>().FromInstance(_fieldConfig).AsSingle();
            Container.BindInterfacesTo<ShopConfig>().FromInstance(_shopConfig).AsSingle();
            Container.BindInterfacesTo<UnitConfig>().FromInstance(_unitConfig).AsSingle();
        }
    }
}