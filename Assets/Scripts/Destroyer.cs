using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float timeTillObjectIsDestroyed = 4.5f;
    private bool ready = false;

    public void InitializeDestroyer(float time)
    {
        timeTillObjectIsDestroyed = time;
        ready = true;
        Destroy(this.gameObject, timeTillObjectIsDestroyed);
    }

    private void Start()
    {
        if (!ready)
        {
            Destroy(this.gameObject, timeTillObjectIsDestroyed);
            ready = true;
        }
    }
}
