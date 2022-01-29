using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void NameEntry(string name)
    {
        PlayerPrefs.Instance.playerName = name;
        Debug.Log(name);
    }
     public void StartNew()
    {
        SceneManager.LoadScene(1);
    }


}
