using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {
    public GameObject warningPanel;

    void Start() {
        warningPanel.SetActive(false);
    }

    public void OnExitPressed() {
        warningPanel.SetActive(true);
    }

    public void OnConfirmExit() {
        Debug.Log("Saliendo del juego al menú inicial");
        SceneManager.LoadScene("MainMenuScene");
    }

    public void OnCancelExit() {
        warningPanel.SetActive(false);
    }
}