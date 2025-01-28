using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainLevel", LoadSceneMode.Single);
    }

    public void ReloadLevel()
    {
        StartCoroutine(ReloadSceneRoutine());
    }

    IEnumerator ReloadSceneRoutine()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("ReloadLevel", LoadSceneMode.Single);        
    }
}
