using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    [CreateAssetMenu(fileName = "PrefabInstaller", menuName = "Installers/PrefabInstaller")]
    public class PrefabInstaller : ScriptableObjectInstaller<PrefabInstaller>
    {
        public override void InstallBindings()
        {
        }
    }
}