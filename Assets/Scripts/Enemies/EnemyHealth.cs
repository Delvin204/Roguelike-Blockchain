using System.Collections;
using UnityEngine;
using Pathfinding;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;

    private int currentHealth;
    private Flash flash;
    private Animator animator;
    private bool isDead = false;

    private AIPath aiPath;
    private Seeker seeker;
    private Transform spriteTransform; // Đối tượng cần lật (có thể là chính nó hoặc con của nó)
    private PickUpSpawner pickUpSpawner;

    private void Awake() {
        flash = GetComponent<Flash>();
        animator = GetComponent<Animator>();
        aiPath = GetComponent<AIPath>();
        seeker = GetComponent<Seeker>();
        spriteTransform = transform;
        pickUpSpawner = GetComponent<PickUpSpawner>();
    }

    private void Start() {
        currentHealth = startingHealth;
    }

    private void Update() {
        if (!isDead) {
            FlipSpriteBasedOnDirection();
        }
    }

    public void TakeDamage(int damage) {
        if (isDead) return; // Không nhận sát thương nếu đã chết

        currentHealth -= damage;
        StartCoroutine(flash.FlashRoutine());
        DetectDeath();
    }

    public void DetectDeath() {
        if (currentHealth <= 0) {
            isDead = true;

            // Ngừng di chuyển
            aiPath.canMove = false;
            aiPath.destination = transform.position;

            seeker.enabled = false; // Ngừng tính toán đường đi

            animator.SetTrigger("DeathTrigger"); // Phát animation chết
            
            if (pickUpSpawner != null) {
                pickUpSpawner.DropItems(); // Gọi hàm DropItems để spawn coin
            }

            StartCoroutine(DestroyAfterDelay(1f)); // Chờ 1 giây rồi phá hủy
        }
    }

    private IEnumerator DestroyAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private void FlipSpriteBasedOnDirection() {
        Vector2 velocity = aiPath.desiredVelocity;

        if (velocity == Vector2.zero || float.IsNaN(velocity.x) || float.IsNaN(velocity.y)) {
            Debug.LogWarning("AIPath velocity is invalid. Skipping sprite flip.");
            return;
        }

        spriteTransform.localScale = velocity.x < 0 
            ? new Vector3(-1, 1, 1) 
            : new Vector3(1, 1, 1);
    }
}
