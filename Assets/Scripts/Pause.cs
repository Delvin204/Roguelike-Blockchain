using UnityEngine;
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

}
