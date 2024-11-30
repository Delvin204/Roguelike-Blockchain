using UnityEngine;
using System.Collections;

public class EnemyPathfinding : MonoBehaviour {
    [SerializeField] private float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 moveDir;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
    }

    public void MoveTo(Vector2 targetPosition) {
        moveDir = targetPosition;
    }

    public void StopMoving() {
        rb.linearVelocity = Vector2.zero; // Dừng chuyển động
    }
}
