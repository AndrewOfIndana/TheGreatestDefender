using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    /*  
        Name: MenuManager.cs
        Description: This script controls the main menu

    */
    /*[Header("Static References")]*/
    GameManager gameManager;

    [Header("Script References")]
    public GameObject[] menuScreens;
    public Image[] levelIcons;

    /*---      SETUP FUNCTIONS     ---*/
    /*-  Start is called before the first frame update -*/
    private void Start()
    {
        /* Gets the static instances and stores them in the Static References */
        gameManager = GameManager.instance;

        UpdateScreen(0);

        /* Adds listeners for each buttons for each level */
        for(int i = 0; i < levelIcons.Length; i++)
        {
            AddListeners(levelIcons[i].GetComponent<Button>(), i);
        }
    
        /*  Hides the level icons that haven't been unlocked  */
        HideUI(levelIcons, gameManager.GetLastPlayedLevel()); 
    }

    /*---      FUNCTIONS     ---*/
    /*-  Adds listeners to each button, takes a button and the index from the for loop -*/
    private void AddListeners(Button btn, int index)
    {
        btn.onClick.AddListener(() => { OnButtonClick(index); }); //Adds a listeners a button
    }
    /*-  Checks if a button is clicked, uses an index to indicate which button, OnClick -*/
    private void OnButtonClick(int index)
    {
        gameManager.SelectLevel((index + 1));
    }
    /*-  Hides unused buttons or images by setting the images inactive in reverse order, takes a Image[] for the array of images affected, and a int for the listSize   -*/
    public void HideUI(Image[] icons, int listSize)
    {
        for(int i = icons.Length - 1; i >= listSize; i--)
        {
            icons[i].gameObject.SetActive(false);
        }
    }
    /*-  Opens level select menu, OnClick   -*/
    public void LevelSelect()
    {
        UpdateScreen(1);
    }
    /*-  Opens options menu, OnClick   -*/
    public void Options()
    {
        UpdateScreen(2);
    }
    /*-  Backs out to Main menu, OnClick   -*/
    public void Back()
    {
        UpdateScreen(0);
    }
    /*-  Buttons for GameManager's quit function, OnClick   -*/
    public void QuitGame()
    {
        gameManager.QuitGame();
    }
    /*-  Updates the Swaps the screen, takes an index for chosen screen -*/
    private void UpdateScreen(int index)
    {
        for(int i = 0; i < menuScreens.Length; i++)
        {
            menuScreens[i].SetActive(false);
        }
        menuScreens[index].SetActive(true);
    } 
}