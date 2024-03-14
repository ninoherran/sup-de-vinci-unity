using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // appel de la propriété "UnityEngine.UI" suivant pour accéder à l'interface user pour afficher le score

public class PongBall2 : MonoBehaviour
{
    [SerializeField] private float speed = 15;
    [SerializeField] private Vector3 direction = new Vector3(1, 0, 0);
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI botScoreText;
    private float zMaxDistance = 15f; // Distance que la balle doit parcourir
    private int scorePlayer = 0;
    private int scoreComputer = 0;

    // Permet d'indiquer dans l'inspector l'AudioClip qui s'occupera du son
    [SerializeField] private AudioClip audioBall = null;
    [SerializeField] private AudioClip audioColliPlayer = null;

    // Permet de récupérer la composante qui va permettre de gérer du son
    private AudioSource ball_AudioBall;

    private void Awake()
    {
        ball_AudioBall = GetComponent<AudioSource>();
    }

    private void Start()
    {
        //appel de la fonction qui va permet de donner une direction initiale à la balle au lancement du jeu
        SetDirection();
    }

    void Update()
    {
        ball_AudioBall.PlayOneShot(audioBall);

        //on applique une translation sur le déplacement de la balle
        transform.Translate(direction * speed * Time.deltaTime);

        // IA gange
        if (transform.position.z < -zMaxDistance && direction.z < 0)
        {
            scoreComputer++;
            SetDirection();
        }

        // Joueur gange
        if (transform.position.z > zMaxDistance && direction.z > 0)
        {
            scorePlayer++;
            SetDirection();
        }
    }

    // On crée la fonction SetDirection
    public void SetDirection()
    {
        // Acceder à la propriété "text" de notre "scoreText" et lui affecter le score du joueur "+" celui de l'ordinateur
        playerScoreText.text = "Player : " + scorePlayer.ToString();
        botScoreText.text = "Bot : " + scoreComputer.ToString();

        // On rénitialise la position de la balle au centre à chaque score
        transform.position = new Vector3(0, .5f, 0);

        // Donner une direction initiale aléatoire grâce à Random.Range qui va nous permettre d'avoir un mouvement aléatoire
        // initiale dans la balle. Puis on fait un "normalized" pour que la vitesse soit constante.
        direction = new Vector3(Random.Range(0.75f, 1.75f), 0, -1).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Si le tag de l'objet touché(colllision) est égale à bar
        if (collision.gameObject.tag == "Bar")
        {
            // On vérifie si le joueur est touché ou l'ordinateur
            bool isPlayer = collision.gameObject.GetComponent<PongBar>().isHumanPlayer;
            if ((isPlayer && direction.z < 0) || (!isPlayer && direction.z > 0))
            {
                direction.z *= -1;
            }

            // Condition de faiblesse de l'ordinateur
            // si l'ordinateur est touché 
            if (!isPlayer)
            {
                // alors on incrémente une valeur daans laquelle "PongAi" sera faible.
                collision.gameObject.GetComponent<PongAi>().AddBounce();
            }
            ball_AudioBall.PlayOneShot(audioColliPlayer);
        }

        // Si notre boule touche le mur 
        if (collision.gameObject.tag == "Side")
        {
            // On inverse la direction sur l'axe "X" 
            direction.x *= -1;
        }
    }

}
