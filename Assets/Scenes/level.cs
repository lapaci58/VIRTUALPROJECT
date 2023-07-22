using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level : MonoBehaviour
{

    public int sayi = 1;
    // Update is called once per frame

    public void oyunabasla()
    {
        SceneManager.LoadScene(sayi);
    }
    public void cikisyap()
    {
        Application.Quit();
    }

}
