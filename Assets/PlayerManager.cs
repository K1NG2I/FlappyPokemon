using UnityEngine;

public class PlayerManager
{
    private GameObject _player;
    private Rigidbody2D _rb;

    public PlayerManager(GameObject player)
    {
        _player = player;
        _rb = _player.GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rb.AddForce(new Vector2(0, 250));
    }
}
