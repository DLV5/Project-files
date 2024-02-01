using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [field: SerializeField] public PlayerHealthBar HealthBar {  get; private set; }
    [field: SerializeField] public SceneFader Fader { get; private set; }
}
