using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    private float umbralCaida = 5f;

    public bool EstaCaido()
    {
        float angulo = Vector3.Angle(transform.up, Vector3.up);
        return angulo > umbralCaida;
    }
}
