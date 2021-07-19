public class ShootingState : BaseState
{
    protected readonly Shooting _shooting;
    protected readonly PlayerActions _playerActions;
    
    public ShootingState(PlayerMovement playerMovement, PlayerActions playerActions, IPlayerStateSwitcher stateSwitcher, Shooting shooting) : base(playerMovement, playerActions, stateSwitcher)
    {
        animState = 2;
        _playerActions = playerActions;
        _shooting = shooting;
    }

    public override void Start()
    {
        
    }

    public override void Stop()
    {
        
    }

    public override void Click()
    {
        
    }
    
    public override void CheckPosition()
    {
        if (_playerMovement.CheckEnemyAtPosition())
        {
            _stateSwitcher.SwitchState<IdleState>();
            _playerActions.WaypointClear?.Invoke();
        }
        else
        {
            _stateSwitcher.SwitchState<FightState>();
        }
    }
}
