using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public enum PlayerAction { Idle, Walking, Running, Action, Bend}
    public AudioSource backgroundMusic;
    public AudioSource nightSounds;
    public AudioSource monsterSound;
    public float pausedVolume = 0.2f;
    private float originalVolume;

    private bool isPaused = false;
    public PlayerAction currentAction = PlayerAction.Idle;
    public bool alive = true;

    void Awake(){
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else{
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();
    }
    
    public void PauseGame() {

        isPaused = !isPaused;
        if (isPaused) {
            originalVolume = monsterSound.volume;
            Time.timeScale = 0f;
            backgroundMusic.Pause();
            nightSounds.Pause();
            monsterSound.volume = pausedVolume;
            //SceneManager.LoadScene("EscenaMinijuegoCables");
            Debug.Log("Juego en pausa");
        }
        else {
            Time.timeScale = 1f;
            //SceneManager.LoadScene("EscenaGasolineraConIAGameManager");
            backgroundMusic.UnPause();
            nightSounds.UnPause();
            monsterSound.volume = originalVolume;
            Debug.Log("Juego reanudado");
        }
    }

    public void SetPlayerAction(PlayerAction action) {
        currentAction = action;
    }

    public void dead() {
        alive = false;

    }
}
