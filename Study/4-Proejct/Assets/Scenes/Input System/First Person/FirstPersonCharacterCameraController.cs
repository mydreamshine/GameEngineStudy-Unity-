using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scenes.Input_System.First_Person
{
    public class FirstPersonCharacterCameraController : MonoBehaviour, GameInputAction.IFpsCameraActions
    {
        private CharacterController _characterController;
        private GameInputAction _inputAction;
        private Vector2 _mouseDeltaVector;
        private float _cameraPitchAngle;

        [SerializeField] private Transform cameraTransform;
        [SerializeField] private float moseSensitivity = 100.0f;
        [SerializeField] private float cameraPitchMin = -65.0f;
        [SerializeField] private float cameraPitchMax = 65.0f;
        
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        // Start is called before the first frame update
        void Start()
        {
            Cursor.visible = false;
            // 커서를 화면 밖으로 내보내지 않게 Lock함.
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnEnable()
        {
            if(_inputAction == null)
                _inputAction = new GameInputAction();
            
            // Action 맵에 따라 활성/비활성 가능
            _inputAction.FpsCamera.Enable();
            // 콜백 메소드가 존재하는 인스턴스 등록
            _inputAction.FpsCamera.SetCallbacks(this);
        }

        private void OnDisable()
        {
            _inputAction.Disable();
        }


        // Update is called once per frame
        void Update()
        {
            float horizontalDirection = _mouseDeltaVector.x * moseSensitivity * Time.deltaTime;
            transform.Rotate(0.0f, horizontalDirection, 0.0f);
            
            _cameraPitchAngle -= _mouseDeltaVector.y * moseSensitivity * Time.deltaTime;
            _cameraPitchAngle = Mathf.Clamp(_cameraPitchAngle, cameraPitchMin, cameraPitchMax);
            cameraTransform.localRotation = Quaternion.Euler(_cameraPitchAngle, 0.0f, 0.0f);
        }

        public void OnAim(InputAction.CallbackContext context)
        {
            _mouseDeltaVector = context.ReadValue<Vector2>();
        }
    }
}
