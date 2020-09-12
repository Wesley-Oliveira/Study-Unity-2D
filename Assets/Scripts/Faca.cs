using UnityEngine;
using System.Collections;

public class Faca : MonoBehaviour {

    //private SpriteRenderer facaSpriteRenderer;

    void OnCollisionEnter2D()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
        Destroy(this.gameObject, 3);
    }
}
