using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TiroController : MonoBehaviour
{
   // [HideInInspector]
    public LayerMask playerLayer;
    public float tempoVida = 2.2f;
    public const float VELOCIDADE_TIRO = 5f;

    [SerializeField]
    private AudioSource audioTiro;
    public AudioSource AudioTiro { get => audioTiro; set => audioTiro = value; }

    [SerializeField]
    private AudioSource audioKill;
    public AudioSource AudioKill => audioKill;
    


    void Start()
    {
        Destroy(gameObject, tempoVida);
        AudioTiro.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Parede"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().numberLifes -= 1;

            if (other.GetComponent<PlayerController>().numberLifes == 0)
            {
                audioKill.Play();
            }
            Debug.Log(other.GetComponent<PlayerController>().numberLifes);
            Destroy(gameObject);
        }
    }
}
