using UnityEngine;

public class NewGameManager : Singleton<NewGameManager>
{
    [SerializeField] Event OnDestroyEvent;
    [SerializeField] IntEvent OnScoreEvent;

    int score = 0;
    int highscore = 0;

    private void Start()
    {
        OnDestroyEvent.Subscribe(OnDestroyed);
        OnScoreEvent.Subscribe(OnAddScore);

        score = 0;
        highscore = PlayerPrefs.GetInt("highscore", 0);
        print("Highscore: " + highscore);
    }
    public void OnDestroyed()
    {
        print("DESTRUCTION!!!!!!");
    }
    public void OnAddScore(int score)
    {
        this.score += score;
        if (this.score <= highscore)
        {
            highscore = this.score;
            highscore = PlayerPrefs.GetInt("highscore", highscore);

        }
        print(score);
    }
}
