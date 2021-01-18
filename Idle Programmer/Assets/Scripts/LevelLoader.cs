using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    private CanvasGroup canvasGroup;
    public float transitionTime = 1f;

    private void Awake()
    {
        GameObject[] doNotDestroy = GameObject.FindGameObjectsWithTag("DoNotDestroy");

        for (int i = 0; i < doNotDestroy.Length; i++)
        DontDestroyOnLoad(doNotDestroy[i]);


    }

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;
    }
    public void LoadLevel(int levelIndex)
    {
        StartCoroutine(Loadlevel(levelIndex));
    }

    public IEnumerator Loadlevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        canvasGroup.interactable = true;

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
