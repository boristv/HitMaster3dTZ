public abstract class BaseState
{
    public int animState;
    protected readonly PlayerMovement _playerMovement;
    protected readonly IPlayerStateSwitcher _stateSwitcher;
    protected readonly PlayerActions _playerActions;

    protected BaseState(PlayerMovement playerMovement, PlayerActions playerActions, IPlayerStateSwitcher stateSwitcher)
    { 
        _playerMovement = playerMovement;
        _stateSwitcher = stateSwitcher;
        _playerActions = playerActions;
    }

    public abstract void Start();
    public abstract void Stop();
    
    public abstract void Click();

    public abstract void CheckPosition();
}