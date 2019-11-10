using UnityEngine;

namespace _Scripts.PlayAreas
{
    public interface IFieldConfig
    {
        Material DefaultMaterial { get; }
        Material EnteredMaterial { get; }
    }
}