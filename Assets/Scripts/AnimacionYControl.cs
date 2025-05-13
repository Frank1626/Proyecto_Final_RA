using UnityEngine;

public class AnimacionYControlCanvas : MonoBehaviour
{
    public Animator animador;                  // Referencia al Animator
    public GameObject canvasPasosSiguientes;   // Referencia al Canvas de pasos siguientes
    public GameObject canvasInspeccionar;      // Referencia al Canvas de inspección

    private int indicePaso = 0;                // Índice del paso actual
    private string[] animaciones = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" }; // Lista de animaciones, puedes ajustarlas según tus animaciones

    // Método para reproducir la animación dependiendo del paso actual
    public void ReproducirAnimacion()
    {
        if (indicePaso >= 0 && indicePaso < animaciones.Length)
        {
            animador.Play(animaciones[indicePaso], 0, 0f);  // Reproduce la animación correspondiente al paso
        }
    }

    // Método para ir al siguiente paso (Canvas y Animación)
    public void SiguientePaso()
    {
        if (indicePaso < animaciones.Length - 1)  // Asegurarse de no exceder el límite
        {
            indicePaso++;  // Incrementar el paso
            ReproducirAnimacion();  // Reproducir la animación para el paso siguiente
            MostrarCanvasPasosSiguientes();  // Cambiar al siguiente Canvas
        }
    }

    // Método para ir al paso anterior (Canvas y Animación)
    public void PasoAnterior()
    {
        if (indicePaso > 0)  // Asegurarse de no retroceder más allá del primer paso
        {
            indicePaso--;  // Decrementar el paso
            ReproducirAnimacion();  // Reproducir la animación para el paso anterior
            MostrarCanvasPasosSiguientes();  // Volver al Canvas de pasos anteriores
        }
    }

    // Método para ir al Canvas de inspección
    public void MostrarCanvasInspeccionar()
    {
        canvasPasosSiguientes.SetActive(false);  // Desactivar el Canvas de pasos siguientes
        canvasInspeccionar.SetActive(true);       // Activar el Canvas de inspección
    }

    // Método para ir al Canvas de pasos siguientes
    public void MostrarCanvasPasosSiguientes()
    {
        canvasInspeccionar.SetActive(false);      // Desactivar el Canvas de inspección
        canvasPasosSiguientes.SetActive(true);   // Activar el Canvas de pasos siguientes
    }
}
