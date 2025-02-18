using TMPro;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] IntData score;
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
