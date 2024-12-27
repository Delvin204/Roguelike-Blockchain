using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab; // Prefab của Player
    private GameObject currentPlayer; // Lưu trữ Player hiện tại

    private void Start()
    {
        // Kiểm tra nếu đang ở scene Gameplay
        if (SceneManager.GetActiveScene().name == "Gameplay" && playerPrefab == null)
        {
            ReloadGameplayScene();
            // SetupPlayer();
        }
    }

    private void SetupPlayer()
    {
        // if (currentPlayer == null)
        // {
        //     if (playerPrefab != null)
        //     {
        //         currentPlayer = Instantiate(playerPrefab);
        //     }
        //     else
        //     {
        //         Debug.LogError("Player Prefab không được gán trong Inspector!");
        //         return;
        //     }
        // }

        if (!playerPrefab.activeSelf)
        {
            playerPrefab.SetActive(true);
        }
    }


    private void ReloadGameplayScene()
    {
        // Tải lại scene Gameplay hoàn toàn
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
