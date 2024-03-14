using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongAi : MonoBehaviour
{
    // On appelle la méthode "Transform" pour connaitre la position de la balle
    public Transform pongBall;

    // On déclare la variable "latency" pour stocker le temps de latence de l'ordinateur
    public float latency = 4f;

    // On stock la distance de vision de l'ordi
    public float viewDistance = 20;

    // nombre de fois que l'ordi rentre en contact avec la balle
    public int nbShots = 0;

    // Permet d'indiquer dans l'inspector l'AudioClip qui s'occupera du son sur le computer
    [SerializeField] private AudioClip audioComputer = null;

    // Permet de récupérer la composante qui va permettre de gérer du son
    private AudioSource ai_AudioComputer;

    private void Awake()
    {
        ai_AudioComputer = GetComponent<AudioSource>();
    }

    void Update()
    {
        // vérifie si la distance entre la raquette et la balle est plus petit que la distance de vue
        if (Vector3.Distance(transform.position, pongBall.position) < viewDistance)
        {
            // s'il le voit alors :
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(pongBall.transform.position.x, .5f, 14),
                latency * Time.deltaTime
            ); // MoveToward qui permet que l'ordi voit la balle avec les positions avec un petit temps de latente
            ai_AudioComputer.PlayOneShot(audioComputer);
        }
    }

    // On crée une fonction "AddBounce" 
    public void AddBounce()
    {
        // On augmente la valeur de nbShots
        nbShots++;
        if (nbShots >= 10)
        {
            // On reinitialize
            nbShots = 0;

            // On diminue le temps de latence
            latency -= 0.25f;
        }
    }
}
