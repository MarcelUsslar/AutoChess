using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using _Scripts.Unit;

namespace _Scripts.Config
{
    [CreateAssetMenu(fileName = "UnitConfig", menuName = "Configs/Unit Config")]
    public class UnitConfig : ScriptableObject, IUnitConfig
    {
#pragma warning disable 0649
        [Serializable]
        private class UnitMapping
        {
            public int UnitId;
            public UnitType UnitType;
            public RenderTexture PreviewTexture;
        }
#pragma warning restore 0649

        [SerializeField] private List<UnitMapping> _unitMappings;

        public UnitType GetPreviewType(int id)
        {
            return _unitMappings.First(mapping => mapping.UnitId == id).UnitType;
        }

        public RenderTexture GetPreviewTexture(int id)
        {
            return _unitMappings.First(mapping => mapping.UnitId == id).PreviewTexture;
        }
    }
}