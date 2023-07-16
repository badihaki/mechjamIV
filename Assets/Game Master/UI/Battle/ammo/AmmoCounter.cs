using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    public List<RectTransform> _CurrentAmmoCounter { get; private set; } = new List<RectTransform>();
    [SerializeField] private RectTransform ammoIcon;

    public void UseAmmo()
    {
        if (_CurrentAmmoCounter[_CurrentAmmoCounter.Count - 1])
        {
            print(_CurrentAmmoCounter[_CurrentAmmoCounter.Count - 1].gameObject.name);
            Destroy(_CurrentAmmoCounter[_CurrentAmmoCounter.Count - 1].gameObject);
            _CurrentAmmoCounter.RemoveAt(_CurrentAmmoCounter.Count - 1);
        }
    }

    public void ResetAmmoCounter(int maxAmmo)
    {
        print("reloading with " + maxAmmo + "ammo");
        for (int number = 0; number < maxAmmo; number++)
        {
            //RectTransform icon = Instantiate(ammoIcon, transform);
            // _CurrentAmmoCounter.Add(icon);
            _CurrentAmmoCounter.Add(Instantiate(ammoIcon, transform));
        }
    }

    // end
}
