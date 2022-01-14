using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement; 


public class SceneChanger : MonoBehaviour
{
public GameObject PantherCard;
public int panther;

public void Start(){
    panther = PlayerPrefs.GetInt("panther");
    Debug.Log("Panther Int: " + panther);
}     private void Update(){
            if (panther == 1){
PantherCard.SetActive(true);        
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
        PantherCard.SetActive(false);   
    }
}

