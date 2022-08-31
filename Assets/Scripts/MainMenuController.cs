using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Created By : Galih Tyas A");
    }

    public void OpenAuthor()
    {
        Debug.Log("Created By : Galih Tyas A");
    }
}
