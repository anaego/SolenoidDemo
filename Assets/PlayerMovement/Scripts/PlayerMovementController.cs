using UniRx;

namespace PlayerMovement
{
    public class PlayerMovementController
    {
        private readonly PlayerMovementView _view;
        private readonly PlayerMovementConfig _config;

        public ReactiveProperty<float> Magnitude => _view.Magnitude; 
   
        public PlayerMovementController(PlayerMovementView view, PlayerMovementConfig config)
        {
            _view = view;
            _config = config;
            _view.Init(_config);
        }
    }
}