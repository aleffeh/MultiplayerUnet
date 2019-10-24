using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : NetworkBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D _rb2d;

    private void Awake() => _rb2d = GetComponent<Rigidbody2D>();
    private void FixedUpdate() => Move(GetDirection());
    private Vector2 GetDirection() =>
        new Vector2 {x = Input.GetAxisRaw("Horizontal"), y = Input.GetAxisRaw("Vertical")};
    private void Move(Vector2 direction)
    {
        if (isLocalPlayer)
            _rb2d.velocity = direction * speed;
    }
}