using UnityEngine;
using System.Collections;

public class OnWay : MonoBehaviour
{
    public Transform superficie, groundCheck;
    private float posY; // posição y do personagem
    private Collider2D colisor;


	// Use this for initialization
	void Start ()
    {
        groundCheck = GameObject.Find("GroundCheck").transform;
        colisor = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        posY = groundCheck.position.y;

        if(posY > superficie.position.y)
        {
            colisor.enabled = true;
        }
        else
        {
            colisor.enabled = false;
        }
	}
}
