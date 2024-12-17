using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {
    public GameObject warningPanel;
    public GameObject pauseMenu;
    public GameObject resume;
    public GameObject exit;
    public GameObject confirmExit;
    public GameObject cancelExit;

    void Start() {
        warningPanel.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void OnResumePressed() {
        SceneManager.LoadScene("EscenaGasolineraConIAGameManager");
    }

    public void OnExitPressed() {
        pauseMenu.SetActive(false);
        warningPanel.SetActive(true);
    }

    public void OnConfirmExit() {
        Debug.Log("Saliendo del juego al menú inicial");
        GameManager.Instance.DestroyGameManager();
        SceneManager.LoadScene("EscenaGasolineraConIAGameManager");
    }

    public void OnCancelExit() {
        warningPanel.SetActive(false);
        pauseMenu.SetActive(true);
    }
}