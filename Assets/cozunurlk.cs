using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cozunurlk : MonoBehaviour
{public
  GameObject bomboms;
    
    void Start()
    {

        Screen.SetResolution(Screen.currentResolution.width / 3, Screen.currentResolution.height / 3, true);
        bomboms.SetActive(false);
        cozunurlk.Destroy(this);

    }
}
