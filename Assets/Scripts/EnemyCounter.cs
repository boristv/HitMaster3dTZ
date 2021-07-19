using UnityEngine.Events;

public static class EnemyCounter
{
    public static UnityAction OnEnemyCountChanged;

    private static int count;
    
    public static int Count
    {
        get => count;
        set
        {
            count = value;
            OnEnemyCountChanged?.Invoke();
        }
    }
}
