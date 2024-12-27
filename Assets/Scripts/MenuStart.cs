using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    [SerializeField] GameObject WalletMenu;

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void LinkWallet()
    {
        WalletMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
