using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private Estudo scriptPlayer;
    private Vector3 destino;
    public Transform L, R;
    public float velocidade;
    public bool comLerp;
    public bool seguirY;
	// Use this for initialization
	void Start ()
    {
        scriptPlayer = FindObjectOfType(typeof(Estudo)) as Estudo;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(seguirY == true)
        {
            destino = new Vector3(scriptPlayer.transform.position.x, scriptPlayer.transform.position.y, transform.position.z);
        }
        else
        {
            destino = new Vector3(scriptPlayer.transform.position.x, transform.position.y, transform.position.z);
        }
        


        if(scriptPlayer.transform.position.x > L.position.x && scriptPlayer.transform.position.x < R.position.x)
        {
            if (comLerp == true)
            {
                transform.position = Vector3.Lerp(transform.position, destino, velocidade * Time.deltaTime);
            }
            else
            {
                transform.position = destino;//new Vector3(scriptPlayer.transform.position.x, transform.position.y, transform.position.z);
            }
        }
        else if (transform.position.x > L.position.x && transform.position.x < R.position.x)
        {
            transform.position = Vector3.Lerp(transform.position, destino, velocidade * Time.deltaTime);
        }

    }
}
