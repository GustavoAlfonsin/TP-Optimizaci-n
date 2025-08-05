using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sustosAmbientales : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event playSustos;
    [SerializeField] private Transform _player;
    public float radio = 10f;
    public float tiempoMin = 5f;
    public float tiempoMax = 15f;

    private float siguienteTiempo;

    private void Start()
    {
        calcularSiguienteTiempo();
    }

    private void Update()
    {
        if (!ControladorTiempo.instance.EsDeNoche) return;

        siguienteTiempo -= Time.deltaTime;
        if(siguienteTiempo <= 0)
        {
            reproducirSusto();
            calcularSiguienteTiempo();
        }
    }

    private void reproducirSusto()
    {
        Vector2 r2D = UnityEngine.Random.insideUnitCircle * radio;
        Vector3 posicionSusto = _player.position + new Vector3(r2D.x, 0f, r2D.y);

        GameObject emisor = new GameObject("sustoTemp");
        emisor.transform.position = posicionSusto;
        playSustos.Post(emisor);

        Destroy(emisor,3f);
    }

    private void calcularSiguienteTiempo()
    {
        siguienteTiempo = UnityEngine.Random.Range(tiempoMin, tiempoMax);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(_player.position, radio);
    //}
}
