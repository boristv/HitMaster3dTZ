using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    private bool damageDone;
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        damageDone = false;
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.forward * speed);
        CancelInvoke(nameof(ReturnToPool));
        Invoke(nameof(ReturnToPool), 5f);
    }

    private void OnCollisionEnter(Collision coll)
    {
        //Чтоб при касании нескольких частей тела одновременно урон не наносился несколько раз
        if (damageDone)
        {
            ReturnToPool();
            return;
        }
        damageDone = true;
        
        coll.gameObject.GetComponent<EnemyPart>()?.ApplyDamage(damage);
        
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        //Destroy(gameObject);
        GetComponent<PoolObject>().ReturnToPool();
    }
}
