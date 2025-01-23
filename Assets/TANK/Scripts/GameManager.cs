using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    [SerializeField] GameObject titleUI;

    enum eState
    {
        TITLE,
        GAME,
        WIN,
        LOSE
    }

    eState state = eState.TITLE;
    void Update()
    {
        switch (state)
        {
            case eState.TITLE:
                titleUI.SetActive(true);
                break;
            case eState.GAME:
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
    public void OnStartGame()
    {
        titleUI.SetActive(false);
        state = eState.GAME;

    }
    public void SetGameOver()
    {
        state = eState.WIN;

    }
}

