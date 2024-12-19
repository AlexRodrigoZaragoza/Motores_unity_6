using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void EnterGame()
    {
        SceneManager.LoadScene("EscenaGasolineraConIA");
    }

    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}