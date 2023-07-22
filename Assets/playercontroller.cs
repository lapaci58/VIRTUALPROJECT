using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System;
using System.Security.Cryptography;
using Random = System.Random;
using UnityEngine.SceneManagement;
using TMPro;


public class playercontroller : MonoBehaviour
{

    public TextMeshProUGUI puantext;
    public GameObject panel;
    public AudioSource[] sesler;
    public CinemachineVirtualCamera[] cameras;
    public GameObject karakter;

    void Start()
    {

        puantexsayi = 0;
        kalkan = false;
        canmove = false;
        canhit = true;
        duzgit= false;
        gerigit= false;
        zipla = false;
    }


    void Update()
    {
        duzgit1();
        geri1();
        zipla1();
        kalkan1();
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("yumruk"))
        {
            anim.SetBool("yumruk", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("yumruk1"))
        {
            anim.SetBool("yumruk1", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("yumruk2"))
        {
            anim.SetBool("yumruk2", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("yumruk3"))
        {
            anim.SetBool("yumruk3", false);
        }
        if (Time.time - lastclickedtime > maxcombodelay)
        {
            noofclicks = 0;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("tekme"))
        {
            anim.SetBool("tekme", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("tekme1"))
        {
            anim.SetBool("tekme1", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("tekme2"))
        {
            anim.SetBool("tekme2", false);
        }
        if (Time.time - lastclickedtime1 > maxcombodelay1)
        {
            noofclicks1 = 0;
        }
    }
    public float movementspeed;
    public float jumppower;
    public Animator anim;
    public bool canmove;
    public bool canhit;
    public Button[] butonlar;
    public bool duzgit;
    public bool gerigit;
    public bool zipla;
    public bool kalkan;
    public float cooldowntime = 2f;
    public static int noofclicks = 0;
    float lastclickedtime = 0;
    float maxcombodelay=1;
    public float cooldowntime1 = 2f;
    public static int noofclicks1 = 0;
    float lastclickedtime1 = 0;
    float maxcombodelay1 = 1;
    int sayi = 0;
    int sayi1 = 1;
    int puantexsayi;
    Random random = new Random();


    public void Onclick()
    {
        lastclickedtime= Time.time;
        noofclicks++;
        if(noofclicks==1)
        {
            sesler[5].Stop();
            anim.SetBool("yumruk", true);
            sesler[0].Play();
        }
        noofclicks = Mathf.Clamp(noofclicks, 0, 4);
        if(noofclicks>=2&& anim.GetCurrentAnimatorStateInfo(0).normalizedTime>0.7f&&anim.GetCurrentAnimatorStateInfo(0).IsName("yumruk"))
        {

            sesler[0].Stop();
            sesler[1].Play();
            anim.SetBool("yumruk", false);
            anim.SetBool("yumruk1", true);
        }
        if (noofclicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("yumruk1"))
        {
            sesler[1].Stop();
            sesler[2].Play();
            anim.SetBool("yumruk1", false);
            anim.SetBool("yumruk2", true);
        }
        if (noofclicks >= 4 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("yumruk2"))
        {
            StartCoroutine(yavaslat());
            sesler[2].Stop();
            sesler[3].Play();
            anim.SetBool("yumruk2", false);
            anim.SetBool("yumruk3", true);
            
        }
    }
    public void Onclicktekme()
    {
        lastclickedtime1 = Time.time;
        noofclicks1++;
        if (noofclicks1 == 1)
        {
            sesler[5].Stop();
            sesler[6].Play();
            anim.SetBool("tekme", true);
        }
        noofclicks = Mathf.Clamp(noofclicks, 0, 3);
        if (noofclicks1 >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("tekme"))
        {
            sesler[6].Stop();
            sesler[7].Play();
            anim.SetBool("tekme", false);
            anim.SetBool("tekme1", true);
        }
        if (noofclicks1 >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("tekme1"))
        {
            StartCoroutine(yavaslat());
            sesler[7].Stop();
            sesler[8].Play();
            anim.SetBool("tekme1", false);
            anim.SetBool("tekme2", true);
            
        }
    }
    public void kalkantut()
    {
        sesler[10].Play();
        kalkan = true;
    }
    public void kalkanindir()
    {
        sesler[10].Stop();
        sesler[11].Play();
        panel.SetActive(true);
        kalkan = false;
        anim.Play("idle");
    }
    public void kalkan1()
    {
        if(kalkan==true)
        {
            
            panel.SetActive(false);
            anim.Play("block");
        }
    }
    public void ileri()
    {
        
        duzgit= true;
    }
    public void ileridurdur()
    {
        anim.Play("idle");
        duzgit = false;
    }
    public void duzgit1()
    {
        if(duzgit==true)
        {
            transform.Translate(-movementspeed, 0, 0);
            anim.Play("forward");
        }
    }
    public void geri()
    {
        gerigit = true;
    }
    public void geridurdur()
    {

        gerigit = false;
        anim.Play("idle");
    }
    public void geri1()
    {
        if (gerigit == true)
        {
            transform.Translate(movementspeed, 0, 0);
            anim.Play("back");
        }
    }
    public void ziplatrue()
    {
        
        zipla= true;
    }
    public void ziplafalse()
    {
        zipla= false;
    }
    public void zipla1()
    {
        if (zipla == true)
        {
            StartCoroutine(animbekle());
            gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumppower);
            anim.Play("jump");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("kapsul"))
        {
            if (noofclicks > 0 || noofclicks1 > 0)
            {
                puantexsayi += 100;
                puantext.text = puantexsayi.ToString();
            }
        }
        if (other.CompareTag("kafasersem"))
        {
             StartCoroutine(sersembekle());
             anim.Play("sersemle");
        }
    }
    

        IEnumerator animbekle()
    {
        sesler[5].Stop();
        sesler[9].Play();
        panel.SetActive(false);
        butonlar[1].interactable = false;
        butonlar[2].interactable = false;
        butonlar[3].interactable = false;
        butonlar[4].interactable = false;
        butonlar[5].interactable = false;

        zipla = false;
        canhit = false;
        canmove = false;
        yield return new WaitForSecondsRealtime(1f);
        canmove = true;
        canhit = true;
        panel.SetActive(true);
        butonlar[1].interactable = true;
        butonlar[2].interactable = true;
        butonlar[3].interactable = true;
        butonlar[4].interactable = true;
        butonlar[5].interactable = true;
        sesler[5].Play();


    }
    IEnumerator sersembekle()
    {

        if (kalkan == false)
        {
            if (duzgit == true)
            {
                karakter.transform.position = new Vector3(0.05f, transform.position.y, transform.position.z);
            }
            if (gerigit == true)
            {
                karakter.transform.position = new Vector3(31f, transform.position.y, transform.position.z);
            }
            sesler[5].Stop();
            sesler[4].Play();
            duzgit = false;
            gerigit = false;
            zipla = false;
            panel.SetActive(false);
            butonlar[1].interactable = false;
            butonlar[2].interactable = false;
            butonlar[3].interactable = false;
            butonlar[4].interactable = false;
            butonlar[5].interactable = false;
            canhit = false;
            canmove = false;
            yield return new WaitForSecondsRealtime(2f);
            canmove = true;
            canhit = true;
            panel.SetActive(true);
            butonlar[1].interactable = true;
            butonlar[2].interactable = true;
            butonlar[3].interactable = true;
            butonlar[4].interactable = true;
            butonlar[5].interactable = true;

        }

    }
    IEnumerator yavaslat()
    {
        cameras[0].Priority = 9;
        int number = random.Next(9, 14);
        int number1 = random.Next(9, 14);
        int number2 = random.Next(9, 14);
        cameras[2].Priority = number;
        cameras[1].Priority = number1;
        cameras[0].Priority = number2;
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(3.8f);
        Time.timeScale = 1f;
        cameras[0].Priority = 15;
        
    }
    public void anamenudon()
    {
        
        SceneManager.LoadScene(sayi);
        

    }
    public void tekrar()
    {

        SceneManager.LoadScene(sayi1);

    }
}
