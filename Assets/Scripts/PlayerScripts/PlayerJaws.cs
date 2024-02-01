using UnityEngine;

public class PlayerJaws : MonoBehaviour
{
    private PlayerStats _playerStats;

    private void OnEnable()
    {
        _playerStats = transform.root.GetComponent<PlayerStats>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();

            if (damagable != null)
            {
                damagable.TakeDamage(_playerStats.Damage);
            }
        }
    }
}
