using UnityEngine;
using System.Collections;

public class Bau : MonoBehaviour
{
    public GameObject[] estadoBau;
    private bool aberto;
    private Estudo scriptPersonagem;

	// Use this for initialization
	void Start ()
    {
        scriptPersonagem = FindObjectOfType(typeof(Estudo)) as Estudo;
        estadoBau[0].SetActive(true);
        estadoBau[1].SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {

	
	}

    void Interacao()// aqui vc adiciona o que vai acontecer quando interagir. tipo quando abrir o bau vai ganhar algum item ou gold e por ai vai
    {
        // COMANDOS A SEREM REALIZADOS PELA INTERAÇÃO DO PERSONAGEM
        if(aberto == false) 
        {
            aberto = !aberto;
            estadoBau[0].SetActive(!estadoBau[0].activeSelf);
            estadoBau[1].SetActive(!estadoBau[1].activeSelf);

            scriptPersonagem.pontuacao += 50;
        } 
    }
}
