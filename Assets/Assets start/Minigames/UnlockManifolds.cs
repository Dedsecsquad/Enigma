using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class UnlockManifolds : MonoBehaviour
{

    public List<Button> buttons;// list of our buttons
    public List<Button> shuffledButtons; // shuffled version of this list
    int counter = 0; // keep track of how many buttons were pressed in sequence Unity Message references
    public void Start()
    {
        RestartTheGame(); // in the beginning just restart game session
    }

    public void RestartTheGame()
    {
        counter = 0;// reset the press counter
        shuffledButtons = buttons.OrderBy(a => Random.Range(0, 100)).ToList();
        for (int i = 1; i < 11; i++)
        {

            shuffledButtons[i - 1].GetComponentInChildren<Text>().text = i.ToString(); // set the text on buttons to correct number shuffledButtons[i - 1].interactable = true; // set all buttons pressable
            shuffledButtons[i - 1].interactable = true;
            shuffledButtons[i - 1].image.color = new Color32(177, 228, 233, 255); // our initial color
        }
    }
    public void pressButton(Button button) // function for buttons to call on click
    {
        if (int.Parse(button.GetComponentInChildren<Text>().text) - 1 == counter) // check if the number on the button -1 is equal to counter so we know that this button is pressed in correct order counter++; // increase the counter
        {
            counter++;
            button.interactable = false; // disable the button
            button.image.color = Color.green; // set color to green
            if (counter == 10) // check if all buttons are pressed already
            {
                StartCoroutine(presentResult(true)); // present result for winning
            }
        }
        else
        {
            StartCoroutine(presentResult(false)); // in case the button was not pressed in correct sequence - present result for loosing
        }
    }

    public IEnumerator presentResult(bool win) // coroutine for game result presentation
    {
        if (!win) // if player lost
        {
            foreach (var button in shuffledButtons)
            {
                button.image.color = Color.red; // set colors of all buttons to red button.interactable = false; // set all buttons to noninteractable state
                button.interactable = false;
            }
            yield return new WaitForSeconds(2f); // wait for 2 seconds so player can see the result RestartTheGame(); // and then just start the game again
            RestartTheGame();
        }
    }
}
