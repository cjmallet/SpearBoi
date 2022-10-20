using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scene activeScene = SceneManager.GetActiveScene();

        switch (activeScene.name)
        {
            case ("Tutorial"):
                SceneManager.LoadScene("Level1");
                break;

            case ("Level1"):
                //SceneManager.LoadScene("Level2");
                break;

        }
    }
}
