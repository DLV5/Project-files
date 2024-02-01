using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private bool _isMoving;  //Bool to check if the player is allowed to move
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _isMoving = true;  //allowed to move if the left mouse button is pressed
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isMoving = false;
        }
        FollowMouse();
    }

    /// <summary>
    /// Moves the player to the mouse position at a certain speed
    /// </summary>
    public void FollowMouse()
    {
        if (!_isMoving)
            return;

        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime); // Player Movement

        transform.up = target.normalized;  // Player rotation
    }
}
