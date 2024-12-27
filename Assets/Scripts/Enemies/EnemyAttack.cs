using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float attackRange = 1f; // Tầm tấn công
    [SerializeField] private int damageAmount = 1;  // Sát thương gây ra
    [SerializeField] private float attackCooldown = 1f; // Thời gian hồi chiêu

    private bool canAttack = true;

    private void Update()
    {
        if (player == null)
        {
            // Player bị null, không thực hiện tấn công
            return;
        }
        // Kiểm tra khoảng cách giữa enemy và player
        if (Vector2.Distance(transform.position, player.position) <= attackRange && canAttack)
        {
            player.GetComponent<PlayerHealth>()?.TakeDamage(damageAmount, transform);
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        // Vẽ tầm tấn công trong Editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
