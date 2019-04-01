using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/ConfigInstaller")]
    public class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
    {
        public override void InstallBindings()
        {
        }
    }
}