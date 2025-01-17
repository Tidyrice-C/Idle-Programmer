﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LLMAIN : MonoBehaviour
{
    public Animator transition;
    private CanvasGroup canvasGroup;
    public float transitionTime = 0.5f;

    private void Awake()
    {
        GameObject[] doNotDestroy = GameObject.FindGameObjectsWithTag("DoNotDestroy");

        for (int i = 0; i < doNotDestroy.Length; i++)
            DontDestroyOnLoad(doNotDestroy[i]);
    }

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;

        if (GameObject.FindGameObjectsWithTag("DoNotDestroy").Length > 2)
        {
            Destroy(GameObject.FindGameObjectsWithTag("DoNotDestroy")[0]);
            Destroy(GameObject.FindGameObjectsWithTag("DoNotDestroy")[1]);

        }
    }
    public void LoadLevel(int levelIndex)
    {
        StartCoroutine(Loadlevel(levelIndex));
    }

    public IEnumerator Loadlevel(int levelIndex)
    {
        canvasGroup.blocksRaycasts = true;
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
