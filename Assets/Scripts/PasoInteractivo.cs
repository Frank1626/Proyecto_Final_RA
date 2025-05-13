using UnityEngine;

public class PasoInteractivo : MonoBehaviour
{
    public Animator animador;
    public GameObject[] pasosCanvas; // Paneles dentro de un solo Canvas (por paso)
    public GameObject botonInspeccionar; // Botón Inspeccionar
    public GameObject botonSiguiente; // Botón Siguiente
    public GameObject botonAnterior; // Botón Anterior
    private int pasoActual = 0;
    private bool animacionEnCurso = false; // Para saber si la animación está en curso

    void Start()
    {
        MostrarPaso(pasoActual);
        ActualizarBotones();
    }

    void Update()
    {
        // Verificamos si la animación actual ha terminado para poder avanzar
        if (animador.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !animacionEnCurso)
        {
            animacionEnCurso = false;
        }
    }

    // Método para el botón "Siguiente"
    public void SiguientePaso()
    {
        // Asegúrate de que la animación haya terminado antes de continuar
        if (!animacionEnCurso)
        {
            // Oculta el paso actual
            pasosCanvas[pasoActual].SetActive(false);

            pasoActual++;

            // Si hay más pasos, reproducir la animación y mostrar el siguiente paso
            if (pasoActual < pasosCanvas.Length)
            {
                animacionEnCurso = true; // Iniciamos que la animación está en curso
                animador.Play(pasoActual.ToString(), 0, 0f); // Reproducir animación
                MostrarPaso(pasoActual);
                ActualizarBotones();
            }
            else
            {
                Debug.Log("Fin de la secuencia.");
            }
        }
    }

    // Método para el botón "Anterior"
    public void AnteriorPaso()
    {
        // Asegúrate de que la animación haya terminado antes de retroceder
        if (!animacionEnCurso)
        {
            // Oculta el paso actual
            pasosCanvas[pasoActual].SetActive(false);

            pasoActual--;

            // Si hay pasos anteriores, reproducir la animación y mostrar el paso anterior
            if (pasoActual >= 0)
            {
                animacionEnCurso = true; // Iniciamos que la animación está en curso
                animador.Play(pasoActual.ToString(), 0, 0f); // Reproducir animación
                MostrarPaso(pasoActual);
                ActualizarBotones();
            }
            else
            {
                Debug.Log("Ya estás en el primer paso.");
            }
        }
    }

    // Método para mostrar el paso correspondiente
    private void MostrarPaso(int index)
    {
        if (index >= 0 && index < pasosCanvas.Length)
        {
            pasosCanvas[index].SetActive(true);
        }
    }

    // Método para actualizar la visibilidad de los botones según el paso actual
    private void ActualizarBotones()
    {
        // Mostrar botón Inspeccionar solo en el primer paso
        if (pasoActual == 0)
        {
            botonInspeccionar.SetActive(true);
            botonAnterior.SetActive(false); // No mostrar el botón Anterior en el primer paso
            botonSiguiente.SetActive(true); // Mostrar botón Siguiente en el primer paso
        }
        else
        {
            botonInspeccionar.SetActive(false); // Ocultar el botón Inspeccionar en los demás pasos
            botonAnterior.SetActive(true); // Mostrar el botón Anterior en los demás pasos
            botonSiguiente.SetActive(true); // Asegurar que el botón Siguiente esté disponible en los demás pasos
        }

        // Si estamos en el último paso, desactivar el botón Siguiente
        if (pasoActual == pasosCanvas.Length - 1)
        {
            botonSiguiente.SetActive(false); // Desactivar el botón "Siguiente" al estar en el último paso
        }
        else if (pasoActual < pasosCanvas.Length - 1)
        {
            botonSiguiente.SetActive(true); // Asegurarse que el botón "Siguiente" esté activo si no estamos en el último paso
        }
    }
}
