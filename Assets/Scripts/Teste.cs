using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Teste : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public int velocidade;
    private float horizontal;
    private float vertical;
    public float forca;
    public SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        playerRb.velocity = new Vector2(horizontal * velocidade, playerRb.velocity.y);//vertical * velocidade); //altera a velocidade do rigidbody //MOVIMENTO HORIZONTAL DO PERSONAGEM // NO Y DO VETOR FOI UTILIZADO AQUILO PRA ELE NÃO FICAR LENTO OU SEJA NÃO ALTERAR A GRAVIDADE DO JOGO
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Esse")
        {
            playerRb.AddForce(new Vector2(playerRb.transform.position.x, forca));
            sprite.color = Color.black;
            print("Começoua a colidir");
        }
    }

    void OnCollisionExit2D()
    {
        print("Saiu");
        sprite.color = Color.yellow;
    }

    void OnCollisionStay2D()
    {
        print("Está colidindo");
    }
}
