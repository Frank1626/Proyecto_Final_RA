using UnityEngine;

public class AnimacionYControlCanvas : MonoBehaviour
{
    public Animator animador;

    public GameObject canvasBienvenida;
    public GameObject canvasInstrucciones;
    public GameObject canvasInspeccionar;
    public GameObject canvasPasosSiguientes;
    public GameObject canvasFinal; // NUEVO

    public Transform objetoConsola;

    private int indicePaso = 0;
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;

    private string[] animaciones = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19" };

    void Start()
    {
        if (objetoConsola != null)
        {
            posicionInicial = objetoConsola.position;
            rotacionInicial = objetoConsola.rotation;
        }

        canvasBienvenida.SetActive(true);
        canvasInstrucciones.SetActive(false);
        canvasInspeccionar.SetActive(false);
        canvasPasosSiguientes.SetActive(false);
        canvasFinal.SetActive(false); // NUEVO
    }

    public void MostrarCanvasInstrucciones()
    {
        canvasBienvenida.SetActive(false);
        canvasInstrucciones.SetActive(true);
        canvasInspeccionar.SetActive(false);
        canvasPasosSiguientes.SetActive(false);
        canvasFinal.SetActive(false);
    }

    public void MostrarCanvasInspeccionar()
    {
        canvasBienvenida.SetActive(false);
        canvasInstrucciones.SetActive(false);
        canvasInspeccionar.SetActive(true);
        canvasPasosSiguientes.SetActive(false);
        canvasFinal.SetActive(false);
    }

    public void MostrarCanvasPasosSiguientes()
    {
        canvasBienvenida.SetActive(false);
        canvasInstrucciones.SetActive(false);
        canvasInspeccionar.SetActive(false);
        canvasPasosSiguientes.SetActive(true);
        canvasFinal.SetActive(false);
    }

    // NUEVO MÉTODO
    public void MostrarCanvasFinal()
    {
        canvasBienvenida.SetActive(false);
        canvasInstrucciones.SetActive(false);
        canvasInspeccionar.SetActive(false);
        canvasPasosSiguientes.SetActive(false);
        canvasFinal.SetActive(true);
    }

    public void SiguientePaso()
    {
        if (indicePaso < animaciones.Length - 1)
        {
            indicePaso++;
            ReproducirAnimacion();
            MostrarCanvasPasosSiguientes();
        }
        else
        {
            MostrarCanvasFinal(); // Cuando termina, muestra canvasFinal
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

            animador.Play("Idle", 0, 0f);

            if (objetoConsola != null)
            {
                objetoConsola.position = posicionInicial;
                objetoConsola.rotation = rotacionInicial;
            }
        }
    }

    private void ReproducirAnimacion()
    {
        if (indicePaso == 0)
        {
            animador.Play("1", 0, 0f);
        }
        else if (indicePaso >= 0 && indicePaso < animaciones.Length)
        {
            animador.Play(animaciones[indicePaso], 0, 0f);
        }
    }

    // MÉTODO DE REINICIO PARA BOTÓN
    public void Reiniciar()
    {
        indicePaso = 0;

        MostrarCanvasInspeccionar();

        animador.Play("Idle", 0, 0f);

        if (objetoConsola != null)
        {
            objetoConsola.position = posicionInicial;
            objetoConsola.rotation = rotacionInicial;
        }
    }
}
