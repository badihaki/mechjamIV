using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotScarf : MonoBehaviour
{
    private Color scarfColor;
    private SpriteRenderer sprite;
    private TrailRenderer trailRenderer;
    [SerializeField] private Material trailMaterial;

    public void InitializeScarf(Color color)
    {
        scarfColor = new Color(color.r, color.g, color.b, 1);
        
        sprite = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
        
        sprite.color = scarfColor;
        
        Material material = new Material(trailMaterial);
        trailRenderer.startColor = scarfColor;
        // trailRenderer.endColor = new Color(220f, 220f, 220f, 0.2f);
        material.color = scarfColor;
        trailRenderer.material = material;
    }

    // end
}
