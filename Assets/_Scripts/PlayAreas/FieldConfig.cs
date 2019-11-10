using UnityEngine;

namespace _Scripts.PlayAreas
{
    [CreateAssetMenu(fileName = "FieldConfig", menuName = "Configs/Field Config")]
    public class FieldConfig : ScriptableObject, IFieldConfig
    {
        [SerializeField] private Material _defaultMaterial;
        [SerializeField] private Material _enteredMaterial;
        
        public Material DefaultMaterial
        {
            get { return _defaultMaterial; }
        }

        public Material EnteredMaterial
        {
            get { return _enteredMaterial; }
        }
    }
}