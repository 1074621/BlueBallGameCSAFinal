using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public static void Menu() 
    {
        SceneManager.LoadScene("Menu");
        Cursor.visible = true;
    }

    public static void NextLevel() 
    {
        if ((SceneManager.GetActiveScene().buildIndex + 1) > (SceneManager.sceneCountInBuildSettings - 1))
        {
            Menu();
        }
        else 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public static void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cursor.visible = false;
    }

    public static void L1()
    {
        SceneManager.LoadScene("Level01");
        Cursor.visible = false;
    }

    public static void L2() 
    {
        SceneManager.LoadScene("Level02");
        Cursor.visible = false;
    }

    public static void L3()
    {
        SceneManager.LoadScene("Level03");
        Cursor.visible = false;
    }

    public static void Quit() 
    {
        Application.Quit();
    }
}
