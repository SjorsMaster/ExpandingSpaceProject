using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StageSelect : MonoBehaviour {

    public Image DotLine;
    public Button b;//Dit
    public Button c;//Zijn
    public Button d;//De
    public Button e;//Knoppen
    public Button f;//Knoppen
    public Button g;//Knoppen
    public Button h;//Knoppen
    public Button i;//Knoppen
    public Button j;//Knoppen
    public int SceneSeen;

    private int Completed;//Zie aantal behaalde levels

    private void Start()
    {
        //PlayerPrefs.SetInt("Seen", 5);

        SceneSeen = PlayerPrefs.GetInt("Completed", 0);

        if (SceneSeen == 0)
        {
            SceneSeen++;
            PlayerPrefs.SetInt("Completed", SceneSeen);
            SceneManager.LoadScene("StoryPage1");
        }
    }

    void Update () {
        Completed = PlayerPrefs.GetInt("Completed", 0);

        DotLine.fillAmount = Completed / 10f;

        if (Completed >= 1 && !b.interactable)//Kijk of het aantal benodigde levels gehaald overeenkomt
        {
            b.interactable = true;//Zo ja maak knop bruikbaar
        }
        if (Completed >= 2 && !c.interactable)//Etc.
        {
            c.interactable = true;//Etc..
        }
        if (Completed >= 3 && !d.interactable)//Etc...
        {
            d.interactable = true;//Etc....
        }
        if (Completed >= 4 && !e.interactable)//Etc.....
        {
            e.interactable = true;//Etc......
        }
        if (Completed >= 5 && !f.interactable)//Etc.....
        {
            f.interactable = true;//Etc......
        }
        if (Completed >= 6 && !g.interactable)//Etc.....
        {
            g.interactable = true;//Etc......
        }
        if (Completed >= 7 && !h.interactable)//Etc.....
        {
            h.interactable = true;//Etc......
        }
        if (Completed >= 8 && !i.interactable)//Etc.....
        {
            i.interactable = true;//Etc......
        }
        if (Completed >= 9 && !j.interactable)//Etc.....
        {
            j.interactable = true;//Etc......
        }
        //Kan beste in array maar hoe?
        if (Completed <= 0)
        {
            b.interactable = false;//Als
            c.interactable = false;//er
            d.interactable = false;//iets
            e.interactable = false;//niet klopt
            f.interactable = false;//er
            g.interactable = false;//iets
            h.interactable = false;//niet klopt
            i.interactable = false;//niet klopt
            j.interactable = false;//niet klopt
        }

    }
}
