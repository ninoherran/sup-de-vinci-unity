using System.Collections;
using System.Collections.Generic;
using UnityEngine; // Propriété qui permet d'utiliser les fonctionnalités propres à unity

//Script de déplacement des raquettes
public class PongBar : MonoBehaviour // cette dérive permet d'attacher le script à un objet
{
    //variable "isHumanPlayer" de type bool pour la raquette du joueur
    public bool isHumanPlayer = false;
    public float speed = 12; // variable de vitesse du déplacement de la raquette

    //distance max à parcourir sur l'axe "X" afin d'empêcher la raquette de passer outre le mur
    private float xMaxDistance = 9f;


    void Update()
    {
        float move; // mouvement appliquée sur la raquette

        if (isHumanPlayer)
        {
            move = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //Time.deltaTime permet d'avoir une vitesse fixe peut importe la vitesse de l'ordi 
        }
        else
        {
            move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        }

        //on applique une translation sur le déplacement "X" de la raquette
        transform.Translate(move * Vector3.right);

        //condition de test de la position
        if (transform.position.x < -xMaxDistance)
        {
            transform.position = new Vector3(-xMaxDistance, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xMaxDistance)
        {
            transform.position = new Vector3(xMaxDistance, transform.position.y, transform.position.z);
        }
    }
}
