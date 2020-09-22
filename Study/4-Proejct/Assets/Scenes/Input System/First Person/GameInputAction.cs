// GENERATED AUTOMATICALLY FROM 'Assets/Scenes/Input System/First Person/GameInputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputAction"",
    ""maps"": [
        {
            ""name"": ""Fps"",
            ""id"": ""0c2ab5dc-00e2-414f-b220-fa71cc45e31c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""43d7e99b-23ce-4657-b31a-d3a52422eaa9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d2846178-3cb1-4f37-9dfd-4f9a1438a8e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""fe513a22-bd50-499d-8910-1d6fff55ea0c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Chrouch"",
                    ""type"": ""Button"",
                    ""id"": ""aeca981c-56ab-42ab-b13a-ab4ce1232e34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""6609777b-51cc-4661-b484-50b0c7cb5c14"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""07c9affd-9b02-453b-a65c-85e24d8c08fa"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""024c3761-421a-4f35-8b64-7ab48c1725f6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b94f903e-edaa-4a73-a791-ff3e1315d449"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f0e645d6-f413-4015-9dc1-56e29f1f15ff"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3f526c5a-34c6-4cbf-992c-0b041faebe45"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99da67ee-364f-4ee7-b331-64b8aa966f2d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""829a65e2-9d9f-4df3-a01f-de7bf9dc3362"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Chrouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""FpsCamera"",
            ""id"": ""644aeedb-0485-4cba-b49b-6615ffad7758"",
            ""actions"": [
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""292c292c-f0e5-4303-a214-933e2f24fc42"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""160d0617-33fb-473e-884a-293d423a9d50"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Fps
        m_Fps = asset.FindActionMap("Fps", throwIfNotFound: true);
        m_Fps_Move = m_Fps.FindAction("Move", throwIfNotFound: true);
        m_Fps_Jump = m_Fps.FindAction("Jump", throwIfNotFound: true);
        m_Fps_Sprint = m_Fps.FindAction("Sprint", throwIfNotFound: true);
        m_Fps_Chrouch = m_Fps.FindAction("Chrouch", throwIfNotFound: true);
        // FpsCamera
        m_FpsCamera = asset.FindActionMap("FpsCamera", throwIfNotFound: true);
        m_FpsCamera_Aim = m_FpsCamera.FindAction("Aim", throwIfNotFound: true);
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

    // Fps
    private readonly InputActionMap m_Fps;
    private IFpsActions m_FpsActionsCallbackInterface;
    private readonly InputAction m_Fps_Move;
    private readonly InputAction m_Fps_Jump;
    private readonly InputAction m_Fps_Sprint;
    private readonly InputAction m_Fps_Chrouch;
    public struct FpsActions
    {
        private @GameInputAction m_Wrapper;
        public FpsActions(@GameInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Fps_Move;
        public InputAction @Jump => m_Wrapper.m_Fps_Jump;
        public InputAction @Sprint => m_Wrapper.m_Fps_Sprint;
        public InputAction @Chrouch => m_Wrapper.m_Fps_Chrouch;
        public InputActionMap Get() { return m_Wrapper.m_Fps; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FpsActions set) { return set.Get(); }
        public void SetCallbacks(IFpsActions instance)
        {
            if (m_Wrapper.m_FpsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_FpsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_FpsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_FpsActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_FpsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_FpsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_FpsActionsCallbackInterface.OnJump;
                @Sprint.started -= m_Wrapper.m_FpsActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_FpsActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_FpsActionsCallbackInterface.OnSprint;
                @Chrouch.started -= m_Wrapper.m_FpsActionsCallbackInterface.OnChrouch;
                @Chrouch.performed -= m_Wrapper.m_FpsActionsCallbackInterface.OnChrouch;
                @Chrouch.canceled -= m_Wrapper.m_FpsActionsCallbackInterface.OnChrouch;
            }
            m_Wrapper.m_FpsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Chrouch.started += instance.OnChrouch;
                @Chrouch.performed += instance.OnChrouch;
                @Chrouch.canceled += instance.OnChrouch;
            }
        }
    }
    public FpsActions @Fps => new FpsActions(this);

    // FpsCamera
    private readonly InputActionMap m_FpsCamera;
    private IFpsCameraActions m_FpsCameraActionsCallbackInterface;
    private readonly InputAction m_FpsCamera_Aim;
    public struct FpsCameraActions
    {
        private @GameInputAction m_Wrapper;
        public FpsCameraActions(@GameInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_FpsCamera_Aim;
        public InputActionMap Get() { return m_Wrapper.m_FpsCamera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FpsCameraActions set) { return set.Get(); }
        public void SetCallbacks(IFpsCameraActions instance)
        {
            if (m_Wrapper.m_FpsCameraActionsCallbackInterface != null)
            {
                @Aim.started -= m_Wrapper.m_FpsCameraActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_FpsCameraActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_FpsCameraActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_FpsCameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public FpsCameraActions @FpsCamera => new FpsCameraActions(this);
    public interface IFpsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnChrouch(InputAction.CallbackContext context);
    }
    public interface IFpsCameraActions
    {
        void OnAim(InputAction.CallbackContext context);
    }
}
