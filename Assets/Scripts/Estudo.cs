using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class Estudo : MonoBehaviour
{
    //private SpriteRenderer playerSpriteRenderer;
    private Rigidbody2D playerRigidbody2D;
    private Animator playerAnimator;
    //public Sprite novaSprite
    private float horizontal, vertical;
    public float velocidade, velocidadeBase, adicionalVelocidade, forcaJump, forcaJumpBase, adicionalforcaJump, velocidadeFaca; // utiliza multiplicando com horizontal ou vertical para mudar a velocidade de andar do personagem, utiliza em mudanças de cenário
    public Transform groundCheck, mao;
    private bool grounded, walk, inversaoGravidade;
    public bool olhandoEsquerda;
    public LayerMask whatIsGround; // DEFINE QUAIS CAMADAS O GROUNDCHECK DEVE COLIDIR
    public GameObject facaPrefab, caixotePrefab, objetoInteracao;
    public Text score;
    public int pontuacao;

    // Use this for initialization
    void Start ()
    {
        //PARA PEGAR UM COMPONENTE: playerSpriteRenderer = GetComponent<SpriteRenderer>();
        //playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        velocidade = velocidadeBase;
        forcaJump = forcaJumpBase;
        //playerSpriteRenderer.enabled = false;
        //playerSpriteRenderer.color = Color.red;
        //playerRigidbody2D.gravityScale = -1;
        //playerSpriteRenderer.flipY = true;
        //playerSpriteRenderer.sprite = novaSprite; // muda a sprite do objeto para isso só precisa alterar na unity a variavel adicionando a sprite no local.
    }

    // Update is called once per frame
    void Update() // Input Todos aqui para não haver delay
    {
        score.text = pontuacao.ToString();
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f, whatIsGround); // RETORNA TRUE SE HOUVER ALGUMA COLISÃO NOS PÉS DO PERSONAGEM FALSE SE NÃO HOUVER COLISÃO

        horizontal = Input.GetAxisRaw("Horizontal"); // -1  0  1
        if(horizontal != 0)
        {
            walk = true;
        }
        else
        {
            walk = false;
        }

        if(horizontal > 0 && olhandoEsquerda == true) // SE O PERSONAGEM ESTA INDO PARA A DIREITA MAS A A VARIAVEL OLHANDOESQUERA FOR TRUE ENTÃO CHAMA A FUNÇÃO FLIP
        {
            Flip();
        }
        else if(horizontal < 0 && olhandoEsquerda == false)
        {
            Flip();
        }

        //
        vertical = Input.GetAxisRaw("Vertical");
        if(vertical > 0 && inversaoGravidade == false) //cima
        {
            InverterGravidade();
        }
        else if(vertical < 0 && inversaoGravidade == true)//baixo
        {
            InverterGravidade();
        }

        if (Input.GetButtonDown("Correr")) //Correr é o fire3; Quando descer o botão executa o comando
        {
            velocidade = velocidadeBase + adicionalVelocidade; // ADD MAIS VELOCIDADE NO PLAYER
            forcaJump = forcaJumpBase + adicionalforcaJump;
        }
        if (Input.GetButtonUp("Correr")) //Quando sobir o botão executa o botão
        {
            velocidade = velocidadeBase; // VOLTA A VELOCIDADE NORMAL 
            forcaJump = forcaJumpBase;
        }


        if(Input.GetButtonDown("Jump") && grounded == true)
        {
            playerRigidbody2D.AddForce(new Vector2(0, forcaJump)); //FAZ O PULO// SE UTILIZAR UM VALOR NO X DÁ PRA FAZER UM DASH
        }

        if(Input.GetButtonDown("Atirar"))
        {
            if(objetoInteracao == null)
            {
                lancarFaca();
            }
            else
            {
                objetoInteracao.SendMessage("Interacao", SendMessageOptions.DontRequireReceiver);
            }
        }

        if (Input.GetButtonDown("Caixote"))
        {
            colocarCaixote();
        }

        //ATUALIZA O ANIMATOR
        playerAnimator.SetBool("WalkAnimator", walk);
        
        playerAnimator.SetBool("Grounded", grounded);

        if(inversaoGravidade == false) //INVERTE ANIMAÇÃO
        {
            playerAnimator.SetFloat("VelocidadeY", playerRigidbody2D.velocity.y);
        }
        else if(inversaoGravidade == true)
        {
            playerAnimator.SetFloat("VelocidadeY", playerRigidbody2D.velocity.y * -1);
        }
        
    }

    void FixedUpdate() // Na maioria dos casos os comandos relacionados a rigidbody são colocados nesta função
    {
        playerRigidbody2D.velocity = new Vector2(horizontal * velocidade, playerRigidbody2D.velocity.y); //altera a velocidade do rigidbody //MOVIMENTO HORIZONTAL DO PERSONAGEM // NO Y DO VETOR FOI UTILIZADO AQUILO PRA ELE NÃO FICAR LENTO OU SEJA NÃO ALTERAR A GRAVIDADE DO JOGO
    }

    void Flip() //RESPONSAVEL POR VIRAR O PERSONAGEM
    {
        olhandoEsquerda = !olhandoEsquerda;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        velocidadeFaca *= -1;
        transform.localScale = theScale;
    }

    void InverterGravidade()
    {
        inversaoGravidade = !inversaoGravidade;
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
        playerRigidbody2D.gravityScale *= -1;
        forcaJump *= -1;
        forcaJumpBase *= -1;
        adicionalforcaJump *= -1;
    }

    void lancarFaca()
    {
        GameObject tempFaca = Instantiate(facaPrefab, mao.position, transform.rotation) as GameObject;

        //SE O PERSONAGEM ESTIVER OLHANDO PARA A ESQUERDA VIRA A FACA
        if(olhandoEsquerda == true)
        {
            tempFaca.GetComponent<SpriteRenderer>().flipX = true;
        }

        tempFaca.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeFaca, 0);
        Destroy(tempFaca, 5);
    }

    void colocarCaixote()
    {
        Instantiate(caixotePrefab, mao.position, mao.rotation);
    }

    void OnCollisionEnter2D(Collision2D col) // responsável por fazer o personagem acompanhar a plataforma quando estiver em cima dela
    {
        switch (col.gameObject.tag)
        {
            case "PlataformaMovel": transform.SetParent(col.transform); break; // faz o personagem se tornar filho da plataforma
            case "Inimigo":
                if (pontuacao > PlayerPrefs.GetInt("recorde"))
                {
                    PlayerPrefs.SetInt("recorde", pontuacao);
                }
                SceneManager.LoadScene("Titulo"); break;
        }
    }

    void OnCollisionExit2D(Collision2D col) // responsável por fazer o personagem parar de acompanhar a plataforma
    {
        switch (col.gameObject.tag)
        {
            
            case "PlataformaMovel": transform.SetParent(null); break; // faz o personagem deixar de ser filho da plataforma
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Interacao": objetoInteracao = col.gameObject; break; 
            case "BarraOuro": Destroy(col.gameObject); pontuacao += 15; break;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Interacao": objetoInteracao = null; break; 
        }
    }

}
