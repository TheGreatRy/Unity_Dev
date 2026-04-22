using JetBrains.Annotations;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameOverlay;
    [SerializeField] GameObject loseDisplay;
    [SerializeField] GameObject winDisplay;
    [SerializeField] GameObject pauseDisplay;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text introText;
    [SerializeField] TMP_Text enemiesLeft;

    [SerializeField] Event OnUIUpdateEvent;
    [SerializeField] IntEvent OnScoreEvent;
    [SerializeField] GameObject[] objectsWithSFX;
    [SerializeField] GameObject enemyContainer;

    int score;
    float health;
    int enemyTotal;

    Turrent[] currentEnemies;


    enum eState
    {
        TITLE,
        GAME,
        WIN,
        LOSE,
        PAUSE
    }

    eState state = eState.TITLE;
    public void Start()
    {
        instance = this;

        score = 0;
        gameOverlay.SetActive(false);
        OnScoreEvent.Subscribe(OnScore);
        OnUIUpdateEvent.Subscribe(OnUIUpdate); 

        currentEnemies = enemyContainer.GetComponentsInChildren<Turrent>();
        enemyTotal = currentEnemies.Length;
        MainGameSFX(true);
    }
    void Update()
    {
    
        switch (state)
        {
            case eState.TITLE:
                titleUI.SetActive(true);
                break;
            case eState.GAME:
                titleUI.SetActive(false);
                pauseDisplay.SetActive(false);
                gameOverlay.SetActive(true);
                MainGameSFX(false);
                StartCoroutine(InstructionDelay(5f));
                OnUIUpdateEvent.RaiseEvent();
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    state = eState.PAUSE;
                }
                break;
            case eState.WIN:
                gameOverlay.SetActive(false);
                winDisplay.SetActive(true);
                MainGameSFX(true);
                break;
            case eState.LOSE:
                gameOverlay.SetActive(false);
                loseDisplay.SetActive(true);
                MainGameSFX(true);
                break;
            case eState.PAUSE:
                Time.timeScale = 0;
                gameOverlay.SetActive(false);
                pauseDisplay.SetActive(true);
                MainGameSFX(true);
                break;
            default:
                break;
        }
    }


    public void StartButton_clicked()
    {
        titleUI.SetActive(false);
        titleUI.GetComponent<AudioSource>().mute = true;
        MainGameSFX(false);

        state = eState.GAME;
    }

    public void ResumeButton_clicked()
    {
        gameOverlay.GetComponent<AudioSource>().mute = false;
        Time.timeScale = 1;
        state = eState.GAME;
    }
    public void QuitButton_clicked()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;    
    }
    public void SetGameOver()
    {
        foreach (Turrent enemy in currentEnemies)
        {
            Destroy(enemy);
        }
        
        state = eState.LOSE;
    }
    
    public void OnScore(int score)
    {
        this.score += score;
        scoreText.text = "Score: " + this.score.ToString();
    }
    public void OnUIUpdate()
    {
        currentEnemies = enemyContainer.GetComponentsInChildren<Turrent>();
        enemiesLeft.text = "Enemies Left: " + currentEnemies.Length.ToString() + "/" + enemyTotal.ToString();

        if (currentEnemies.Length == 0)
        {
            state = eState.WIN;
        }
    }
    IEnumerator InstructionDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        introText.gameObject.SetActive(false);
    }
    private void MainGameSFX(bool isMuted)
    {
        foreach (GameObject gameObject in objectsWithSFX)
        {
            if (gameObject.GetComponent<AudioSource>() != null)
            {
                gameObject.GetComponent<AudioSource>().mute = isMuted;
            }
        }
    }
    public bool IsInGame()
    {
        return state == eState.GAME;
    }
}

