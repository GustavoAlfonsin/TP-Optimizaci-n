using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Spawner : MonoBehaviour
{
    public float currentTime = 0;
    public float spawnTime;
    public float spawnRadio;

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        player = Camera.main.transform;
        SpawnApples();
    }

    private void SpawnApples()
    {
        if (currentTime <= 0)
        {
            Apple manzana = Object_Pooling.Instance.getObject();
            if (manzana != null)
            {
                Vector3 randomPosicion = UnityEngine.Random.insideUnitSphere * spawnRadio;
                randomPosicion.y = 1.5f;
                Vector3 spawnPosicion = player.position + randomPosicion;
                manzana.transform.position = spawnPosicion;
                manzana.gameObject.SetActive(true);
                manzana.SpawnApple();
                currentTime += spawnTime;
            }
        }
        else
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
            {
                currentTime = 0;
            }
        }
    }
}
