using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    internal class Gun : MonoBehaviour, IShootable
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private int damage = 1;
        [SerializeField] private UnityEvent OnShot;

        void IShootable.ShootInDirection(Vector3 direction)
        {
            OnShot?.Invoke();
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = shootPoint.position;
            bullet.Damage = damage;           

            bullet.transform.rotation = Quaternion.Euler(direction.ToDirectionVector());
        }
    }

    internal interface IShootable
    {
        void ShootInDirection(Vector3 direction);
    }
}
