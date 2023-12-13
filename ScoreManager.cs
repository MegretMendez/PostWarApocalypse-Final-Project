using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //Start is called before the first frame update
    //Singleton Method: solo puede haber una instancia de un objeto

    public static ScoreManager instance;
    public int amount;
    
    //Metodo Awake se ejecuta antes que cualquier otra, incluyendo el Start Method
    void Awake(){ //ejecuta cada vez que el elemento se instancia o cuando esta en reposo y vuelve y se llama
        if(instance==null){
            instance=this; //si no existe un score, crealo
        }
        else{ //Si ya existe, manda mensaje de error
            Debug.LogError("Duplicated Score,ignoring this one",gameObject);
        }
    }
}

//Pedirle el scoremanager a alguien
