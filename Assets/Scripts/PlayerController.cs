using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int numberLifes;
    private Rigidbody2D rb;
    public Rigidbody2D bullet;
    public Transform mira;
    private float elapsedTime;
    private float velocidadeGiro = 180f;
    private float inputValorMovimento;
    private float inputValorGiro;
    public float forcaTiro = 20f;
    private string nomeEixoMovimento;
    private string nomeEixoGiro;
    private string botaoTiro;

    [SerializeField]
    private TMP_Text vidaPlayer;

    [SerializeField]
    private TMP_Text bulletPlayer;

    [SerializeField]
    private float reloadTime;

    [SerializeField]
    private int numberBullets;

    [SerializeField]
    public int playerID;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        nomeEixoMovimento = "Vertical" + playerID;
        nomeEixoGiro = "Horizontal" + playerID;
        botaoTiro = "Fire" + playerID;

    }
    

    void Update()
    {
        if ((Input.GetButtonDown(botaoTiro)) && (numberBullets > 0))
        {
            Fire();
            numberBullets -= 1;
        }
        else if(numberBullets == 0)
        {
            ReloadBullets();
        }
    
        CheckLife();
    }

    private void FixedUpdate()
    {
        Rotate();

        Move();

        UpdateHUD();
    }

    private void UpdateHUD()
    {
        vidaPlayer.text = numberLifes.ToString();
        bulletPlayer.text = $"{numberBullets}";
    }

    private void Rotate()
    {
        float horizontal = Input.GetAxisRaw(nomeEixoGiro);
        float newAngle = rb.rotation + (horizontal * velocidadeGiro * Time.deltaTime);
        rb.MoveRotation(newAngle);
    }

    private void Move()
    {   
        float vertical = Input.GetAxisRaw(nomeEixoMovimento);

        rb.AddForce(transform.right * vertical);
    }
    
    private void Fire()
    {
        Rigidbody2D bulletInstance = Instantiate(bullet, mira.position, mira.rotation) as Rigidbody2D;

        bulletInstance.AddForce(transform.right * forcaTiro);
    }

    private void ReloadBullets()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= reloadTime)
        {
            elapsedTime = 0f;
            
            numberBullets = 5;
        }
    }


    private void CheckLife()
    {
        if (numberLifes == 0)
        {
            UpdateHUD();

            Destroy(gameObject);

            SceneManager.LoadScene("GameOver");
        }
    }
}
