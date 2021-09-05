using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DSessionController : MonoBehaviour
{
    [SerializeField] private GameObject next_Button;
    [SerializeField] private Text question_Text = null;
    string[] questions = { "What did you learn about the game?", "What strategie did you use in the game?", "Now that you know the game, would you change the strategie next time?", "Did you use short cuts durign the game? Why or why not?", " Was it worth it to take a shortcut?", "What does this game suggests about strategies for incurring and managing technical debt?", "Thank you player, we hope you enjoy the game. Press next to go back to the main menu"};
    [SerializeField] private int Index = 0;

    private void Start()
    {
        next_Button.SetActive(true);
        question_Text.text = "Now, you and your co-players will answer and discuss about the next series of questions, so you can learn from each other's experience. Press next to continue";
    }

    public void onNextButton()
    {
        if (Index == questions.Length)
        {
            SceneManager.LoadScene("LogMenu");
        }
        else
        {
            question_Text.text = questions[Index];
            Index++;
        }
        
    }
}
