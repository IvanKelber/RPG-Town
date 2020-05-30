using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    public SceneInfo[] scenes;

    public ItemCollection playerInventory;
    public Equipment playerEquipment;
    public PrimaryStats playerBaseStats;

    public SceneLoader townLoader;

    public void NewStart() {
        foreach(SceneInfo scene in scenes) {
            scene.SetToDefault();
        }
        playerInventory.Clear();
        playerEquipment.Clear();
        playerBaseStats.Default();
        townLoader.Load();
    }
}
