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
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text introText;
    [SerializeField] TMP_Text enemiesLeft;

    [SerializeField] Event OnDestroyEvent;
    [SerializeField] IntEvent OnScoreEvent;
    //[SerializeField] Event OnEnemyDeathEvent;
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
        LOSE
    }

    eState state = eState.TITLE;
    public void Start()
    {
        instance = this;

        score = 0;
        gameOverlay.SetActive(false);
        OnDestroyEvent.Subscribe(OnDestroyed);
        OnScoreEvent.Subscribe(OnScore);
        //OnEnemyDeathEvent.Subscribe(OnEnemyDeath);

        currentEnemies = enemyContainer.GetComponentsInChildren<Turrent>();
        enemyTotal = currentEnemies.Length;

        foreach (GameObject gameObject in objectsWithSFX)
        {
            if (gameObject.GetComponent<AudioSource>() != null)
            {
                gameObject.GetComponent<AudioSource>().mute = true;
            }
        }
    }
    void Update()
    {
        switch (state)
        {
            case eState.TITLE:
                titleUI.SetActive(true);
                break;
            case eState.GAME:
                gameOverlay.SetActive(true);
                StartCoroutine(InstructionDelay(5f));
                break;
            case eState.WIN:
                gameOverlay.SetActive(false);
                winDisplay.SetActive(true);
                break;
            case eState.LOSE:
                gameOverlay.SetActive(false);
                loseDisplay.SetActive(true);
                break;
            default:
                break;
        }
    }


    public void StartButton_clicked()
    {
        titleUI.SetActive(false);
        state = eState.GAME;
        foreach (GameObject gameObject in objectsWithSFX)
        {
            if (gameObject.GetComponent<AudioSource>() != null)
            {
                gameObject.GetComponent<AudioSource>().mute = false;
            }
        }
    }
    public void SetGameOver()
    {
        foreach (Turrent enemy in currentEnemies)
        {
            Destroy(enemy);
        }
        state = eState.LOSE;
    }

    public void OnDestroyed()
    {
        if (currentEnemies.Length == 0)
        {
            state = eState.WIN;
        }
    }
    public void OnScore(int score)
    {
        this.score += score;
        scoreText.text = "Score: " + score.ToString();
        print(score);
    }
    public void OnEnemyDeath()
    {
        currentEnemies = enemyContainer.GetComponentsInChildren<Turrent>();
        enemiesLeft.text = "Enemies Left: " + currentEnemies.Length.ToString() + "/" + enemyTotal.ToString();
    }
    IEnumerator InstructionDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        introText.gameObject.SetActive(false);
    }
}

