using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement; 


public class SceneChanger : MonoBehaviour
{
 public void Scene1() {  
        SceneManager.LoadScene("MultipleImagetracking2");  
    }  
    public void Scene2() {  
        SceneManager.LoadScene("MultipleImagetracking 1");  
    }
}
