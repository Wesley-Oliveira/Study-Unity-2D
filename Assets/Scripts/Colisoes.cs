using UnityEngine;
using System.Collections;

public class Colisoes : MonoBehaviour
{
    //Só funciona pra objeto sem ser trigger
    void OnCollisionEnter2D(Collision2D col) //VERIFICA QUANDO COLIDE // COL RETORNA O OBJETO QUE COLIDIU
    {
        switch(col.gameObject.tag)
        {
            case "Objeto": print(col.gameObject.name);break;
            case "TomarDano": print("AI");break;
        }
        /*if(col.gameObject.tag == "Objeto") // SE COLIDIR COM ALGUM OBJETO QUE TENHA A TAG "OBJETO" EXECUTA
        {
            print(col.gameObject.name);
        }
        else if(col.gameObject.tag == "TomarDano")
        {
            print("AI");
        }*/
    }

    /*void OnCollisionExit2D(Collision2D col) //VERIFICA QUANDO PARA DE COLIDIR // COL RETORNA O OBJETO QUE COLIDIU
    {

    }

    void OnCollisionStay2D(Collision2D col) //VERIFICA SE ESTÁ COLIDINDO // COL RETORNA O OBJETO QUE COLIDIU
    {

    }
    */
    //fim

    //Funciona para os Triggers
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "TomarDano": print("AI"); break;
        }
    }
    /*
    void OnTriggerExit2D()
    {

    }

    void OnTriggerStay2D()
    {

    }
    */
    //fim
}
