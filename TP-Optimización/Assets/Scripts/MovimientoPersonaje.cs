using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float velocidadRotacion;
    [SerializeField] private CharacterController _chController;
    [SerializeField] private Transform trPersonaje;
    [SerializeField] private Camera _camaraPersonaje;
    [SerializeField] private Light _linterna;

    private Vector3 movimiento;
    private float rotacionX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _linterna.enabled = false;
    }

    private void Update()
    {
        MovimientoDelPersonaje();
        MovimientoDeCamara();
        prenderYApagarLinterna();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void MovimientoDelPersonaje()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        movimiento = transform.right * movX + transform.forward * movZ;
        _chController.SimpleMove(movimiento * velocidadMovimiento);
    }

    private void MovimientoDeCamara()
    {
        float ratonX = Input.GetAxis("Mouse X") * velocidadRotacion;
        float ratonY = Input.GetAxis("Mouse Y") * velocidadRotacion;

        rotacionX -= ratonY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        _camaraPersonaje.transform.localRotation = Quaternion.Euler(rotacionX,0,0);
        trPersonaje.Rotate(Vector3.up * ratonX);
    }

    private void prenderYApagarLinterna()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (_linterna.enabled)
            {
                _linterna.enabled = false;
            }
            else
            {
                _linterna.enabled = true;
            }
        }
    }
}
