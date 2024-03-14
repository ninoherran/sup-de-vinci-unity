using System.Collections;
using System.Collections.Generic;
using UnityEngine; // Propri�t� qui permet d'utiliser les fonctionnalit�s propres � unity

//Script de d�placement des raquettes
public class PongBar : MonoBehaviour // cette d�rive permet d'attacher le script � un objet
{
    //variable "isHumanPlayer" de type bool pour la raquette du joueur
    public bool isHumanPlayer = false;
    public float speed = 15; // variable de vitesse du d�placement de la raquette

    //distance max � parcourir sur l'axe "X" afin d'emp�cher la raquette de passer outre le mur
    private float xMaxDistance = 9f;
    
    void Update()
    {
        float move; // mouvement appliqu�e sur la raquette

        if (isHumanPlayer)
        {
            move = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //Time.deltaTime permet d'avoir une vitesse fixe peut importe la vitesse de l'ordi 
        }
        else
        {
            move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        }

        //on applique une translation sur le d�placement "X" de la raquette
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
