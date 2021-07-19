public class RunState : BaseState
{
    protected readonly PlayerActions _playerActions;
    protected readonly Shooting _shooting;
    
    public RunState(PlayerMovement playerMovement, PlayerActions playerActions, IPlayerStateSwitcher stateSwitcher, Shooting shooting) : base(playerMovement, playerActions, stateSwitcher)
    {
        animState = 3;
        _playerActions = playerActions;
        _shooting = shooting;
    }

    public override void Start()
    {
        _playerMovement.StartRun();
        _playerMovement.ReachPoint += CheckPosition;
    }
    
    public override void Stop()
    {
        _playerMovement.StopRun();
        _playerMovement.ReachPoint -= CheckPosition;
    }

    public override void Click()
    {
        if (_shooting.canShootAtRun)
            _shooting.Shoot(_shooting.ReloadingTime/2);
    }

    public override void CheckPosition()
    {
        if (_playerMovement.CheckEnemyAtPosition())
        {
            if (_playerMovement.OnFinish())
            {
                _playerActions.OnFinish?.Invoke();
                _playerMovement.IsFinish = true;
                _stateSwitcher.SwitchState<IdleState>();
            }
            _playerMovement.MoveToNextPoint();
        }
        else
        {
            _stateSwitcher.SwitchState<FightState>();
        }
    }
}
