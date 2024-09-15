using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public float lifeTime;
    private float currentLifeTime;
   

    // Update is called once per frame
    void Update()
    {
        currentLifeTime -= Time.deltaTime;
        if (currentLifeTime < 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void SpawnApple()
    {
        currentLifeTime = lifeTime;
    }
}
