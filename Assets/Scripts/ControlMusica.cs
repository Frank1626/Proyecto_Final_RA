using UnityEngine;

public class ControlMusica : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] canciones;
    private int indiceActual = 0;
    private bool estaSilenciado = false;

    void Start()
    {
        if (canciones.Length > 0)
        {
            audioSource.clip = canciones[indiceActual];
            audioSource.Play();
        }
    }

    public void SilenciarMusica()
    {
        estaSilenciado = !estaSilenciado;
        audioSource.mute = estaSilenciado;
    }

    public void SiguienteCancion()
    {
        if (canciones.Length == 0) return;

        indiceActual = (indiceActual + 1) % canciones.Length;
        audioSource.clip = canciones[indiceActual];
        audioSource.Play();
    }
}
