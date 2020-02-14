using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NickEntry : MonoBehaviour
{
    public int SelectedChar = 0;
    bool HasMoved = false;
    bool HasChanged = false;
    public GameObject Arrows;

    private string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private int[] indexes = new int[3];
    public TextMeshProUGUI[] characters;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 && !HasMoved)
        {
            if (SelectedChar < 2)
            {
                SelectedChar++;
                HasMoved = true;
            }
            Arrows.GetComponent<RectTransform>().anchoredPosition = new Vector2(84 * SelectedChar - 84, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0 && !HasMoved)
        {
            if (SelectedChar > 0)
            {
                SelectedChar--;
                HasMoved = true;
            }
            Arrows.GetComponent<RectTransform>().anchoredPosition =  new Vector2(84 * SelectedChar - 84, 0);

        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            HasMoved = false;
        }

        if (Input.GetAxis("Vertical") > 0 && !HasChanged)
        {
            indexes[SelectedChar]++;
            if (indexes[SelectedChar] > 25)
            {
                indexes[SelectedChar] = 0;
            }
            characters[SelectedChar].text = Alphabet[indexes[SelectedChar]].ToString();
            HasChanged = true;
        }
        else if (Input.GetAxis("Vertical") < 0 && !HasChanged)
        {
            indexes[SelectedChar]--;
            if (indexes[SelectedChar] < 0)
            {
                indexes[SelectedChar] = 25;
            }
            characters[SelectedChar].text = Alphabet[indexes[SelectedChar]].ToString();
            HasChanged = true;
        }
        else if (Input.GetAxis("Vertical") == 0)
        {
            HasChanged = false;
        }

        if (Input.GetAxis("Submit") == 1)
        {
            ScoreSaver.SaveTime(Alphabet[indexes[0]].ToString() + Alphabet[indexes[1]].ToString() + Alphabet[indexes[2]].ToString(), FindObjectOfType<Timer>().currentTime);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
    }
}
