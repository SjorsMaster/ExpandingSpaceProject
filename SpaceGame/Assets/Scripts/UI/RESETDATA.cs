using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RESETDATA : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }
}
