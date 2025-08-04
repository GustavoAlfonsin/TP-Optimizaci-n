using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidosPajaros : MonoBehaviour
{
    public AK.Wwise.Event playPajarosEvent;
    public AK.Wwise.Event stopPajarosEvent;

    private bool esDeNoche = false;
    private bool estadoAnterior = false;


    void Start()
    {
        estadoAnterior = ControladorTiempo.instance.EsDeNoche;

        // Si al empezar es de día, reproducimos el sonido
        if (!estadoAnterior)
        {
            playPajarosEvent.Post(gameObject);
        }
    }

    void Update()
    {
        esDeNoche = ControladorTiempo.instance.EsDeNoche;

        if (esDeNoche != estadoAnterior)
        {
            if (esDeNoche)
            {
                // Noche: detener sonido
                stopPajarosEvent.Post(gameObject);
            }
            else
            {
                // Día: reproducir sonido
                playPajarosEvent.Post(gameObject);
            }

            estadoAnterior = esDeNoche;
        }
    }
}
