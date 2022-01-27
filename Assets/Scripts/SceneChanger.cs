using System;
using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement; 


public class SceneChanger : MonoBehaviour{
    public GameObject Hero;
    public GameObject HeroShadow;
    public GameObject NotScanned;
public GameObject DisabledReadStoryButton;
public GameObject ReadStoryButton;
public GameObject PantherCard;
public GameObject FarmersCard;
public GameObject RockCard;
public GameObject EasterCard;
public GameObject Schlossbergcard;

public GameObject PShadow;
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
 public GameObject Overview;
 public GameObject Login;
 public GameObject Onboarding;
 public void Awake()
 {
     Screen.sleepTimeout = SleepTimeout.NeverSleep;
 }

 public void Start(){
    panther = PlayerPrefs.GetInt("panther");
    Debug.Log("Panther Int: " + panther);
     farmers = PlayerPrefs.GetInt("farmers");
     rock = PlayerPrefs.GetInt("rock");
    schlossberg=  PlayerPrefs.GetInt("schlossberg");
    devil = PlayerPrefs.GetInt("devil");
    Debug.Log("Devil Int: " + devil);
        easter = PlayerPrefs.GetInt("easter");
        Debug.Log("Ester Int: " + easter);
    Debug.Log("Farmers Int: " + farmers);
}     private void Update(){
            if (panther == 1){
            PantherCard.SetActive(true); 
            PShadow.SetActive(false);
            HeroShadow.SetActive(false);
         Hero.SetActive(true);
         NotScanned.SetActive(false);
        
            }
            if (farmers == 1){
            FarmersCard.SetActive(true); 
            QFarmersCard.SetActive(false); 
             if (panther == 0){
                 PShadow.SetActive(true);
                 NotScanned.SetActive(false);
             }      
            }
            if(rock==1){
                RockCard.SetActive(true);
                QRockCard.SetActive(false);
                 if (panther == 0){
                 PShadow.SetActive(true);
                 NotScanned.SetActive(false);
             }    
            }
             if (easter == 1){
            EasterCard.SetActive(true); 
            QEasterCard.SetActive(false);
             if (panther == 0){
                 PShadow.SetActive(true);
                 NotScanned.SetActive(false);
             }    
            }
            if (schlossberg == 1){
            Schlossbergcard.SetActive(true); 
            QSchlossbergCard.SetActive(false);
             if (panther == 0){
                 PShadow.SetActive(true);
                 NotScanned.SetActive(false);
             }           
            }
            if(devil==1){
                Devilcard.SetActive(true);
                QDevilCard.SetActive(false);
                 if (panther == 0){
                 PShadow.SetActive(true);
                 NotScanned.SetActive(false);
             }    
            }
            if (panther == 1 && farmers == 1 && rock == 1 && easter == 1 && schlossberg ==1 && devil==1){
            DisabledReadStoryButton.SetActive(false);
               ReadStoryButton.SetActive(true);
        
            }
     }
 public void Scene1() {  
        SceneManager.LoadScene("MultipleImagetracking2");  
        Login.SetActive(false);
        Onboarding.SetActive(false);
        Overview.SetActive(true);
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }  
    public void Scene2() {  
        SceneManager.LoadScene("MultipleImagetracking 1");  
    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnLevelFinishedLoading");
        Login.SetActive(false);
        Onboarding.SetActive(false);
        Overview.SetActive(true);
    }

    public void Reset(){
        Debug.Log("Reset");
        panther=0;
        farmers = 0;
rock = 0;
easter =0;
schlossberg = 0;
devil = 0;
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
         PShadow.SetActive(false);
         DisabledReadStoryButton.SetActive(true);
         ReadStoryButton.SetActive(false);
         HeroShadow.SetActive(true);
         Hero.SetActive(false);
         NotScanned.SetActive(true);
               //Fragezeichen wieder einblenden
    
                QFarmersCard.SetActive(true); 
                QDevilCard.SetActive(true);
                QEasterCard.SetActive(true);
                QSchlossbergCard.SetActive(true);
                QRockCard.SetActive(true);
                
    }
}

