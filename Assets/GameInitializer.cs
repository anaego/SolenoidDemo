using PlayerMovement;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private PlayerMovementView _playerMovementView;
    [SerializeField] private PlayerMovementConfig _playerMovementConfig;
    [SerializeField] private PlayerAnimationView _playerAnimationView;

    void Awake()
    {
        PlayerMovementController playerMovementController = 
            new PlayerMovementController(_playerMovementView, _playerMovementConfig);
        PlayerAnimationController playerAnimationController = 
            new PlayerAnimationController(_playerAnimationView, playerMovementController);
    }
}
