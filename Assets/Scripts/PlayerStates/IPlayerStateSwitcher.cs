public interface IPlayerStateSwitcher
{
    void SwitchState<T>(float time = 0f) where T : BaseState;
}
