using UnityEngine;
using System.Collections;

public class PlataformaMovel : MonoBehaviour
{
    public Transform plataforma, A, B;
    public float velocidade;
    private Vector3 destino;

	// Use this for initialization
	void Start ()
    {
        plataforma.position = A.position;
        destino = B.position; 
	}
	
	// Update is called once per frame
	void Update ()
    {
        plataforma.position = Vector3.MoveTowards(plataforma.position, destino, velocidade * Time.deltaTime);
        if(plataforma.position == destino)
        {
            if(destino == A.position)
            {
                destino = B.position;
            }
            else if(destino == B.position)
            {
                destino = A.position;
            }
        }
	
	}



}
