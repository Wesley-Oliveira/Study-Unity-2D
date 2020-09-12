using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{

    public Transform backGround, cam; //cam == camera
    public float parallaxScale, velocidade;
    private Vector3 destino, previewCamPos;// preview vai pegar a posição anterior da camera

	// Use this for initialization
	void Start ()
    {
        	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float parallaxX = (previewCamPos.x - cam.position.x) * parallaxScale;
        destino = new Vector3(backGround.position.x + parallaxX, backGround.position.y, backGround.position.z);

        backGround.position = Vector3.Lerp(backGround.position, destino, velocidade * Time.deltaTime );

        previewCamPos = cam.position;
	}
}
