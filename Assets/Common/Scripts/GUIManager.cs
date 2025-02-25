using TMPro;
using UnityEngine;

public class GUIManager : Singleton<GUIManager>
{
    [Header("Pause")]
    [SerializeField] GameObject pauseUI;
    [SerializeField] BoolEvent onPauseEvent;
    [SerializeField] StringEvent onLoadMainMenuEvent;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] IntData score;

    private void Start()
    {
        onPauseEvent?.Subscribe(OnPause);
    }

    void Update()
    {
        scoreText.text = score.Value.ToString("0000");
    }

    public void OnPause(bool pause)
    {
        pauseUI.SetActive(pause);
        Time.timeScale = (pause) ? 0 : 1;
        Cursor.visible = pause;
        Cursor.lockState = (pause) ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void OnResumeButton()
    {
        OnPause(false);
    }

    public void OnQuitButton()
    {
        onLoadMainMenuEvent.RaiseEvent("MainMenu");
    }
}
