using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pegarObjetos : MonoBehaviour {

    
    public List<GameObject> arrayObjetos = new List<GameObject>();
    GameObject ultimoObjeto;
    public GameObject disparador;
    public Text puntuacion;
    int puntos = 0;

    

    // Use this for initialization
    void Start () {

        puntuacion.text = "" + puntos;
		
	}
	
	// Update is called once per frame
	void Update () {
        puntuacion.text = "" + puntos;
        if (Input.GetKeyDown(KeyCode.Space)){

            
            Rigidbody2D ultimoObjeto = arrayObjetos[arrayObjetos.Count - 1].GetComponent<Rigidbody2D>() ;
            GameObject ultimoObjetoFinalPlusUltra = arrayObjetos[arrayObjetos.Count - 1];
            ultimoObjeto.transform.parent = null;
            

            ultimoObjeto.simulated = true;
            ultimoObjeto.AddForce(new Vector2(450f, 450f));
            arrayObjetos.Remove(ultimoObjetoFinalPlusUltra);
            //transform.DetachChildren();
            puntos--;

        }
        
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if(collision.gameObject.CompareTag("Objeto")){

            Rigidbody2D Objeto;


            collision.transform.position = disparador.transform.position;
            Objeto = collision.gameObject.GetComponent<Rigidbody2D>();
            Objeto.simulated = false;
            collision.transform.parent = transform;
            

            GameObject nuevoObjeto = collision.gameObject;
            arrayObjetos.Add(nuevoObjeto);
            puntos++;
            


        }
	}
}
