using PlayerMovement;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private PlayerMovementView _playerMovementView;
    [SerializeField] private PlayerMovementConfig _playerMovementConfig;

    void Awake()
    {
        PlayerMovementController playerMovementController = 
            new PlayerMovementController(_playerMovementView, _playerMovementConfig);
    }
}
