﻿using UniRx;
using UnityEngine;

namespace _Scripts.PlayAreas
{
    public interface IFieldView
    {
        IObservable<UniRx.Unit> OnPointerEnterAsObservable { get; }
        IObservable<UniRx.Unit> OnPointerExitAsObservable { get; }
        IObservable<UniRx.Unit> OnPointerClickAsObservable { get; }

        Vector3 Position { set; }
        Transform UnitParent { get; }
        Material FieldMaterial { set; }
    }
}