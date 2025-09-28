using UnityEngine;

namespace PlayerMovement
{
    [CreateAssetMenu(fileName = "PlayerMovementConfig", menuName = "Configs/PlayerMovementConfig")]
    public class PlayerMovementConfig : ScriptableObject
    {        
        public float Speed = 5f;
    }
}
