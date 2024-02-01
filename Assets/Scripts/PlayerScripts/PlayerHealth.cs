using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    public event Action OnPlayerDied;

    private PlayerStats _playerStats;

    private int _currentHealth;

    private bool _isInvincible = false;
    private float _invincibilityTime = 2f;

    private PlayerUI _playerUI;

    private void Awake()
    {
        _playerUI = GetComponent<PlayerUI>();
    }

    private void OnEnable()
    {
        _playerStats = GetComponent<PlayerStats>();
    }

    private void Start()
    {
        SetHealthToMax();
    }

    public void TakeDamage(int damage)
    {
        if (_isInvincible)
        {
            return;
        }

        _currentHealth -= damage;

        _playerUI.HealthBar.SetHealth(_currentHealth);

        StartCoroutine(StartInvincibility());

        if (_currentHealth <= 0)
        {
            _playerUI.Fader.FadeIn("ShopMenu");
        }
    }

    private void SetHealthToMax()
    {
        _currentHealth = _playerStats.Health;
        _playerUI.HealthBar.SetMaxHealth(_currentHealth);
    }

    private IEnumerator StartInvincibility()
    {
        _isInvincible = true;
        yield return new WaitForSeconds(_invincibilityTime);
        _isInvincible = false;
    }

}