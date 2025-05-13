using System.Collections;
using UnityEngine;

public class CanvasFadeManager : MonoBehaviour
{
    public CanvasGroup bienvenidaGroup;
    public GameObject Canvas_Inspeccionar;

    public float tiempoVisible = 3f;   // Tiempo antes de empezar el fade-out
    public float tiempoFade = 1.5f;    // Duración del fade-out

    void Start()
    {
        StartCoroutine(FadeOutSequence());
    }

    IEnumerator FadeOutSequence()
    {
        bienvenidaGroup.alpha = 1f;
        bienvenidaGroup.gameObject.SetActive(true);
        Canvas_Inspeccionar.SetActive(false);

        yield return new WaitForSeconds(tiempoVisible);

        float elapsed = 0f;
        while (elapsed < tiempoFade)
        {
            float t = elapsed / tiempoFade;
            bienvenidaGroup.alpha = Mathf.Lerp(1f, 0f, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        bienvenidaGroup.alpha = 0f;

        bienvenidaGroup.gameObject.SetActive(false);
        Canvas_Inspeccionar.SetActive(true);
    }
}
