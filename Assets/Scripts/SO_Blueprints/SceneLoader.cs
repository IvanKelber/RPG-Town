using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "SceneLoader", menuName = "Utils/SceneLoader", order = 1)]
public class SceneLoader : ScriptableObject
{
    [SerializeField]
    private int sceneToLoad;

    public void Load() {
        SceneManager.LoadScene(sceneToLoad);
    }
}
