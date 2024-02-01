using UnityEngine;
using Pathfinding;
/// <summary>
/// Controls flip across x axis so enemy always will face player
/// </summary>
public class EnemyFlipToTarget : MonoBehaviour
{
    [SerializeField] private AIPath _aiPath;

    void Update()
    {
        if(_aiPath.desiredVelocity.x >= 0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if (_aiPath.desiredVelocity.x <= -0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
