using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private Transform forWeapon;
    [SerializeField] private Weapon weapon;
    private GameObject bullet;
    private Transform bulletSpawnTransform;

    public float ReloadingTime;

    public bool canShootAtRun;

    private Vector3 targetPosition;
    
    private void Start()
    {
        var go = Instantiate(weapon, forWeapon);
        go.transform.parent = forWeapon;
        bulletSpawnTransform = go.GetComponent<Weapon>().BulletSpawn;
        bullet = weapon.Bullet;
    }

    private Vector3 GetClickWorldPosition(float maxDistance = 30f)
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _layerMask) ? raycastHit.point : ray.GetPoint(maxDistance);
    }
    
    public void Shoot(float time = 0)
    {
        targetPosition = GetClickWorldPosition();
        Invoke(nameof(Fire), time);
    }

    private void Fire()
    {
        //var go = Instantiate(bullet, bulletSpawnTransform.position, Quaternion.identity);
        //go.transform.LookAt(targetPosition);
        PoolManager.GetObjectLookAt(bullet.name, bulletSpawnTransform.position, targetPosition);
    }
    
    
}
