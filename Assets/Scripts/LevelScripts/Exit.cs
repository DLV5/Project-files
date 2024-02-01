using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if(collision.tag == "Player")
        {
            _winScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
