using System;
using UnityEngine;

/// <summary>
/// Detects when enemy should damage something
/// </summary>
public class EnemyJaws : MonoBehaviour
{
    public event Action<IDamagable> OnInteractedWithJaws;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Enemy")
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();

            if(damagable != null)
            {
                OnInteractedWithJaws?.Invoke(damagable);
            }
        }
    }
}
