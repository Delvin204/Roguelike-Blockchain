using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private enum PickUpType {
        GoldCoin,
        HealthGlobe,
    }

    [SerializeField] private PickUpType pickUpType;
    [SerializeField] private float pickUpDistance = 5f;
    [SerializeField] private float accelartionRate = .2f;
    [SerializeField] private float moveSpeed = 3f;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (PlayerController.Instance == null) return;

        Vector3 playerPos = PlayerController.Instance?.transform.position ?? Vector3.zero;

        if (Vector3.Distance(transform.position, playerPos) < pickUpDistance) {
            moveDir = (playerPos - transform.position).normalized;
            moveSpeed += accelartionRate;
        } else {
            moveDir = Vector3.zero;
            moveSpeed = 0;
        }
    }

    private void FixedUpdate() {
        rb.linearVelocity = moveDir * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.GetComponent<PlayerController>()) {
            DetectPickupType();
            Destroy(gameObject);
        }
    }

    private void DetectPickupType() {
        if (PlayerHealth.Instance != null) {
            switch (pickUpType)
            {
                case PickUpType.GoldCoin:
                EconomyManager.Instance.UpdateCurrentGold();
                    Debug.Log("GoldCoin");
                    break;

                case PickUpType.HealthGlobe:
                    PlayerHealth.Instance.HealPlayer();
                    Debug.Log("HealthGlobe");
                    break;
            }
        } else {
            Debug.LogError("PlayerHealth.Instance is null!");
        }
    }
}
