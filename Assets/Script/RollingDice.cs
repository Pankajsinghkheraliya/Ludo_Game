using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingDice : MonoBehaviour
{
    [SerializeField] int numberGot;
    [SerializeField] GameObject rollingDiceAnim;
    [SerializeField] SpriteRenderer numberdSpHolder;
    [SerializeField] Sprite[] numberdSprites;

    bool canDiceRoll = true;
    Coroutine generateRandNumOnDice_Coroutine;

    private void OnMouseDown()
    {
        generateRandNumOnDice_Coroutine = StartCoroutine(GenerateRandomNumberOnDice());
    }

    IEnumerator GenerateRandomNumberOnDice()
    {
        yield return new WaitForEndOfFrame();

        if (canDiceRoll)
        {
            canDiceRoll = false;
            numberdSpHolder.gameObject.SetActive(false);
            rollingDiceAnim.SetActive(true);
            yield return new WaitForSeconds(1f);
            numberGot = Random.Range(0, 6); // This should be 0 to 6
            numberdSpHolder.sprite = numberdSprites[numberGot];
            numberGot += 1;

            GameManager.gm.numOfStepsToMove = numberGot;
            GameManager.gm.rolledDice = this;

            numberdSpHolder.gameObject.SetActive(true);
            rollingDiceAnim.SetActive(false);
            yield return new WaitForEndOfFrame();
            canDiceRoll = true;

            if (generateRandNumOnDice_Coroutine != null)
            {
                StopCoroutine(generateRandNumOnDice_Coroutine);
            }
        }
          
    }
}
