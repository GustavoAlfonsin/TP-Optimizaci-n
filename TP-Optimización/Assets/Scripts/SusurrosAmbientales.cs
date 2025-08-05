using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusurrosAmbientales : MonoBehaviour
{
    public AK.Wwise.Event playSusurrosEvent;
    public AK.Wwise.Event stopSusurrosEvent;

    private bool esDeNoche = false;
    private bool estadoAnterior = false;

    private void Start()
    {
        esDeNoche = ControladorTiempo.instance.EsDeNoche;
        estadoAnterior = ControladorTiempo.instance.EsDeNoche;
    }

    private void Update()
    {
        esDeNoche = ControladorTiempo.instance.EsDeNoche;

        if (esDeNoche != estadoAnterior)
        {
            if (!esDeNoche)
            {
                // Día: detener sonido
                stopSusurrosEvent.Post(gameObject);
            }
            else
            {
                // Noche: reproducir sonido
                playSusurrosEvent.Post(gameObject);
            }

            estadoAnterior = esDeNoche;
        }
    }
}
