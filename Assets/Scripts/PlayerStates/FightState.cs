public class FightState : BaseState
{
    protected readonly Shooting _shooting;
    
    public FightState(PlayerMovement playerMovement,  PlayerActions playerActions, IPlayerStateSwitcher stateSwitcher, Shooting shooting) : base(playerMovement, playerActions, stateSwitcher)
    {
        animState = 1;
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
        _shooting.Shoot(_shooting.ReloadingTime/2);
        _stateSwitcher.SwitchState<ShootingState>();
        _stateSwitcher.SwitchState<FightState>(_shooting.ReloadingTime);
    }

    public override void CheckPosition()
    {
        if (_playerMovement.CheckEnemyAtPosition())
        {
            _playerActions.WaypointClear?.Invoke();
            _stateSwitcher.SwitchState<IdleState>();
        }
    }
}
