using UnityEngine;
using UnityEngine.UI;

public class MenuWallet : MonoBehaviour
{
    [SerializeField] GameObject WalletMenu;
    public InputField inputField;

    public void Save() {
        WalletUrl.Instance.globalWallet = inputField.text;
        Debug.Log("Nội dung từ Input Field: " + inputField.text);
    }

    public void Back() {
        WalletMenu.SetActive(false);
    }
}
