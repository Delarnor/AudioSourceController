using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour {

    GameObject BPlay, BPause, MusicHolder;
    // Usar este para começar:
    void Start ()
    {

        //"BPlay" e "BPause" são o nome dos objectos no Unity.
        BPlay = GameObject.Find("BPlay");
        BPause = GameObject.Find("BPause");
		//"MusicHolder" é nome dado a um objecto, invisível para o utilizador, onde se associou o ficheiro de audio.
        MusicHolder = GameObject.Find("MusicHolder");


        BPlay.SetActive(true);
        BPause.SetActive(false);
    }
    //o Update é activado uma vez por frame:
    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Play")
                {
                    //Este segmento desactiva o botão play, reproduz o ficheiro e activa o botão para pausar.
                    BPlay.SetActive(false);
                    BPause.SetActive(true);
                    MusicHolder.GetComponent<AudioSource>().Play();
                }

                if (hit.collider.tag == "Pause")
                {
                    //Este segmento desactiva o botão pausar, pára o ficheiro e activa o botão play.
                    BPause.SetActive(false);
                    BPlay.SetActive(true);
                    MusicHolder.GetComponent<AudioSource>().Stop();
                }
            }
        }

    }
}