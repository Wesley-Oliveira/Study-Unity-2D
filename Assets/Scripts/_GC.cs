using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class _GC : MonoBehaviour
{
    public Text record;

    void Start()
    {
        //  set grava ||  get ler
        record.text = PlayerPrefs.GetInt("recorde").ToString();
    }

	public void Jogar()
    {
        SceneManager.LoadScene("estudo");
    }
}