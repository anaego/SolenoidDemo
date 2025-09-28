using UnityEngine;

namespace PlayerMovement
{
    public class PlayerAnimationView : MonoBehaviour
    {
        private static readonly int Magnitude = Animator.StringToHash("magnitude");
        
        [SerializeField] private Animator _animator;
        
        public void UpdateMagnitude(float value)
        {
            _animator.SetFloat(Magnitude, value);
        }
    }
}