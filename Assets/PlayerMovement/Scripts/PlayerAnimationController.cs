using UniRx;

namespace PlayerMovement
{
    public class PlayerAnimationController
    {
        public PlayerAnimationController(PlayerAnimationView view, PlayerMovementController playerMovementController)
        {
            playerMovementController.Magnitude.Subscribe(
                f => view.UpdateMagnitude(f)).AddTo(view);
        }
    }
}