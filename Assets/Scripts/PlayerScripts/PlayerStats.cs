using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int CoinAmout { get; private set; } = 0;

    public int Damage { get; private set; }
    public int Health { get; private set; }
    public float Speed { get; private set; }

    private void Awake()
    {
        CoinAmout = (int)PlayerPrefs.GetFloat("PlayerMoney");
        Damage = (int) PlayerPrefs.GetFloat("Damage") > 0 ? (int)PlayerPrefs.GetFloat("Damage") : 1;
        Health = (int) PlayerPrefs.GetFloat("Health") > 0 ? (int)PlayerPrefs.GetFloat("Health") : 1;
        Speed = PlayerPrefs.GetFloat("Speed") > 0 ? (int)PlayerPrefs.GetFloat("Speed") : 5;
    }

    public static void AddCoins(int amount)
    {
        CoinAmout += amount;
        Debug.Log(CoinAmout);
    }
}
