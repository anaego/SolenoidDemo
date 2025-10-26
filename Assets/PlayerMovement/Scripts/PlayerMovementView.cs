using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerMovement
{
    public class PlayerMovementView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private InputAction _mouseClickAction;
        [SerializeField] private Camera _camera;

        private PlayerMovementConfig _config;
        private float _horizontalMovement;
        private bool _isFacingRight = true;
        
        [HideInInspector] public ReactiveProperty<float> Magnitude = new(0); 

        public void Init(PlayerMovementConfig config)
        {
            _config = config;
        }

        private void OnEnable()
        {
            _mouseClickAction.Enable();
            _mouseClickAction.performed += UpdateMouseClickPosition;
        }

        private void OnDisable()
        {
            _mouseClickAction.performed -= UpdateMouseClickPosition;
            _mouseClickAction.Disable();
        }

        private void UpdateMouseClickPosition(InputAction.CallbackContext context)
        {
            Vector3 position = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            // TODO: get different between current position and this point
            // TODO: get this to 1 or -1 somehow
            // TODO: set to 0 if player got to the position
            _horizontalMovement = position.normalized.x;
        }

        private void Update()
        {
            _rigidbody.linearVelocity = new Vector2(_horizontalMovement * _config.Speed, _rigidbody.linearVelocity.y);
            HandleFlip();
            Magnitude.Value = _rigidbody.linearVelocity.magnitude;
        }

        public void Move(InputAction.CallbackContext context)
        {
            _horizontalMovement = context.ReadValue<Vector2>().x;
        }
        
        private void HandleFlip() 
        {
            if (_isFacingRight && _horizontalMovement < 0 || !_isFacingRight && _horizontalMovement > 0)
            {
                _isFacingRight = !_isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1;
                transform.localScale = localScale;
            }
        }
    }
}