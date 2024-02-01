using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<FeatureUpgrader> _featureUpgraders;
    private float _playerMoney;
    private void Awake()
    {
        foreach (var featureUpgrader in _featureUpgraders)
        {
            featureUpgrader.Click += OnFeatureUpgraderClick;
        }
        _playerMoney = PlayerPrefs.GetFloat("PlayerMoney", 0f);
    }
    private void OnFeatureUpgraderClick(FeatureUpgrader featureUpgrader)
    {
        featureUpgrader.Upgrade(ref _playerMoney);
        PlayerPrefs.SetFloat("PlayerMoney", _playerMoney);
    }
}
