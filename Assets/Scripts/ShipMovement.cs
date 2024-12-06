using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float rotationSpeed = 25f;
    void Update()
    {
        Move();   
        Rotate();

    }

    void Move() {

        transform.position = transform.position + transform.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        
    }
    void Rotate()
    {
        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }

    /*TO DO 
    
    Optie 1:

    void GetHit(){ 
        //zorg voor enemies die terugschieten. Als je geraakt wordt gaan er levens af. als je levens op zijn ben je af en herstart de game.
    }  
    void HealthBoost(){ 
        //zorg voor een extra powerup die je een health boost geeft
    }

    Optie 2:

    void ActivateShield(){ 
        //Zorg voor een energie schild dat aangezet kan worden     
    }
    void DeactivateShield(){
        //Zorg dat je het schild uit kunt zetten om energie te sparen
    }
    void CheckShieldEnergy(){
        //zorg dat je energie op gaat bij gebruik van het schild
        //is de energie op dan gaat het schild uit
    }
    void RegenerateShield(){
        //Zorg dat je schild langzaam regenereert
    } 

    */

}