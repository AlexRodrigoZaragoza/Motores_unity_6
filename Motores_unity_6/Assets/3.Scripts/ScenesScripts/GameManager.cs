using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public enum PlayerAction { Idle, Walking, Running, Action, Bend }
    public PlayerAction currentAction = PlayerAction.Idle;

    public AudioSource backgroundMusic;
    public AudioSource nightSounds;
    public AudioSource monsterSound;
    public float pausedVolume = 0.2f;
    private float originalVolume;

    public GameObject warningPanel;
    public GameObject pauseMenu;
    public GameObject resume;
    public GameObject exit;
    public GameObject confirmExit;
    public GameObject cancelExit;
    public bool isPaused = false;

    [Header("Minigames")]
    public bool miniGameTiresCompleted = false;
    public bool miniGameSparkPlugCompleted = false;
    public bool allTiresColected = false;
    public GameObject miniGameCarCanvas;

    void Awake()
    {

        warningPanel.SetActive(false);
        pauseMenu.SetActive(false);
    }

    void Update()
    {

        if (miniGameTiresCompleted && miniGameSparkPlugCompleted)
        {
            Debug.Log("Todos los minijuegos completos, saliendo del juego");
            SceneManager.LoadScene("MainScene");
            DestroyGameManager();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                warningPanel.SetActive(false);
                pauseMenu.SetActive(true);
                originalVolume = monsterSound.volume;
                Time.timeScale = 0f;
                backgroundMusic.Pause();
                nightSounds.Pause();
                monsterSound.volume = pausedVolume;
                isPaused = true;
                Debug.Log("Juego en pausa");
            }
            else
            {
                OnResumePressed();
            }
        }
    }

    public void SetPlayerAction(PlayerAction action)
    {
        currentAction = action;
    }

    public void DestroyGameManager()
    {
        Destroy(gameObject);

    }

    public void Die()
    {
        Debug.Log("El jugador ha muerto");
        SceneManager.LoadScene("GameOver");
    }

    public void OnResumePressed()
    {
        warningPanel.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        backgroundMusic.UnPause();
        nightSounds.UnPause();
        monsterSound.volume = originalVolume;
        isPaused = false;
        Debug.Log("Juego reanudado");
    }

    public void OnExitPressed()
    {
        pauseMenu.SetActive(false);
        warningPanel.SetActive(true);
    }

    public void OnConfirmExit()
    {
        Debug.Log("Saliendo del juego al menú inicial");
        DestroyGameManager();
        SceneManager.LoadScene("MainScene");
    }

    public void OnCancelExit()
    {
        warningPanel.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void miniGameCar()
    {
        if (allTiresColected && !miniGameTiresCompleted)
            miniGameCarCanvas.SetActive(true);
        else if (miniGameTiresCompleted)
            miniGameCarCanvas.SetActive(false);
        else
            Debug.Log("Faltan ruedas");
    }
}