using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUI : MonoBehaviour
{
    public void BackToMenu()
    {
        StartCoroutine(LoadSceneAsync(0));
    }

    public void SwitchScene()
    {
        int sceneId = SceneManager.GetActiveScene().buildIndex + 1;

        if (sceneId == 5)
            StartCoroutine(LoadSceneAsync(1));

        else StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
