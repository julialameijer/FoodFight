using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UtilityScript : MonoBehaviour
{
    private GameObject chosenChar;

    public void Start()
    {
        
    }

    public void ChangeScene(string sceneName)
    { 
        SceneManager.LoadScene(sceneName);
    }
    
    public void CharacterName(GameObject charObj)
    {
        charObj = chosenChar;
        print(chosenChar);
    }   
}
