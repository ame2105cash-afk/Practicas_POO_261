using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objetivo;
    //             Transform position   x    y   z
    public Vector3 offset = new Vector3(0f, 3f, -6f);
    //Cuakquier variable que tu tengas en estado  privado queda protegida dentro de su pieza de lego:
    //solamente camara Follow sabe como esta construida 
    //al poner una camara privade este solo permite cuando arrancar o detenerse
    private bool seguir = false;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void LateUpdate()
    {
        
        if(seguir&& objetivo !=null)
        {
            //Posicionar camara con offset: lo que hace es allinearse con la camara
            transform.position = objetivo.position + offset;
        }


    }
    //publico permite visualizarlo en otro scrip
    public void Iniciarseguimiento()
    {
        seguir = true;
    }
    public void DetenerSeguimiento()
    {
        seguir = false;
    }
}
