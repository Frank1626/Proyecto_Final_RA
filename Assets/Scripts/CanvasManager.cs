using System.Collections;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject Canvas_Binvenida;       // Primer canvas (bienvenida)
    public GameObject Canvas_Inspeccionar;    // Segundo canvas (contenido principal)
    public float tiempoDeEspera = 3f;         // Tiempo que se mostrará el canvas de bienvenida

    void Start()
    {
        StartCoroutine(CambiarCanvasDespuesDeTiempo());
    }

    IEnumerator CambiarCanvasDespuesDeTiempo()
    {
        Canvas_Binvenida.SetActive(true);
        Canvas_Inspeccionar.SetActive(false);

        yield return new WaitForSeconds(tiempoDeEspera);

        Canvas_Binvenida.SetActive(false);
        Canvas_Inspeccionar.SetActive(true);
    }
}
