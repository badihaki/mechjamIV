using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_SceneManager : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        if(name != null)
        {
            SceneManager.LoadScene(name);
        }
    }
}
