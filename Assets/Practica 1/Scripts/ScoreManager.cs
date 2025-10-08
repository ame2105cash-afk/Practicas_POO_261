using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //esta libreria es para colocar el texto

public class ScoreManager : MonoBehaviour
{
    //
    public Text textoPuntaje;

    //Variables internas
    private int puntajeActual = 0;
    [SerializeField]//Este ayuda a que lo "private" se mantenga así ´pero se pueda ver
    private Pin[] pinos;
    // Start is called before the first frame update
    void Start()
    {
        textoPuntaje.text = "Tienes un millon de dolares";  

        pinos =FindObjectsOfType<Pin>();
    }

    public void CalcularPuntaje()
    {
        int puntaje = 0;

        foreach (Pin pin in pinos)
        {
            if (pin.EstaCaido())
            {
                puntaje++;
            }
        }

        puntajeActual = puntaje;

        if (textoPuntaje != null) textoPuntaje.text = "Puntos: " + puntajeActual;
    }
}
