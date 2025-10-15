using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{

    //Movimiento
    public float velocidad = 5F; //velocidad del movimiento del jugador
    public float gravedad = -9.8f;//para controlar la fuerza o velocidad de la gravedad hacia el jugador 
    private CharacterController controller;//la pieza de lego que nos va a permitir el movimiento en el juego
    private Vector3 velocidadVertical;//nos va a permitir saber que tan rapido caemos

    //2, Variables vista
    public Transform camara;//es para registrar que camara va a funcionar como los ojos del jugador
    public float sensibilidadMouse = 200f;//que tan rapido se va a mover el mouse para voltear a ver en diferentes direcciones
    private float rotacionXVertical = 0f;//es para indicar cuantos grados va poder voltear a ver hacia arriba y hacia abajo 



    // Start is called before the first frame update
    void Start()
    {
        controller=GetComponent<CharacterController>();//esta invocacion funciona para buscar el componente caractercontroller
        
        //esta linea bloquea el puntero del mouse en los limites de la pantalla
        Cursor.lockState = CursorLockMode.Locked;


    }

    // Update is called once per frame
    void Update()
    {
        ManejadorVista();//Para llamar las funciones unicamente se escribe la funcion seguido () y ;
        ManejadorMovimiento();

    }
    void ManejadorVista()
    {
        //1. leer el input del mouse
        //input: movmiento del mouse
        float mouseX=Input.GetAxis("Mouse X")* sensibilidadMouse*Time.deltaTime;//registra el desplazamiento del mouse sobre el eje horizontal
        float mouseY=Input.GetAxis("Mouse Y")* sensibilidadMouse*Time.deltaTime;//registra el desplazamiento del mouse sobre el eje vertical

        //2. Construir la rotacion horizontal
        transform.Rotate(Vector3.up * mouseX);

        //3. registro de la rotacion vertical 
        rotacionXVertical -= mouseY;//a a registrar cuando movilices el mouse hacia arriba y hacia abajo va a mover la rotacion del personaje o la camara

        //4. Limitar la rotacion vertical
        Mathf.Clamp(rotacionXVertical, -90f, 90f);//limitas la vision de rotacion en 90 haci arriba y hacia abajo

        //5. Aplicar la rotacion 
                  //los Quaternion son os ejes         x           y  z
        camara.localRotation = Quaternion.Euler(rotacionXVertical, 0, 0);


    }


    void ManejadorMovimiento()
    {
        //1 leer el input de moivimiento (va a registrar el movimiento con WASD o las flechas de direccion)
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        //2. crear el vector de movimiento 
        //Se almacena de forma local el registro de direccion de movimiento 
        Vector3 direccion=transform.right * inputX+transform.forward * inputZ;

        //3. Mover el CharacterController
        controller.Move(direccion*velocidad*Time.deltaTime);//Mover a travez de la direccion que le indiques al jugador

        //4. Aplicar la gravedad 
        //registro si estoy en el piso para un futuro comportamiento de salto
        if(controller.isGrounded && velocidadVertical.y<0)
        {
            velocidadVertical.y = -2f;//una pequeña fuerza hacia abajo para mantenerlo pegado al piso 
        }

        //Aplicamos la aceleracion de la gravedad
        velocidadVertical.y += gravedad * Time.deltaTime;//esta aplucando la gravedad una vez estes en el aire 

        //Movemos el controlador hacia abajo
        controller.Move(velocidadVertical * Time.deltaTime);//esta aplicando la velocidad sober el objeto jugador

    }







}
