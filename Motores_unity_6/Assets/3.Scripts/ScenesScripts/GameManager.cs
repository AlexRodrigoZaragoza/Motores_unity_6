using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public enum PlayerAction { Idle, Walking, Running, Action, Bend }
    public PlayerAction currentAction = PlayerAction.Idle;
    PlayerController playerController;

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
    public bool canmoveCamera;

    [Header("Minigames")]
    public bool miniGameTiresCompleted = false;
    public bool miniGameSparkPlugCompleted = false;
    public bool allTiresColected = false;
    public GameObject miniGameCarCanvas;

    void Awake()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        warningPanel.SetActive(false);
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        if (miniGameTiresCompleted && miniGameSparkPlugCompleted)
        {
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Todos los minijuegos completos, saliendo del juego");
            SceneManager.LoadScene("MainScene");
            DestroyGameManager();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isPaused == false)
            {
                canmoveCamera = false;
                warningPanel.SetActive(false);
                pauseMenu.SetActive(true);
                originalVolume = monsterSound.volume;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                backgroundMusic.Pause();
                nightSounds.Pause();
                monsterSound.volume = pausedVolume;
                isPaused = true;
                Debug.Log("Juego en pausa");
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
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("El jugador ha muerto");
        SceneManager.LoadScene("GameOver");
    }

    public void OnResumePressed()
    {
        canmoveCamera = true;
        warningPanel.SetActive(false);
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        backgroundMusic.UnPause();
        nightSounds.UnPause();
        monsterSound.volume = originalVolume;
        isPaused = false;
        Debug.Log("Juego reanudado");
    }

    public void OnExitPressed()
    {
        Debug.Log("Saliendo del juego al menú inicial");
        SceneManager.LoadScene("MainScene");
        DestroyGameManager();
    }

    public void OnConfirmExit()
    {
        //pauseMenu.SetActive(false);
        //warningPanel.SetActive(true);

    }

    public void OnCancelExit()
    {
        //warningPanel.SetActive(false);
        //pauseMenu.SetActive(true);
    }

    public void miniGameCar()
    {
        if (allTiresColected && !miniGameTiresCompleted)
        {
            miniGameCarCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

        else if (miniGameTiresCompleted)
        {
            miniGameCarCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        else
            Debug.Log("Faltan ruedas");
    }
}