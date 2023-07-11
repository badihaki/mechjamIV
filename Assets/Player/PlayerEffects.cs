using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [field: SerializeField] public List<ParticleSystem> _VisFX { get; private set; }
    [field: SerializeField] public List<AudioClip> _SoundFX { get; private set; }
    [field:SerializeField] public TrailRenderer _Trail { get; private set; }
    [SerializeField] private Material _TrailMaterial;

    private Pilot pilot;

    public void InitializeEffects(Pilot user)
    {
        pilot = user;
        BuildTrail(pilot);
    }

    private void BuildTrail(Pilot pilot)
    {
        _Trail = pilot.AddComponent<TrailRenderer>();
        
        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0.0f, 0.65f);
        curve.AddKey(1.0f, 0.0f);
        _Trail.widthCurve = curve;

        _Trail.time = 0.35f;
        _Trail.minVertexDistance = 0.1f;

        Gradient gradient = new Gradient();
        float alpha = 1.0f;
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.gray, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 1.0f), new GradientAlphaKey(alpha * 0, 1.0f) }
            );
        _Trail.colorGradient = gradient;
        // ^^ may have to change, is this even right???

        _Trail.material = _TrailMaterial;

        _Trail.emitting = false;
    }

    public void ActivateTrail()
    {
        if (_Trail) _Trail.emitting = true;
        else
        {
            BuildTrail(pilot);
            _Trail.emitting = true;
        }
    }
    public void DeactivateTrail() 
    {
        if (_Trail) _Trail.emitting = false;
    }


    // end
}
