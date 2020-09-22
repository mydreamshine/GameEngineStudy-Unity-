using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Scenes.Input_System.First_Person
{
    public class FirstPersonCharacterMoveController : MonoBehaviour, GameInputAction.IFpsActions
    {
        private CharacterController _characterController;
        private GameInputAction _inputAction;
        private Vector2 _moveActionValue;

        private bool _isJumped;
        private float _jumpTime = 0.0f;

        private bool _isGrounded;
        private float _fallingSpeed = 0.0f;
        private const float Gravity = 9.81f;

        [SerializeField] private float characterMoveSpeed = 10.0f;
        [SerializeField] private Transform groundCheckPosition;
        [SerializeField] private float groundCheckOffset = 0.1f;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float jumpPower = 10.0f;
        [SerializeField] private float jumpMaxTime = 1.0f;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        private void OnEnable()
        {
            if(_inputAction == null)
                _inputAction = new GameInputAction();
            
            // Action 맵에 따라 활성/비활성 가능
            _inputAction.Fps.Enable();
            // 콜백 메소드가 존재하는 인스턴스 등록
            _inputAction.Fps.SetCallbacks(this);
        }

        private void OnDisable()
        {
            _inputAction.Disable();
        }

        // Update is called once per frame
        void Update()
        {
            var verticalVector = transform.forward * (_moveActionValue.y * Time.deltaTime * characterMoveSpeed);
            var horizontalVector = transform.right * (_moveActionValue.x * Time.deltaTime * characterMoveSpeed);

            if (_jumpTime >= jumpMaxTime)
            {
                if (_isJumped)
                {
                    var jumpVector = Vector3.zero;
                    jumpVector.y = jumpPower * Time.deltaTime;
                    verticalVector += jumpVector;
                }

                _jumpTime = 0.0f;
            }
            else
                _jumpTime += Time.deltaTime;

            // move by controller
            _characterController.Move(verticalVector + horizontalVector);
            
            _isGrounded = Physics.CheckSphere(groundCheckPosition.position, groundCheckOffset, groundLayer);
            if (_isGrounded) _fallingSpeed = 0.0f;
            else _fallingSpeed = -(Gravity * Time.deltaTime);
            
            // move by gravity
            _characterController.Move(new Vector3(0.0f, _fallingSpeed, 0.0f));
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _moveActionValue = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            // phase: 입력 상태
            if (context.phase == InputActionPhase.Performed)
                _isJumped = true;
            else
                _isJumped = false;
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
        }

        public void OnChrouch(InputAction.CallbackContext context)
        {
        }
    }
}
