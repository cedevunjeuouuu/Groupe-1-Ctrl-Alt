using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text text1;
    [SerializeField] private TMP_Text text2;
    [SerializeField] private TMP_Text text3;
    public void OnLaunch(InputValue inputValue)
    {
        SceneManager.LoadScene(1);
    }

    void Start()
    {
        text1.text = PlayerPrefs.GetInt("highScore1").ToString();
        text2.text = PlayerPrefs.GetInt("highScore2").ToString();
        text3.text = PlayerPrefs.GetInt("highScore3").ToString();
    }
}
