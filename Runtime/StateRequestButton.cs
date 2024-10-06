using System;
using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.StateMachines
{
    public abstract class StateRequestButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        
        protected virtual void OnValidate()
        {
            if (!button) button = GetComponent<Button>();
        }

        protected virtual void Awake() => OnValidate();
        
        protected virtual void OnEnable()
        {
            if (button) button.onClick.AddListener(OnClick);
        }

        protected virtual void OnDisable()
        {
            if (button) button.onClick.AddListener(OnClick);
        }

        public abstract void OnClick();
    }
}