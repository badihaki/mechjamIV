using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectHelper : MonoBehaviour
{
    [SerializeField] private GameObject intro;
    public void StartHelper()
    {
        intro.SetActive(true);
    }
}
