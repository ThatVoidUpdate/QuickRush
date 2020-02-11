using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;

    public void Play(int Character)
    {
        FindObjectOfType<PlayerLoader>().LoadGame(Character);
    }

    public void Quit()
    {
        Application.Quit(0);
    }

    public void ShowCredits()
    {
        CreditsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void HideCredits()
    {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }
}
