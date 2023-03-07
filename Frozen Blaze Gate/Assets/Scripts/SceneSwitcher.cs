using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    Animator animator;
    int launchHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        launchHash = Animator.StringToHash("launch");
    }

    public void PlayGame()
    {
        StartCoroutine(WaitAndStart(5.0f));
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // wait and start
    private IEnumerator WaitAndStart(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
        }
    }
}
