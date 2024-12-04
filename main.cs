using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoice : MonoBehaviour
{
    public Sprite[] sprites;

    public Button rockButton;
    public Button paperButton;
    public Button scissorButton;
    public Button playButton;
    public Button resetButton;
    public Button backButton;

    public Image img;

    public int randChoice = -1;
    public TextMeshProUGUI resultText, aiScoreText, playerScoreText;

    public int playerChoice = -1, aiScore = 0, playerScore = 0;

    // Start the game
    public void Play()
    {
        randChoice = Random.Range(0, 3); // Fixed range
        EnableGameButtons();
        HideUIElements(playButton);
        ShowUIElements(aiScoreText, playerScoreText);
        ShowUIElements(backButton);
    }

    // Player chooses Rock
    public void Rock() => PlayerSelection(0);

    // Player chooses Paper
    public void Paper() => PlayerSelection(1);

    // Player chooses Scissor
    public void Scissor() => PlayerSelection(2);

    // Process player selection
    private void PlayerSelection(int choice)
    {
        playerChoice = choice;
        img.sprite = sprites[randChoice];
        UpdateUIAfterChoice();
        CountResult();
    }

    // Reset the game state
    public void Reset()
    {
        randChoice = Random.Range(0, 3);
        EnableGameButtons();
        HideUIElements(img, resultText, resetButton);
        ShowUIElements(backButton);
    }

    // Return to main menu
    public void Back()
    {
        HideUIElements(aiScoreText, playerScoreText, rockButton, paperButton, scissorButton, resetButton, resultText, img);
        ShowUIElements(playButton);
        HideUIElements(backButton);
    }

    // Calculate results
    private void CountResult()
    {
        resultText.gameObject.SetActive(true);

        if (randChoice == playerChoice)
        {
            resultText.text = "   Draw";
        }
        else if ((playerChoice == 0 && randChoice == 2) ||
                 (playerChoice == 1 && randChoice == 0) ||
                 (playerChoice == 2 && randChoice == 1))
        {
            resultText.text = "You Won!";
            playerScore++;
        }
        else
        {
            resultText.text = "AI Won!";
            aiScore++;
        }

        // Update scores
        aiScoreText.text = aiScore.ToString();
        playerScoreText.text = playerScore.ToString();
    }

    // Helper methods to manage UI
    private void EnableGameButtons()
    {
        rockButton.gameObject.SetActive(true);
        paperButton.gameObject.SetActive(true);
        scissorButton.gameObject.SetActive(true);
    }

    private void HideUIElements(params MonoBehaviour[] elements)
    {
        foreach (var element in elements)
        {
            element.gameObject.SetActive(false);
        }
    }

    private void ShowUIElements(params MonoBehaviour[] elements)
    {
        foreach (var element in elements)
        {
            element.gameObject.SetActive(true);
        }
    }

    private void UpdateUIAfterChoice()
    {
        HideUIElements(rockButton, paperButton, scissorButton, playButton);
        ShowUIElements(img, resetButton, resultText, backButton);
    }
}


