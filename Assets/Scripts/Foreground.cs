using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(Renderer))]
public class Foreground : MonoBehaviour
{
    [SerializeField]
    [Range(0,1)]
    private float fadedOpacity;

    [SerializeField]
    [Range(0,1)]
    private float fadeDelay;
    private Color originalColor;

    private Renderer renderer;
    private void Awake() {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }
    public void FadeOpacity() {
        StopAllCoroutines();
        StartCoroutine(DoFade());
    }

    public IEnumerator DoFade() {
        Color fadedColor = new Color(originalColor.r, originalColor.g, originalColor.b, fadedOpacity);
        renderer.material.color = fadedColor;
        yield return new WaitForSeconds(fadeDelay);
        renderer.material.color = originalColor;
    }
}
