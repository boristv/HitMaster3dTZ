using UnityEngine;

[AddComponentMenu("Pool/PoolSetup")]
public class PoolSetup : MonoBehaviour //обертка для управления статическим классом PoolManager
{
    [SerializeField] private PoolManager.PoolPart[] pools; //структуры, где пользователь задает префаб для использования в пуле и инициализируемое количество 
    
    
    private void OnValidate() {
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i].name = pools[i].prefab.name; //присваиваем имена заранее, до инициализации
        }
    }

    private void Awake()
    {
        Initialize();
    }

    private void Initialize ()
    {
        PoolManager.Initialize(pools); //инициализируем менеджер пулов
    }
}
