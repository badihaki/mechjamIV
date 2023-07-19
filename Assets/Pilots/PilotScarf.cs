using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotScarf : MonoBehaviour
{
    private Color scarfColor;
    private Sprite sprite;
    private TrailRenderer trailRenderer;
    [SerializeField] private Material trailMaterial;

    public void InitializeScarf(Color color)
    {
        sprite = GetComponent<Sprite>();
        trailRenderer = GetComponent<TrailRenderer>();
        scarfColor = color;
        trailRenderer.startColor = scarfColor;
        trailRenderer.endColor = new Color(220f, 220f, 220f, 0.2f);
        Material material = new Material(trailMaterial);
        material.color = scarfColor;
        trailRenderer.material = material;
    }

    // end
}
