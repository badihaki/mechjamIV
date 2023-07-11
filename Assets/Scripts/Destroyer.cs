using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float timeTillObjectIsDestroyed = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeTillObjectIsDestroyed);
    }
}
