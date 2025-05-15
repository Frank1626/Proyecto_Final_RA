using System.Collections;
using UnityEngine;

public class CanvasFadeManager : MonoBehaviour
{
    public CanvasGroup bienvenidaGroup;
    public CanvasGroup instruccionesGroup;

    public GameObject Canvas_Inspeccionar;

    public float tiempoVisible = 3f;   // Tiempo visible para bienvenida
    public float tiempoFade = 1.5f;    // Duración de fade

    void Start()
    {
        StartCoroutine(SecuenciaBienvenida());
    }

    IEnumerator SecuenciaBienvenida()
    {
        bienvenidaGroup.alpha = 1f;
        bienvenidaGroup.gameObject.SetActive(true);
        instruccionesGroup.gameObject.SetActive(false);
        Canvas_Inspeccionar.SetActive(false);

        yield return new WaitForSeconds(tiempoVisible);

        // Fade-out bienvenida
        float elapsed = 0f;
        while (elapsed < tiempoFade)
        {
            bienvenidaGroup.alpha = Mathf.Lerp(1f, 0f, elapsed / tiempoFade);
            elapsed += Time.deltaTime;
            yield return null;
        }
        bienvenidaGroup.alpha = 0f;
        bienvenidaGroup.gameObject.SetActive(false);

        // Activar instrucciones (sin fade por ahora)
        instruccionesGroup.alpha = 1f;
        instruccionesGroup.gameObject.SetActive(true);
    }

    // Llama esto desde un botón en el Canvas_Instrucciones
    public void IrAInspeccionar()
    {
        instruccionesGroup.gameObject.SetActive(false);
        Canvas_Inspeccionar.SetActive(true);
    }
}
