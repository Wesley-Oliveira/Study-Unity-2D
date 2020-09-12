using UnityEngine;
using System.Collections;

public class Entradas : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            print("Apertou f1");
        }	
        if(Input.GetMouseButtonDown(0)) // 0 btn esquerdo   1 btn direito   2 btn scroll
        {
            print("btn esquerdo pressionado");
        }

	}
}
