//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""c3919879-24a2-434b-83ac-9babfecbdc26"",
            ""actions"": [
                {
                    ""name"": ""headButton"",
                    ""type"": ""Button"",
                    ""id"": ""3f365351-169a-45a4-af92-566e2ccf7403"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""chestButton"",
                    ""type"": ""Button"",
                    ""id"": ""56862b55-e450-4529-b055-92a0b6dd60f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""handButton"",
                    ""type"": ""Button"",
                    ""id"": ""d5a3b93a-63e3-4eff-a060-d77226209898"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""eyesLeftButton"",
                    ""type"": ""Button"",
                    ""id"": ""a828ba84-af21-4748-b1bd-d6bca5e2fc71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateCamLeft"",
                    ""type"": ""Button"",
                    ""id"": ""94eb2fc1-504e-4912-8718-799d40b4b6de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateCamMidle"",
                    ""type"": ""Button"",
                    ""id"": ""713937fc-167b-4254-be9c-92c4fce4b673"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateCamRight"",
                    ""type"": ""Button"",
                    ""id"": ""7a7ee9e1-3bff-47f6-a5a6-85f61c8f41a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""eyesRightButton"",
                    ""type"": ""Button"",
                    ""id"": ""5766582b-49a8-4e80-adef-4b88e58739b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cbf0a6be-d52b-4fe9-b7e9-446d9a86474c"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""headButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38ed260c-9d3d-4558-9bcf-a51ed64e79e1"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""chestButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d456fa21-06a8-4064-9599-834235cc429e"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""handButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ebdef8e-4cbc-4f0b-9fb1-b33a2ddb658e"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""eyesLeftButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""702159ed-7911-4c13-8461-1fc73b633e2d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCamLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae60f2c5-ade4-49b8-b895-877b2c85a346"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCamMidle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7117524-038c-4fb4-a492-2bb0661d00b8"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCamRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d9344ac-6cb3-4f4c-8d45-34cd8408f94f"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""eyesRightButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_headButton = m_Gameplay.FindAction("headButton", throwIfNotFound: true);
        m_Gameplay_chestButton = m_Gameplay.FindAction("chestButton", throwIfNotFound: true);
        m_Gameplay_handButton = m_Gameplay.FindAction("handButton", throwIfNotFound: true);
        m_Gameplay_eyesLeftButton = m_Gameplay.FindAction("eyesLeftButton", throwIfNotFound: true);
        m_Gameplay_RotateCamLeft = m_Gameplay.FindAction("RotateCamLeft", throwIfNotFound: true);
        m_Gameplay_RotateCamMidle = m_Gameplay.FindAction("RotateCamMidle", throwIfNotFound: true);
        m_Gameplay_RotateCamRight = m_Gameplay.FindAction("RotateCamRight", throwIfNotFound: true);
        m_Gameplay_eyesRightButton = m_Gameplay.FindAction("eyesRightButton", throwIfNotFound: true);
    }

    public void Dispose()
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

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_headButton;
    private readonly InputAction m_Gameplay_chestButton;
    private readonly InputAction m_Gameplay_handButton;
    private readonly InputAction m_Gameplay_eyesLeftButton;
    private readonly InputAction m_Gameplay_RotateCamLeft;
    private readonly InputAction m_Gameplay_RotateCamMidle;
    private readonly InputAction m_Gameplay_RotateCamRight;
    private readonly InputAction m_Gameplay_eyesRightButton;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @headButton => m_Wrapper.m_Gameplay_headButton;
        public InputAction @chestButton => m_Wrapper.m_Gameplay_chestButton;
        public InputAction @handButton => m_Wrapper.m_Gameplay_handButton;
        public InputAction @eyesLeftButton => m_Wrapper.m_Gameplay_eyesLeftButton;
        public InputAction @RotateCamLeft => m_Wrapper.m_Gameplay_RotateCamLeft;
        public InputAction @RotateCamMidle => m_Wrapper.m_Gameplay_RotateCamMidle;
        public InputAction @RotateCamRight => m_Wrapper.m_Gameplay_RotateCamRight;
        public InputAction @eyesRightButton => m_Wrapper.m_Gameplay_eyesRightButton;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @headButton.started += instance.OnHeadButton;
            @headButton.performed += instance.OnHeadButton;
            @headButton.canceled += instance.OnHeadButton;
            @chestButton.started += instance.OnChestButton;
            @chestButton.performed += instance.OnChestButton;
            @chestButton.canceled += instance.OnChestButton;
            @handButton.started += instance.OnHandButton;
            @handButton.performed += instance.OnHandButton;
            @handButton.canceled += instance.OnHandButton;
            @eyesLeftButton.started += instance.OnEyesLeftButton;
            @eyesLeftButton.performed += instance.OnEyesLeftButton;
            @eyesLeftButton.canceled += instance.OnEyesLeftButton;
            @RotateCamLeft.started += instance.OnRotateCamLeft;
            @RotateCamLeft.performed += instance.OnRotateCamLeft;
            @RotateCamLeft.canceled += instance.OnRotateCamLeft;
            @RotateCamMidle.started += instance.OnRotateCamMidle;
            @RotateCamMidle.performed += instance.OnRotateCamMidle;
            @RotateCamMidle.canceled += instance.OnRotateCamMidle;
            @RotateCamRight.started += instance.OnRotateCamRight;
            @RotateCamRight.performed += instance.OnRotateCamRight;
            @RotateCamRight.canceled += instance.OnRotateCamRight;
            @eyesRightButton.started += instance.OnEyesRightButton;
            @eyesRightButton.performed += instance.OnEyesRightButton;
            @eyesRightButton.canceled += instance.OnEyesRightButton;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @headButton.started -= instance.OnHeadButton;
            @headButton.performed -= instance.OnHeadButton;
            @headButton.canceled -= instance.OnHeadButton;
            @chestButton.started -= instance.OnChestButton;
            @chestButton.performed -= instance.OnChestButton;
            @chestButton.canceled -= instance.OnChestButton;
            @handButton.started -= instance.OnHandButton;
            @handButton.performed -= instance.OnHandButton;
            @handButton.canceled -= instance.OnHandButton;
            @eyesLeftButton.started -= instance.OnEyesLeftButton;
            @eyesLeftButton.performed -= instance.OnEyesLeftButton;
            @eyesLeftButton.canceled -= instance.OnEyesLeftButton;
            @RotateCamLeft.started -= instance.OnRotateCamLeft;
            @RotateCamLeft.performed -= instance.OnRotateCamLeft;
            @RotateCamLeft.canceled -= instance.OnRotateCamLeft;
            @RotateCamMidle.started -= instance.OnRotateCamMidle;
            @RotateCamMidle.performed -= instance.OnRotateCamMidle;
            @RotateCamMidle.canceled -= instance.OnRotateCamMidle;
            @RotateCamRight.started -= instance.OnRotateCamRight;
            @RotateCamRight.performed -= instance.OnRotateCamRight;
            @RotateCamRight.canceled -= instance.OnRotateCamRight;
            @eyesRightButton.started -= instance.OnEyesRightButton;
            @eyesRightButton.performed -= instance.OnEyesRightButton;
            @eyesRightButton.canceled -= instance.OnEyesRightButton;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnHeadButton(InputAction.CallbackContext context);
        void OnChestButton(InputAction.CallbackContext context);
        void OnHandButton(InputAction.CallbackContext context);
        void OnEyesLeftButton(InputAction.CallbackContext context);
        void OnRotateCamLeft(InputAction.CallbackContext context);
        void OnRotateCamMidle(InputAction.CallbackContext context);
        void OnRotateCamRight(InputAction.CallbackContext context);
        void OnEyesRightButton(InputAction.CallbackContext context);
    }
}
