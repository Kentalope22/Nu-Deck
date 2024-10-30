using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
   [SerializeField] Text dialogText;
   [SerializeField] int lettersPerSecond;
   [SerializeField] Color highlightedColor;

   [SerializeField] GameObject actionSelector;
   [SerializeField] GameObject moveSelector;
   [SerializeField] GameObject moveDetails;

   [SerializeField] List<Text> actionTexts;
   [SerializeField] List<Text> moveTexts;

   [SerializeField] Text ppText;
   [SerializeField] Text typeText;

   public void SetDialog(string dialog)
   {
    dialogText.text = dialog;
   }

   public IEnumerator TypeDialog (string dialog)
   {
    dialogText.text = "";
    foreach(var letter in dialog.ToCharArray())
    {
        dialogText.text += letter; //making the letters in the dialogue box appear one by one
        yield return new WaitForSeconds(1f/lettersPerSecond); 
    }
    yield return new WaitForSeconds(1f);
   }

   public void EnableDialogText(bool enabled) //displays text messages after the battle //
   {
    dialogText.enabled = enabled;
   }

   public void EnableActionSelector(bool enabled) // shows the UI such as Fight, Run //
   {
    actionSelector.SetActive(enabled);
   }

   public void EnableMoveSelector(bool enabled) // shows the UI for selecing moves //
   {
    moveSelector.SetActive(enabled);
    moveDetails.SetActive(enabled);
   }

   public void UpdateActionSelection(int selectedAction)
   {
    for (int i=0; i<actionTexts.Count; ++i)
    {
        if (i == selectedAction)
            actionTexts[i].color = highlightedColor; //highlights the color when selecting action based on the user input//
        else
            actionTexts[i].color = Color.black; // text goes back to black after selecting another option //
    }
   }

   public void UpdateMoveSelection(int selectedMove, Move move)
   {
    for (int i=0; i<moveTexts.Count; ++i)
    {
        if (i == selectedMove)
            moveTexts[i].color = highlightedColor; // same for move selection //
        else
            moveTexts[i].color = Color.black; // same for move selection //
    }

    ppText.text = $"PP { move.PP}/{move.baseStats.PP}";
    typeText.text = move.baseStats.Type.ToString();
   }

   public void SetMoveNames(List<Move> moves)  //used to update the UI to show the player's available moves //
   {
    for (int i=0; i<moveTexts.Count; ++i)
    {
        if (i < moves.Count)
            moveTexts[i].text = moves[i].baseStats.Name; // name of the move //
        else
            moveTexts[i].text = "-"; // if there is no move available it shows as - //
    }
   }
}
