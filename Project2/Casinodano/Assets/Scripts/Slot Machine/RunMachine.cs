// Pull lever function that runs the game
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RunMachine : MonoBehaviour {
    // Three slot machine slot objects
    [SerializeField] private Image Slot1 = null;
    [SerializeField] private Image Slot2 = null;
    [SerializeField] private Image Slot3 = null;

    // Slot machine pictures
    [SerializeField] private Sprite seven = null;
    [SerializeField] private Sprite apple = null;
    [SerializeField] private Sprite grapes = null;

    [SerializeField] private TMP_InputField betInput = null;
    [SerializeField] private TMP_Text errorMessage = null;

    AudioSource ac;
    void Start() {
        ac = GetComponent<AudioSource>();
    }

    public void pullLever() {
        // Get random numbers
        int slot1 = Random.Range(1, 4);
        int slot2 = Random.Range(1, 4);
        int slot3 = Random.Range(1, 4);
        int bet = 0;
        int winnings = 0;

        ac.Stop(); // Make sure audio clip can't be spammed

        try {
            bet = int.Parse(betInput.text); // Parse the bet
            if (bet <= ChipCount.numChips && ChipCount.numChips > 0) {
                ChipCount.numChips -= bet;      // Subtract their bet

                errorMessage.text = "";
                ac.PlayOneShot(ac.clip);

                if (slot1 == 1 && slot2 == 1 && slot3 == 1) {
                    // 3 apples
                    winnings = 5 * bet;
                    ChipCount.numChips += winnings;
                    errorMessage.text = "Nice apps! you got " + winnings.ToString() + " chips!";
                } else if (slot1 == 2 && slot2 == 2 && slot3 == 2) {
                    // 3 grapes
                    winnings = 10 * bet;
                    ChipCount.numChips += winnings;
                    errorMessage.text = "Cool grapes! you got " + winnings.ToString() + " chips!";
                } else if (slot1 == 3 && slot2 == 3 && slot3 == 3) {
                    // Lucky 7
                    winnings = 100 * bet;
                    ChipCount.numChips += winnings;
                    errorMessage.text = "LUCKY SEVEN WHAT! you got " + winnings.ToString() + " chips!";
                } else {
                    errorMessage.text = "Aww, nothing this time... Maybe pull again?";
                }

                // Show the pictures
                switch (slot1) {
                    case 1:
                        Slot1.sprite = apple;
                        break;
                    case 2:
                        Slot1.sprite = grapes;
                        break;
                    case 3:
                        Slot1.sprite = seven;
                        break;
                }
                switch (slot2) {
                    case 1:
                        Slot2.sprite = apple;
                        break;
                    case 2:
                        Slot2.sprite = grapes;
                        break;
                    case 3:
                        Slot2.sprite = seven;
                        break;
                }
                switch (slot3) {
                    case 1:
                        Slot3.sprite = apple;
                        break;
                    case 2:
                        Slot3.sprite = grapes;
                        break;
                    case 3:
                        Slot3.sprite = seven;
                        break;
                }
            } else {
                errorMessage.text = "You do not have enough chips to make that bet...";
            }
        } catch (System.FormatException e) {
            errorMessage.text = "Please enter a number bet in the left input.";
        }


        
    }
}
