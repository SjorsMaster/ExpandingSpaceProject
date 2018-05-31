/////////////////////////////////////////////////////////////
/////////////Youtube video gevolgd///////////////////////////
/////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScript : MonoBehaviour
{

    public float delay = 0.1f;
    public string fullText;
    public string Stage;

    private string currentText = "";

    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(Stage);
        }
    }
}
