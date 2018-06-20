/////////////////////////////////////////////////////////////
/////////////Youtube video gevolgd///////////////////////////
/////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public string LevelName;
    public GameObject loadingScreen;
    public Slider slider;
    public int SpriteGenerator;

    private void Start()
    {
        LevelName = PlayerPrefs.GetString("Level", "Menu");//Haalt level naam op, Als het mistlukt, word het standaard op menu gezet.
        Debug.Log(LevelName);
        ///SpriteGenerator = Random.Range(1, 3);//Random lopend popetje genereren op laadscherm.
        LoadLevel(LevelName);//Voer loadlevel uit met level naam
    }

    void LoadLevel(string LevelName)
    {
        StartCoroutine(LoadAsynchronously(LevelName));//??
    }

    /*\v- Waar staat dit eigenlijk voor -v\*/
    IEnumerator LoadAsynchronously(string LevelName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(LevelName);//??

        loadingScreen.SetActive(true);//Laad effect op waar

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);//Laadscherm berekenen.

            slider.value = progress;//laadscherm tekenen

            yield return null;
        }
    }
}
