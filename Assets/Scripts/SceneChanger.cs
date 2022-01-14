using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement; 


public class SceneChanger : MonoBehaviour
{
public GameObject PantherCard;
public GameObject FarmersCard;
public int panther =0;
    public int farmers = 0;

public void Start(){
    panther = PlayerPrefs.GetInt("panther");
    Debug.Log("Panther Int: " + panther);
     farmers = PlayerPrefs.GetInt("farmers");
    Debug.Log("Farmers Int: " + farmers);
}     private void Update(){
            if (panther == 1){
            PantherCard.SetActive(true);        
            }
            if (farmers == 1){
            FarmersCard.SetActive(true);        
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
    }
}

