using UnityEngine;
using _Scripts.Unit;

namespace _Scripts.Config
{
    public interface IUnitConfig
    {
        UnitType GetPreviewType(int id);
        RenderTexture GetPreviewTexture(int id);
    }
}