using UnityEngine;
using System.Collections;

public class EnemyPathfinding : MonoBehaviour {
    [SerializeField] private float moveSpeed = 4f;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    private KnockBack knockBack;

    private void Awake() {
        knockBack = GetComponent<KnockBack>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (knockBack.gettingKnockedBack) {return;}
        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
    }

    public void MoveTo(Vector2 targetPosition) {
        moveDir = targetPosition;
    }
}
