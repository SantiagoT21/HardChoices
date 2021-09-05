using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Way : MonoBehaviour
{
    public static Way Instance;
    public List<Transform> Posicion = new List<Transform>();
    Transform[] lista;
    public List<Transform> spawn_Counter = new List<Transform>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Posicion.Clear();
        lista = GetComponentsInChildren<Transform>();
        foreach (Transform child in lista)
        {
            if (child != this.transform)
            {
                Posicion.Add(child);
            }
        }
    }
}
