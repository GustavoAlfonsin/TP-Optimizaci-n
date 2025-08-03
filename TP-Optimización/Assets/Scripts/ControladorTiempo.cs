using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTiempo : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 24f)] private float Hora = 12;
    [SerializeField] private Transform _sol;
    public float duracionDelDiaEnMinutos = 1;
    public float duracionDeLaNocheEnMinutos = 1;
    public Color nightFogColor;

    private float solX;

    private bool esDeNoche;
    public bool EsDeNoche
    {
        get { return esDeNoche; }
    }
    private bool estadoAnterior;
    public AK.Wwise.Event playMusicEvent;
    public AK.Wwise.Event stopMusicEvent;


    private void Start()
    {
        esDeNoche = Hora > 18 || Hora <= 6;
        estadoAnterior = esDeNoche;
        if (!esDeNoche)
            playMusicEvent.Post(gameObject);
    }

    private void Update()
    {
        esDeNoche = Hora > 19 || Hora <= 6;
        if (esDeNoche != estadoAnterior)
        {
            if (esDeNoche)
            {
                stopMusicEvent.Post(gameObject);
            }
            else
            {
                playMusicEvent.Post(gameObject);
            }

            // Guardamos el nuevo estado
            estadoAnterior = esDeNoche;
        }

        if (esDeNoche)
        {
            Hora += Time.deltaTime * (24 / (60 * duracionDeLaNocheEnMinutos));
        }
        else
        {
            Hora += Time.deltaTime * (24 / (60 * duracionDelDiaEnMinutos));
        }

        if (Hora >= 24)
        {
            Hora = 0;
        }
        rotacionSol();
    }

    private void rotacionSol()
    {
        solX = 15 * Hora;
        _sol.localEulerAngles = new Vector3(solX,0,0);

        if (Hora <= 6 || Hora > 19)
        {
            _sol.GetComponent<Light>().intensity = 0;
            RenderSettings.fog = true;
            RenderSettings.fogColor = nightFogColor;
        }
        else
        {
            _sol.GetComponent<Light>().intensity = 1;
            RenderSettings.fog = false;
        }
    }
}
