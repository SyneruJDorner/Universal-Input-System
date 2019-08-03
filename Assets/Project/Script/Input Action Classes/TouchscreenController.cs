// GENERATED AUTOMATICALLY FROM 'Assets/Project/Script/Action Classes/TouchscreenController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class TouchscreenController : IInputActionCollection
{
    private InputActionAsset asset;
    public TouchscreenController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchscreenController"",
    ""maps"": [
        {
            ""name"": ""Toushscreen"",
            ""id"": ""8fa16ea3-76ef-416f-bcf9-13562ae11a6b"",
            ""actions"": [
                {
                    ""name"": ""Position"",
                    ""id"": ""ac75ad39-c18e-47e7-ad2b-93666d7b0038"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""19acede5-a1b2-42a0-b1bd-f5254393145c"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Toushscreen
        m_Toushscreen = asset.GetActionMap("Toushscreen");
        m_Toushscreen_Position = m_Toushscreen.GetAction("Position");
    }

    ~TouchscreenController()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes
    {
        get => asset.controlSchemes;
    }

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Toushscreen
    private InputActionMap m_Toushscreen;
    private IToushscreenActions m_ToushscreenActionsCallbackInterface;
    private InputAction m_Toushscreen_Position;
    public struct ToushscreenActions
    {
        private TouchscreenController m_Wrapper;
        public ToushscreenActions(TouchscreenController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Position { get { return m_Wrapper.m_Toushscreen_Position; } }
        public InputActionMap Get() { return m_Wrapper.m_Toushscreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(ToushscreenActions set) { return set.Get(); }
        public void SetCallbacks(IToushscreenActions instance)
        {
            if (m_Wrapper.m_ToushscreenActionsCallbackInterface != null)
            {
                Position.started -= m_Wrapper.m_ToushscreenActionsCallbackInterface.OnPosition;
                Position.performed -= m_Wrapper.m_ToushscreenActionsCallbackInterface.OnPosition;
                Position.canceled -= m_Wrapper.m_ToushscreenActionsCallbackInterface.OnPosition;
            }
            m_Wrapper.m_ToushscreenActionsCallbackInterface = instance;
            if (instance != null)
            {
                Position.started += instance.OnPosition;
                Position.performed += instance.OnPosition;
                Position.canceled += instance.OnPosition;
            }
        }
    }
    public ToushscreenActions @Toushscreen
    {
        get
        {
            return new ToushscreenActions(this);
        }
    }
    public interface IToushscreenActions
    {
        void OnPosition(InputAction.CallbackContext context);
    }
}
