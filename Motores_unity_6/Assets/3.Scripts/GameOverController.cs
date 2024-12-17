using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void RetryGame() {
        SceneManager.LoadScene("EscenaGasolineraConIAGameManager");
    }

    public void ExitGame() {
        SceneManager.LoadScene("MainScene");
    }
}