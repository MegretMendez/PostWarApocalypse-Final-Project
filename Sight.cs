using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{ 
    //Capas para detectar cosas
    //Dos capas: 1 para detectar obstaculos y otra para detectar objetos
    //Las capas ayudan para filtrar, va a ordenar los obstaculos en una lista y los objetos en otra
    //Luego de ordenar obstaculos y objetos en listas, itera por la lista para determinar 
    //que se va a hacer con cada obstaculo y objeto
    public LayerMask objectsLayer;
    public LayerMask obstaclesLayer;
    public Collider detectedObject = null;
    public float distance;
    public float angle;
    

    // Update is called once per frame
    void Update()
    {
        //el enemy tiene un perimetro alrededor(una esfera), todo lo que haga contacto con la esferea 
        //se mete en una lista 
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, objectsLayer); 

        detectedObject = null;
        for(int i = 0; i < colliders.Length; i++){
            Collider collider = colliders[i];  //objeto collider va a tener el valor de la posicion en la lista
            
            //Determinar angulo de object, en respecto al enemy
            Vector3 directionToCntroller = Vector3.Normalize(collider.bounds.center - transform.position);
            float angleToCollider = Vector3.Angle(transform.forward, directionToCntroller); 

            //verificar angle to collider y angle
            if (angleToCollider < angle){ //verificar si tienes algo en cerca

                //verificar si eso que tienes cerca esta de frente a ti
                //Si del centro lanzo una linea, quiero saber si esa linea le pega a un elemento
                if(Physics.Linecast(transform.position, collider.bounds.center, out RaycastHit hit, obstaclesLayer)){
                    //Green line aparece cuando detecta un objeto dentro de su angulo de vision y la linea 
                    //solo es visible por 2 segundos pero sigue detectando el objeto
                    Debug.DrawLine(transform.position, collider.bounds.center, Color.green, 2, true);
                    detectedObject = collider;
                    break;
                } 
                else{
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                }
            }
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);

        //Ojo derecho
        Vector3 rightDirection = Quaternion.Euler(0,angle,0) * transform.forward;
        Gizmos.DrawRay(transform.position,rightDirection * distance);

        //Ojo Izquierdo
        Vector3 leftDirection = Quaternion.Euler(0,-angle,0) * transform.forward;
        Gizmos.DrawRay(transform.position,leftDirection * distance);
    }    
}
