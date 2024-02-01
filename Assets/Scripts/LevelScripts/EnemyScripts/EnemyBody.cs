using System.Collections;
using UnityEngine;

/// <summary>
/// The main script of all enemies
/// </summary>
public class EnemyBody : MonoBehaviour, IDamagable, IAttacker
{
    [field: SerializeField] public int AttackDamage { get; private set; } = 1;
    [field: SerializeField] public int MaxHealth { get; private set; } = 1;
    [field: SerializeField] public float Speed { get; private set; } = 10;
    [field: SerializeField] public int CoinValue { get; private set; } = 1;

    [SerializeField] private EnemyJaws _enemyJaws;

    private int _currentHealth;

    private bool _isInvincible = false;
    private float _invincibilityTime = 1f;

    //Tagreg to follow
    private GameObject _target;


    private void OnEnable()
    {
        _currentHealth = MaxHealth;

        _enemyJaws.OnInteractedWithJaws += Attack;
    }

    private void OnDisable()
    {
        _enemyJaws.OnInteractedWithJaws -= Attack;
    }

    /// <summary>
    /// Invoked when attacked
    /// </summary>
    public void TakeDamage(int amountOfDamage)
    {
        if (_isInvincible)
        {
            return;
        }

        StartCoroutine(StartInvincibility());

        if (_currentHealth - amountOfDamage <= 0) 
        { 
            PlayerStats.AddCoins(CoinValue);
            gameObject.SetActive(false);
        } else
        {
            _currentHealth -= amountOfDamage;
        }
    }

    /// <summary>
    /// Attack others
    /// </summary>
    public void Attack(IDamagable objectToAttack)
    {
        objectToAttack.TakeDamage(AttackDamage);
    }

    private IEnumerator StartInvincibility()
    {
        _isInvincible = true;
        yield return new WaitForSeconds(_invincibilityTime);
        _isInvincible = false;
    }

}
