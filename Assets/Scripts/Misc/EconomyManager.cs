using UnityEngine;
using TMPro;

public class EconomyManager : Singleton<EconomyManager>
{
    private TMP_Text goldText;
    public int currentGold;

    const string COIN_AMOUNT_TEXT = "Gold Amount Text";

    private void Start()
    {
        // Khởi tạo `currentGold` từ WalletUrl.Instance
        currentGold = WalletUrl.Instance != null ? WalletUrl.Instance.goldText : 0;

        // Tìm đối tượng `goldText`
        GameObject textObject = GameObject.Find(COIN_AMOUNT_TEXT);
        if (textObject != null)
        {
            goldText = textObject.GetComponent<TMP_Text>();
            if (goldText == null)
            {
                Debug.LogError("GameObject không chứa TMP_Text component!");
            }
        }
        else
        {
            Debug.LogError($"Không tìm thấy GameObject với tên: {COIN_AMOUNT_TEXT}");
        }
    }

    public void UpdateCurrentGold()
    {
        currentGold += 1;
        if (WalletUrl.Instance != null)
        {
            WalletUrl.Instance.goldText += 1;
        }

        if (goldText != null)
        {
            goldText.text = currentGold.ToString("D3");
        }
        else
        {
            Debug.LogError("goldText chưa được gán giá trị!");
        }
    }
}
