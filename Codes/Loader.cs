using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneEnum
{
    Loading = 0,
    MainMenu = 1,
    GameScene = 2,
}

public class Loader : MonoBehaviour
{
    public static Loader Instance;
    public static bool isSceneLoaded;
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    [SerializeField] GameObject loadingScreen;

    private void Awake()
    {
        Instance = this;
        loadingScreen.SetActive(true);
        isSceneLoaded = false;
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneEnum.MainMenu, LoadSceneMode.Additive));
        StartCoroutine(GetSceneLoadProgress(SceneManager.GetSceneByBuildIndex(1)));
    }

    public void LoadGame()
    {
        scenesLoading.Clear();
        loadingScreen.SetActive(true);
        isSceneLoaded = false;
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneEnum.MainMenu));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneEnum.GameScene, LoadSceneMode.Additive));
        StartCoroutine(GetSceneLoadProgress(SceneManager.GetSceneByBuildIndex(2)));
    }

    public void LoadMenu()
    {
        scenesLoading.Clear();
        loadingScreen.SetActive(true);
        isSceneLoaded = false;
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneEnum.GameScene));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneEnum.MainMenu, LoadSceneMode.Additive));
        StartCoroutine(GetSceneLoadProgress(SceneManager.GetSceneByBuildIndex(1)));
    }

    public IEnumerator GetSceneLoadProgress(Scene scene)
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return null;
            }
        }
        loadingScreen.SetActive(false);
        SceneManager.SetActiveScene(scene);
        isSceneLoaded = true;
    }
}
