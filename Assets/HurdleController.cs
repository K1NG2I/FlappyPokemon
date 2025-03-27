using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class HurdleController : MonoBehaviour
{
    public float Speed = 1.5f;  // Movement speed of the hurdle
    public bool IsMovingUpward; // True for `HurdleUp`, False for `HurdleDown`
    public bool isPassed = false;
    public bool isFlipped = false; 

    private float _resetPositionX = 4f;  // Position to respawn after reset
    private float _leftBound = -3.5f;  // Leftmost boundary before resetting
    private float _rightBound = 4.5f;

    private void Update()
    {
        if (GameManager.Instance.IsGameRunning)
        {
            float moveDirection = isFlipped ? 1f : -1f;
            transform.Translate(Vector2.right * moveDirection * Speed * Time.deltaTime);

            if ((!isFlipped && transform.position.x <= _leftBound) || (isFlipped && transform.position.x >= _rightBound))
            {
                ResetPosition();
            }
        }
        else
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
      
        float newY = IsMovingUpward ? Random.Range(-8.5f, -9.5f) : Random.Range(-18f, -18f);

        float newX = isFlipped ? -_resetPositionX : _resetPositionX;
        transform.position = new Vector2(newX, newY);

        isPassed = false; 
    }
}
