using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IPlayerStateSwitcher
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Shooting shooting;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerActions playerActions;

    private bool isFinish;


    private BaseState _currentState;
    private List<BaseState> _allStates;

    
    private void Start()
    {
        EnemyCounter.OnEnemyCountChanged += CheckPosition;
        _allStates = new List<BaseState>()
        {
            new IdleState(playerMovement, playerActions, this),
            new FightState(playerMovement, playerActions, this, shooting),
            new RunState(playerMovement, playerActions, this, shooting),
            new ShootingState(playerMovement, playerActions, this, shooting)
        };
        _currentState = _allStates[playerMovement.CheckEnemyAtPosition() ? 0 : 1];
    }

    private void OnDestroy()
    {
        EnemyCounter.OnEnemyCountChanged -= CheckPosition;
    }

    private void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    private void Click()
    {
        _currentState.Click();
    }

    private void CheckPosition()
    {
        _currentState.CheckPosition();
    }

   
    public void SwitchState<T>(float time = 0f) where T : BaseState
    {
        if (time == 0)
        {
            StopAllCoroutines();
            SwitchDone<T>();
        }
        else
        {
            var cor = ChangeAfterTimeOver<T>(time);
            StartCoroutine(cor);
        }
        
    }
    
    private IEnumerator ChangeAfterTimeOver<T>(float value)
    {
        yield return new WaitForSeconds(value);
        SwitchDone<T>();
    }

    private void SwitchDone<T>()
    {
        var state = _allStates.FirstOrDefault(s => s is T);
        _currentState.Stop();
        state.Start();
        _currentState = state;
        animator.SetInteger("State", _currentState.animState);
    }
}
