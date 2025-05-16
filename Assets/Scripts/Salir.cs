using UnityEngine;
using System.Collections;

public class SalirApp : MonoBehaviour
{
    public GameObject canvasSalir;      // Panel de confirmación de salida
    public GameObject canvasDespedida;  // Panel con el mensaje de despedida

    public float tiempoDespedida = 2f;  // Tiempo antes de cerrar (en segundos)

    void Start()
    {
        // Asegura que los canvas estén desactivados al iniciar la escena
        if (canvasSalir != null)
            canvasSalir.SetActive(false);

        if (canvasDespedida != null)
            canvasDespedida.SetActive(false);
    }

    // Muestra el panel de confirmación
    public void MostrarCanvasSalir()
    {
        if (canvasSalir != null)
            canvasSalir.SetActive(true);
    }

    // Cancela la salida y oculta el panel de confirmación
    public void CancelarSalir()
    {
        if (canvasSalir != null)
            canvasSalir.SetActive(false);
    }

    // Confirma la salida: muestra el mensaje de despedida y cierra después de un tiempo
    public void ConfirmarSalida()
    {
        if (canvasSalir != null)
            canvasSalir.SetActive(false);

        if (canvasDespedida != null)
            canvasDespedida.SetActive(true);

        StartCoroutine(CerrarDespuesDeTiempo());
    }

    private IEnumerator CerrarDespuesDeTiempo()
    {
        yield return new WaitForSeconds(tiempoDespedida);
        Application.Quit(); // Solo funciona en build, no en el editor
        Debug.Log("Saliendo de la app...");
    }
}
