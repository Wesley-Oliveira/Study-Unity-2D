using UnityEngine;
using System.Collections;

public class Fantasma : MonoBehaviour
{
    private Estudo scriptPlayer;
    public float velocidade;
    public Sprite[] imagemFantasma;
    private SpriteRenderer fantasmaSR;
    private bool fantasmaOlhandoEsquerda;

	// Use this for initialization
	void Start ()
    {
        scriptPlayer = FindObjectOfType(typeof(Estudo)) as Estudo; // como se fosse o import para usar as coisas publicas daquela classe   	
        fantasmaSR = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x > scriptPlayer.transform.position.x && fantasmaOlhandoEsquerda == false)
        {
            Flip();
        }
        else if (transform.position.x < scriptPlayer.transform.position.x && fantasmaOlhandoEsquerda == true)
        {
            Flip();
        }

        if (transform.position.x > scriptPlayer.transform.position.x && scriptPlayer.olhandoEsquerda == true)
        {
            Seguir();
        }
        else if (transform.position.x < scriptPlayer.transform.position.x && scriptPlayer.olhandoEsquerda == false)
        {
            Seguir();
        }
        else
        {
            fantasmaSR.sprite = imagemFantasma[1];
        }
	}

    void Seguir()
    {
        fantasmaSR.sprite = imagemFantasma[0];
        transform.position = Vector3.MoveTowards(transform.position, scriptPlayer.transform.position, velocidade * Time.deltaTime);
    }

    void Flip()
    {
        fantasmaOlhandoEsquerda = !fantasmaOlhandoEsquerda;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale; 
    }

}
