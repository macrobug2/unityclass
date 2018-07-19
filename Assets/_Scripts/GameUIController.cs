using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    public void QuitApplication()
    {
        Application.Quit();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
