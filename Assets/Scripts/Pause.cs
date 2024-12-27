using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject player;

    public void PauseGame() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home() {
        player.SetActive(false);
        SceneManager.LoadScene("MenuStart");
        Time.timeScale = 1;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Save() {
        int goldAmount = WalletUrl.Instance.goldText;
        StartCoroutine(SendGoldValueToAPI(goldAmount));
    }

    private IEnumerator SendGoldValueToAPI(int goldValue)
    {
        // URL của API (thay thế bằng URL thực tế)
        string apiUrl = "localhost:8080/roguelike/saveCoin";
        string walletUrl = WalletUrl.Instance.globalWallet;
        // Tạo form data hoặc JSON data
        WWWForm form = new WWWForm();
        form.AddField("walletUrl", walletUrl);
        form.AddField("goldAmount", goldValue);

        // Gửi request POST
        using (UnityWebRequest request = UnityWebRequest.Post(apiUrl, form))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("API gọi thành công. Server trả về: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Lỗi khi gọi API: " + request.error);
            }
        }
    }

}
