using UnityEngine;

public class SalirApp : MonoBehaviour
{
    public void Salir()
    {
        Application.Quit(); // Esto cierra la aplicación en un build
        Debug.Log("Saliendo de la app..."); // Esto se ve solo en el editor
    }
}
