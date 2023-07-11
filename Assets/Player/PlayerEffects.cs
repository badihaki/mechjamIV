using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [field: SerializeField] public List<ParticleSystem> _VisFX { get; private set; }
    [field: SerializeField] public List<AudioClip> _SoundFX { get; private set; }
    [field:SerializeField] public TrailRenderer _Trail { get; private set; }

    public void InitializeEffects(Pilot pilot)
    {
        _Trail = pilot.GetComponent<TrailRenderer>();
        _Trail.emitting = false;
    }

    public void ActivateTrail() => _Trail.emitting = true;
    public void DeactivateTrail() => _Trail.emitting = false;


    // end
}
