using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour, IInteractable
{
    [field: SerializeField] public bool _CanInteract { get; set; }
    [field: SerializeField] public WeaponScriptableObject _Weapon { get; private set; }

    public void Interact(Pilot pilot)
    {
        if (pilot._Player._Controls._InteractInput)
        {
            pilot._Player._Controls.UseInteract();
            pilot._Player._Attack.SwitchWeapon(_Weapon);
            _CanInteract = false;
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _CanInteract = true;
        transform.Find("GFX").GetComponent<SpriteRenderer>().sprite = _Weapon.pickupGraphic;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
