using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Paneles de UI")]
    public GameObject panelHUD;         // UI del juego (por ejemplo, vida, score)
    public GameObject panelInfoExtra;   // Otro panel visible durante el juego
    public GameObject panelPausa;       // Panel que aparece al pausar
    public TextMeshProUGUI txtLinterna;

    [Header("Botones del menú de pausa")]
    public Button botonReanudar;
    public Button botonSalir;

    private bool juegoPausado = false;

    private void Start()
    {
        // Asegurar que solo se vea el HUD e info al comenzar
        panelHUD.SetActive(true);
        panelInfoExtra.SetActive(true);
        panelPausa.SetActive(false);

        // Asignar funciones a los botones
        botonReanudar.onClick.AddListener(ReanudarJuego);
        botonSalir.onClick.AddListener(SalirDelJuego);

        Time.timeScale = 1f; // Asegurar que el tiempo esté corriendo
        if (!ControladorTiempo.instance.EsDeNoche)
            txtLinterna.enabled = false;
    }

    private void Update()
    {
        if (ControladorTiempo.instance.EsDeNoche)
        {
            txtLinterna.enabled = true;
        }
        else
        {
            txtLinterna.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (juegoPausado)
                ReanudarJuego();
            else
                PausarJuego();
        }
    }

    public void PausarJuego()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        panelHUD.SetActive(false);
        panelInfoExtra.SetActive(false);
        panelPausa.SetActive(true);

        AkUnitySoundEngine.Suspend();
    }

    public void ReanudarJuego()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        panelHUD.SetActive(true);
        panelInfoExtra.SetActive(true);
        panelPausa.SetActive(false);

        AkUnitySoundEngine.WakeupFromSuspend();
    }

    public void SalirDelJuego()
    {
        // Si estás en el editor de Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Cierra la aplicación en build
#endif
    }
}
