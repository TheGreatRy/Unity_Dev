using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameOverlay;
    [SerializeField] TMP_Text scoreText;

    [SerializeField] GameObject[] objectsWithSFX;
    [SerializeField] Event OnDestroyEvent;
    [SerializeField] IntEvent OnScoreEvent;

    int score;
    float health;

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
        score = 0;
        gameOverlay.SetActive(false);
        OnDestroyEvent.Subscribe(OnDestroyed);
        OnScoreEvent.Subscribe(OnScore);

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
                break;
            case eState.WIN:
                print("win!");
                break;
            case eState.LOSE:
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
        state = eState.WIN;

    }
    public void OnDestroyed()
    {
        print("DESTRUCTION!!!!!!");

    }
    public void OnScore(int score) 
    { 
        this.score += score;
        scoreText.text = "Score: " + score.ToString();
        print(score);
    }
}

