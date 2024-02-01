using UnityEngine;

/// <summary>
/// The main script of all enemies
/// </summary>
public class EnemyBody : MonoBehaviour, IDamagable, IAttacker
{
    [field: SerializeField] public int AttackDamage { get; private set; } = 1;
    [field: SerializeField] public int MaxHealth { get; private set; } = 1;
    [field: SerializeField] public float Speed { get; private set; } = 10;

    [SerializeField] private EnemyJaws _enemyJaws;

    private int _currentHealth;

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
    public void Damage(int amountOfDamage)
    {
        if(_currentHealth - amountOfDamage <= 0) 
        { 
            gameObject.SetActive(false);
            Debug.Log("Died");
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
        objectToAttack.Damage(AttackDamage);
    }

}
