using UnityEngine;

public class ControlCanvasPorAnimacion : MonoBehaviour
{
    public Animator animador;

    public Canvas inicial;

    public Canvas canvasPaso1;
    public Canvas canvasPaso2;
    public Canvas canvasPaso3;
    public Canvas canvasPaso4;
    public Canvas canvasPaso5;
    public Canvas canvasPaso6;
    public Canvas canvasPaso7;
    public Canvas canvasPaso8;
    public Canvas canvasPaso9;
    public Canvas canvasPaso10;
    public Canvas canvasPaso11;
    public Canvas canvasPaso12;
    public Canvas canvasPaso13;
    public Canvas canvasPaso14;
    public Canvas canvasPaso15;
    public Canvas canvasPaso16;
    public Canvas canvasPaso17;
    public Canvas canvasPaso18;
    public Canvas canvasPaso19;

    void Update()
    {
        AnimatorStateInfo estado = animador.GetCurrentAnimatorStateInfo(0);

        // Desactivar todos los Canvas primero
        inicial.enabled = false;
        canvasPaso1.enabled = false;
        canvasPaso2.enabled = false;
        canvasPaso3.enabled = false;
        canvasPaso4.enabled = false;
        canvasPaso5.enabled = false;
        canvasPaso6.enabled = false;
        canvasPaso7.enabled = false;
        canvasPaso8.enabled = false;
        canvasPaso9.enabled = false;
        canvasPaso10.enabled = false;
        canvasPaso11.enabled = false;
        canvasPaso12.enabled = false;
        canvasPaso13.enabled = false;
        canvasPaso14.enabled = false;
        canvasPaso15.enabled = false;
        canvasPaso16.enabled = false;
        canvasPaso17.enabled = false;
        canvasPaso18.enabled = false;
        canvasPaso19.enabled = false;

        // Activar solo el Canvas correspondiente al estado actual
        if (estado.IsName("1")) canvasPaso1.enabled = true;
        else if (estado.IsName("2")) canvasPaso2.enabled = true;
        else if (estado.IsName("3")) canvasPaso3.enabled = true;
        else if (estado.IsName("4")) canvasPaso4.enabled = true;
        else if (estado.IsName("5")) canvasPaso5.enabled = true;
        else if (estado.IsName("6")) canvasPaso6.enabled = true;
        else if (estado.IsName("7")) canvasPaso7.enabled = true;
        else if (estado.IsName("8")) canvasPaso8.enabled = true;
        else if (estado.IsName("9")) canvasPaso9.enabled = true;
        else if (estado.IsName("10")) canvasPaso10.enabled = true;
        else if (estado.IsName("11")) canvasPaso11.enabled = true;
        else if (estado.IsName("12")) canvasPaso12.enabled = true;
        else if (estado.IsName("13")) canvasPaso13.enabled = true;
        else if (estado.IsName("14")) canvasPaso14.enabled = true;
        else if (estado.IsName("15")) canvasPaso15.enabled = true;
        else if (estado.IsName("16")) canvasPaso16.enabled = true;
        else if (estado.IsName("17")) canvasPaso17.enabled = true;
        else if (estado.IsName("18")) canvasPaso18.enabled = true;
        else if (estado.IsName("19")) canvasPaso19.enabled = true;
        else inicial.enabled = true; // Si no está en ningún estado conocido, volver al canvas inicial
    }
}
