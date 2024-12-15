using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RetryGame() {
        SceneManager.LoadScene("EscenaGasolineraConIAGameManager");
    }

    public void ExitGame() {
        SceneManager.LoadScene("MainScene");
    }
}