using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WalletUrl : MonoBehaviour
{
    // Instance Singleton
    public static WalletUrl Instance;

    // Biến toàn cục
    public string globalWallet = "";
    public int goldText;

    private void Awake()
    {
        // Đảm bảo chỉ có một instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Không bị xóa khi chuyển scene
        }
        else
        {
            Destroy(gameObject);
        }

        StartCoroutine(LoadGoldValueAndStartGame());
    }

    private IEnumerator LoadGoldValueAndStartGame()
    {
        // URL của API (thay thế bằng URL thực tế)
        string apiUrl = "http://localhost:8080/roguelike/loadCoin";
        string walletUrl = globalWallet;
        do
        {
            if (!string.IsNullOrEmpty(walletUrl))
            {
                string requestUrl = $"{apiUrl}?walletUrl={UnityWebRequest.EscapeURL(walletUrl)}";

                using (UnityWebRequest request = UnityWebRequest.Get(requestUrl))
                {
                    yield return request.SendWebRequest();

                    if (request.result == UnityWebRequest.Result.Success)
                    {
                        Debug.Log("API gọi thành công. Server trả về: " + request.downloadHandler.text);

                        if (int.TryParse(request.downloadHandler.text, out int coinAmount))
                        {
                            goldText = coinAmount;
                            Debug.Log($"Số vàng trong ví: {goldText}");
                        }
                        else
                        {
                            Debug.LogError("Không thể parse số vàng từ kết quả API.");
                        }
                    }
                    else
                    {
                        Debug.LogError("Lỗi khi gọi API: " + request.error);
                    }
                }
            }
            else
            {
                Debug.LogWarning("walletUrl chưa được gán giá trị hợp lệ.");
                yield return null; // Đợi một frame để tránh treo chương trình
            }
        } while (string.IsNullOrEmpty(walletUrl)); // Lặp đến khi walletUrl có giá trị

    }
}
