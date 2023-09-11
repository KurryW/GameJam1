using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadsceneAll : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSceneButton()
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("GOGOGOGO SCENE");
        SceneManager.LoadScene("Victory");
    }
}
