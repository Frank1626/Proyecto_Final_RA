using UnityEngine;

public class AnimacionYControlCanvas : MonoBehaviour
{
    public Animator animador;                   // Animator del objeto
    public GameObject canvasBienvenida;         // Canvas de bienvenida
    public GameObject canvasInspeccionar;       // Canvas con botón de inspeccionar
    public GameObject canvasPasosSiguientes;    // Canvas con botones siguiente/anterior

    public Transform objetoConsola;             // Objeto que se anima (si quieres reiniciar posición/rotación)

    private int indicePaso = 0;                 // Paso actual
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;

    private string[] animaciones = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };

    void Start()
    {
        // Guardar transformaciones originales
        if (objetoConsola != null)
        {
            posicionInicial = objetoConsola.position;
            rotacionInicial = objetoConsola.rotation;
        }

        // Al iniciar, mostrar solo el canvas de bienvenida
        canvasBienvenida.SetActive(true);
        canvasInspeccionar.SetActive(false);
        canvasPasosSiguientes.SetActive(false);

        // Puedes desactivar bienvenida automáticamente después de unos segundos si deseas
        Invoke(nameof(MostrarCanvasInspeccionar), 3f);
    }

    public void MostrarCanvasInspeccionar()
    {
        canvasBienvenida.SetActive(false);
        canvasInspeccionar.SetActive(true);
        canvasPasosSiguientes.SetActive(false);
    }

    public void MostrarCanvasPasosSiguientes()
    {
        canvasBienvenida.SetActive(false);
        canvasInspeccionar.SetActive(false);
        canvasPasosSiguientes.SetActive(true);
    }

    public void SiguientePaso()
    {
        if (indicePaso < animaciones.Length - 1)
        {
            indicePaso++;
            ReproducirAnimacion();
            MostrarCanvasPasosSiguientes();
        }
    }

    public void PasoAnterior()
    {
        if (indicePaso > 1)
        {
            indicePaso--;
            ReproducirAnimacion();
            MostrarCanvasPasosSiguientes();
        }
        else if (indicePaso == 1)
        {
            indicePaso = 0;
            MostrarCanvasInspeccionar();

            // Opcional: reproducir animación "Idle"
            animador.Play("Idle", 0, 0f);

            // Reiniciar posición/rotación del objeto si es necesario
            if (objetoConsola != null)
            {
                objetoConsola.position = posicionInicial;
                objetoConsola.rotation = rotacionInicial;
            }
        }
    }

    private void ReproducirAnimacion()
    {
        // Comprobamos si la animación es "1" para asegurarnos que no se salte
        if (indicePaso == 0)
        {
            animador.Play("1", 0, 0f);  // Reproduce animación "1" sin importar el estado anterior
        }
        else if (indicePaso >= 0 && indicePaso < animaciones.Length)
        {
            // Para otras animaciones, se continúa con el flujo
            animador.Play(animaciones[indicePaso], 0, 0f);
        }
    }
}
