using UnityEngine;

public class EnemyAI : MonoBehaviour {
    private EnemyPathfinding enemyPathfinding;
    private Transform playerTransform;

    private void Awake() {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
    }

    // private void Start() {
    //     // Tìm player trong scene (đảm bảo object Player có tag "Player")
    //     GameObject player = GameObject.FindGameObjectWithTag("Player");
    //     if (player != null) {
    //         playerTransform = player.transform;
    //     }
    // }

    // private void Update() {
    //     if (playerTransform != null) {
    //         Vector2 playerPosition = playerTransform.position;

    //         // Kiểm tra khoảng cách giữa enemy và player
    //         float distanceToPlayer = Vector2.Distance(transform.position, playerPosition);
    //         if (distanceToPlayer > 0.1f) { 
    //             // Di chuyển đến player nếu khoảng cách lớn hơn 0.1
    //             enemyPathfinding.MoveTo(playerPosition);
    //         } else {
    //             // Enemy đã đến gần player, dừng lại
    //             enemyPathfinding.StopMoving();
    //         }
    //     }
    // }
}
