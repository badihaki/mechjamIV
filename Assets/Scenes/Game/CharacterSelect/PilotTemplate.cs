using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotTemplate : MonoBehaviour
{
    [SerializeField] private Color currentColor = Color.white;
    [SerializeField] private SpriteRenderer coloredObject;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        coloredObject.color = currentColor;
    }

    public void ChangeColor(Color color) => currentColor = color;
}
