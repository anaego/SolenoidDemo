namespace PlayerMovement
{
    public class PlayerMovementController
    {
        private PlayerMovementView _view;
        private PlayerMovementConfig _config;
   
        public PlayerMovementController(PlayerMovementView view, PlayerMovementConfig config)
        {
            _view = view;
            _config = config;
            _view.Init(_config);
        }
    }
}