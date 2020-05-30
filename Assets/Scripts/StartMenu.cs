using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private SceneLoader townLoader;

    [SerializeField]
    private ItemCollection inventory;

    public void OnStartClicked() {
        ClearPlayerSOs();

        townLoader.Load();
    }

    private void ClearPlayerSOs() {
        inventory.Clear(); //While there is no saving of course

    }
}
