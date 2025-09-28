using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerMovement
{
    public class PlayerMovementView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private PlayerMovementConfig _config;
        private float _horizontalMovement;
        private bool _isFacingRight = true;
        
        public ReactiveProperty<float> Magnitude = new(0); 

        public void Init(PlayerMovementConfig config)
        {
            _config = config;
        }

        private void Update()
        {
            _rigidbody.velocity = new Vector2(_horizontalMovement * _config.Speed, _rigidbody.velocity.y);
            HandleFlip();
            Magnitude.Value = _rigidbody.velocity.magnitude;
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