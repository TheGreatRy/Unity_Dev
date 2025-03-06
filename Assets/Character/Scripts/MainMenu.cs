using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] StringEvent onLoadLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnLoadLevelGame(string levelName)
    {
        onLoadLevel.RaiseEvent(levelName);
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }
}
