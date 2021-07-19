public class IdleState : BaseState
{
    protected readonly PlayerActions _playerActions;
    
    public IdleState(PlayerMovement playerMovement, PlayerActions playerActions, IPlayerStateSwitcher stateSwitcher) : base(playerMovement, playerActions, stateSwitcher)
    {
        animState = 0;
        _playerActions = playerActions;
    }

    public override void Start()
    {
        
    }

    public override void Stop()
    {
        
    }

    public override void Click()
    {
        if(_playerMovement.IsFinish) 
            _playerActions.GetFinish?.Invoke();
        else
        {
            _stateSwitcher.SwitchState<RunState>();
            _playerMovement.MoveToNextPoint();
            _playerActions.StartRun?.Invoke();
        }
    }

    public override void CheckPosition()
    {
        if (!_playerMovement.CheckEnemyAtPosition())
        {
            _stateSwitcher.SwitchState<FightState>();
        }
    }
}