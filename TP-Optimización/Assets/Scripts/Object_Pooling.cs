using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Pooling : MonoBehaviour
{
    public List<Apple> applesInPool = new List<Apple>();
    public int cantidad;
    public Apple apple;
    public static Object_Pooling Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cantidad; i++)
        {
            Apple poolObject = Instantiate(apple);
            poolObject.gameObject.SetActive(false);
            applesInPool.Add(poolObject);
        }

    }

    public Apple getObject()
    {
        foreach (Apple poolObject in applesInPool)
        {
            if (!poolObject.gameObject.activeInHierarchy)
            {
                return poolObject;
            }
        }
        return null;
    }
    
}
