using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement; 


public class SceneChanger : MonoBehaviour
{
public GameObject PantherCard;
public GameObject FarmersCard;
public GameObject RockCard;
public GameObject EasterCard;
public GameObject Schlossbergcard;


public GameObject Devilcard;
//Fragezeichen ausblenden
public GameObject QFarmersCard;
public GameObject QRockCard;
public GameObject QEasterCard;
public GameObject QSchlossbergCard;
public GameObject QDevilCard;
public int panther =0;
    public int farmers = 0;
    public int rock = 0;
    public int easter =0;
    public int schlossberg = 0;
    public int devil = 0;
 

public void Start(){
    panther = PlayerPrefs.GetInt("panther");
    Debug.Log("Panther Int: " + panther);
     farmers = PlayerPrefs.GetInt("farmers");
     rock = PlayerPrefs.GetInt("rock");
    schlossberg=  PlayerPrefs.GetInt("schlossberg");
    devil = PlayerPrefs.GetInt("devil");
        easter = PlayerPrefs.GetInt("easter");
    Debug.Log("Farmers Int: " + farmers);
}     private void Update(){
            if (panther == 1){
            PantherCard.SetActive(true); 
        
            }
            if (farmers == 1){
            FarmersCard.SetActive(true); 
            QFarmersCard.SetActive(false);       
            }
            if(rock==1){
                RockCard.SetActive(true);
                QRockCard.SetActive(false);
            }
             if (easter == 1){
            EasterCard.SetActive(true); 
            QEasterCard.SetActive(false);
            }
            if (schlossberg == 1){
            Schlossbergcard.SetActive(true); 
            QSchlossbergCard.SetActive(false);       
            }
            if(devil==1){
                Devilcard.SetActive(true);
                QDevilCard.SetActive(false);
            }
     }
 public void Scene1() {  
        SceneManager.LoadScene("MultipleImagetracking2");  
    }  
    public void Scene2() {  
        SceneManager.LoadScene("MultipleImagetracking 1");  
    }
    public void Reset(){
        panther=0;
        farmers = 0;
        PantherCard.SetActive(false);   
        FarmersCard.SetActive(false);
        Devilcard.SetActive(false); 
        EasterCard.SetActive(false); 
        Schlossbergcard.SetActive(false); 
        RockCard.SetActive(false); 
        PlayerPrefs.SetInt("panther", panther);
        PlayerPrefs.SetInt("farmers", farmers);
         PlayerPrefs.SetInt("rock", rock);
        PlayerPrefs.SetInt("schlossberg", schlossberg);
         PlayerPrefs.SetInt("devil", devil);
        PlayerPrefs.SetInt("easter", easter);

               //Fragezeichen wieder einblenden
    
                QFarmersCard.SetActive(true); 
                QDevilCard.SetActive(true);
                QEasterCard.SetActive(true);
                QSchlossbergCard.SetActive(true);
                QRockCard.SetActive(true);
    }
}

