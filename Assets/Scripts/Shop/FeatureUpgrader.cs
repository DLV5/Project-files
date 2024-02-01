using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeatureUpgrader : MonoBehaviour
{
    public event Action<FeatureUpgrader> Click;
    [SerializeField] private Button _buyUpgradeButton;
    [SerializeField] private GameObject _disabledMask;  //Mask to be displayed if the upgrader is not active
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _priceText;
    [Header ("Distinctiveness")]
    [SerializeField] private string _featureName;
    [SerializeField] private float _initialPrice;
    [SerializeField] private float _totalPossibleUpgrades; //Determines how many times the player can update the feature
    [SerializeField] private float _powerUpAmount;  //Determines what value will be added to the current feature value when it is upgraded

    private float _currentPrice;
    private int _upgradesCount;
    private float _currentPower;


    private void Awake()
    {
        _buyUpgradeButton.onClick.AddListener(OnButtonClick);
        _titleText.text = _featureName;
        UpdateItem();
        _currentPrice = PlayerPrefs.GetFloat(_featureName + "CurrentPrice", _initialPrice);
        _upgradesCount = PlayerPrefs.GetInt(_featureName + "UpgradesCount", 0);
        _currentPower = PlayerPrefs.GetFloat(_featureName, 0);
    }

    /// <summary>
    /// Updating the represented feature, if it is allowed
    /// </summary>
    /// <param name="money"></param>
    public void Upgrade(ref float money)
    {
        if (_currentPrice > money)
        {
            LockUpgrader();
            return;
        }
        else if (_upgradesCount >= _totalPossibleUpgrades)
        {
            LockUpgrader();
            return;
        }

        money -= _currentPrice;

        _currentPrice += _initialPrice;
        _upgradesCount++;
        _currentPower += _powerUpAmount;

        UpdateItem();
    }
    private void LockUpgrader()
    {
        _buyUpgradeButton.enabled = false;
        _disabledMask.SetActive(true);
        Debug.Log(_featureName + " locked");
    }

    /// <summary>
    /// Updating the UI and saved in PlayerPrefs values
    /// </summary>
    private void UpdateItem()
    {
        _priceText.text = _currentPrice.ToString(); //Update UI

        PlayerPrefs.SetFloat(_featureName, _currentPower);

        PlayerPrefs.SetFloat(_featureName + "CurrentPrice", _currentPrice);
        PlayerPrefs.SetInt(_featureName + "UpgradesCount", _upgradesCount);
    }
    private void OnButtonClick()
    {
        Click?.Invoke(this);
        Debug.Log(_featureName + " button clicked");
    }
}
