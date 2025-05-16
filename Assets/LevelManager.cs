using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load when clicked.
    public blackScreen blackScreen;
    public bool gavel;


    public void loadScene()
    {
        StartCoroutine(load());
    }

    IEnumerator load()
    {
        if(gavel)
        {
            blackScreen.gavelScreenEnter();
        }
        else
        {
            blackScreen.screenEnter();
        }
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneToLoad);
    }
}
