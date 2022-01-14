using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    public Text obj_text;
    public InputField display_text;
    
    // Start is called before the first frame update
    void Start()
    {
        obj_text.text = PlayerPrefs.GetString("user_name");
    }

    public void Create()
    {
        obj_text.text = display_text.text;
        PlayerPrefs.SetString("user_name", obj_text.text);
        PlayerPrefs.Save();
    }
    
}
