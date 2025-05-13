using UnityEngine;

public class AnimacionConsola : MonoBehaviour
{
    public Animator animador;

    // Reproduce una animación por nombre (por ejemplo, "1", "2", "3"...)
    public void ReproducirAnimacionPorNombre(string nombreAnimacion)
    {
        animador.Play(nombreAnimacion, 0, 0f);
    }

    // Reproduce una animación por número (entero) convirtiéndolo en string
    public void ReproducirAnimacionPorNumero(int numeroAnimacion)
    {
        string nombre = numeroAnimacion.ToString();
        animador.Play(nombre, 0, 0f);
    }
}
