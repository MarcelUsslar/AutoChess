using System;
using UnityEngine;

namespace _Scripts.Utility
{
    public abstract class PanelView : MonoBehaviour, IPanelView
    {
        private Type _panelType;
        private Type PanelType
        {
            get { return _panelType ?? (_panelType = GetType()); }
        }

        public void Open()
        {
            gameObject.SetActive(true);
            Debug.Log(string.Format("Opening panel of type {0}", PanelType));
        }

        public void Close()
        {
            gameObject.SetActive(false);
            Debug.Log(string.Format("Closing panel of type {0}", PanelType));
        }
    }
}