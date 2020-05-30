using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneLoader", menuName = "Utils/SceneInfo", order = 1)]
public class SceneInfo : ScriptableObject
{
    private Vector3 playerPosition;

    [SerializeField]
    private Vector3 defaultPlayerPosition;

    public void SetPlayerPosition(Vector3 position) {
        playerPosition = position;
    }

    public Vector3 GetPlayerPosition() {
        return playerPosition;
    }

    public void SetToDefault() {
        playerPosition = defaultPlayerPosition;
    }

}
