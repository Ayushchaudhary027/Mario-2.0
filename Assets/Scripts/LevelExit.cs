using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLoadScene = currentSceneIndex + 1;
        if (nextLoadScene == SceneManager.sceneCountInBuildSettings)
        {
            nextLoadScene = 0;
        }
        FindObjectOfType<ScenePresist>().ResetScenePersist();
        SceneManager.LoadScene(nextLoadScene);
    }
}
