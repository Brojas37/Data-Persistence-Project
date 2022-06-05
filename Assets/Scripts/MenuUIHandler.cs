using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    private string username;
    public Text bestScore;

    private void Start()
    {
        UpdateScore();
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GetName(string n)
    {
        username = n;
        Manager.Instance.name = username;
        UpdateScore();
    }

    public void UpdateScore()
    {
        bestScore.text = "Best Score";
        if (Manager.Instance.highScore > 0)
        {
            bestScore.text += " : " + Manager.Instance.highScoreName + " : " + Manager.Instance.highScore;
        } else
        {
            bestScore.text += " : " + Manager.Instance.name;
        }
    }
}
