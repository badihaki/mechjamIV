using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public bool _CanInteract { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Interact(Pilot pilot)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
