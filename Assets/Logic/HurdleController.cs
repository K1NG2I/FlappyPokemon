using UnityEditor.PackageManager.Requests;
using UnityEngine;

//Inheritance from MonoBehaviour
public class HurdleController : MonoBehaviour
{
    public float Speed = 1.5f;  
    public bool IsMovingUpward; 
    public bool isPassed = false;
    public bool isFlipped = false; 

    private float _resetPositionX = 4f;  
    private float _leftBound = -3.5f;  
    private float _rightBound = 4.5f;

    private void Update()
    {
        //Dependancy on GameManager
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
