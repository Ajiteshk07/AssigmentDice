using System.Collections;
using UnityEngine;
using TMPro;

public class DiceRoller : MonoBehaviour
{   
    private Rigidbody rb;
    private DiceFaceDetector detector;

    public TextMeshProUGUI diceValueText;
    public TextMeshProUGUI equationText;
    public GameObject cardPanel;

    void Start()
{
    rb = GetComponent<Rigidbody>();
    detector = GetComponent<DiceFaceDetector>();

    cardPanel.SetActive(false);
    diceValueText.gameObject.SetActive(false);

    RollDice();
}
    public void RollDice()
    {
        diceValueText.text = "Rolling Dice...";

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        float force = Random.Range(4f, 8f);

        Vector3 randomDirection = new Vector3(
            Random.Range(-1f, 1f),
            1f,
            Random.Range(-1f, 1f)
        );

        rb.AddForce(randomDirection * force, ForceMode.Impulse);

        Vector3 randomTorque = new Vector3(
            Random.Range(-10f, 10f),
            Random.Range(-10f, 10f),
            Random.Range(-10f, 10f)
        );

        rb.AddTorque(randomTorque, ForceMode.Impulse);

        StartCoroutine(WaitForDiceToStop());
    }

IEnumerator WaitForDiceToStop()
{
    float stillTime = 0f;

    while (stillTime < 1f)
    {
        if (rb.velocity.magnitude < 0.05f && rb.angularVelocity.magnitude < 0.05f)
        {
            stillTime += Time.deltaTime;
        }
        else
        {
            stillTime = 0f;
        }

        yield return null;
    }

    int result = detector.GetDiceValue();

    int points = result;
    int multiplier = 10;

    SpiritCard card = GetRandomCard();

    points += card.bonusPoints;
    multiplier += card.multiplierBonus;

    int total = points * multiplier;

    diceValueText.text = "Dice: " + result;
    equationText.text ="Spirit Card\n" +
    card.cardName +
    "\nFinal Score: " + total;

    Debug.Log("Card: " + card.cardName);
    Debug.Log("Final Score = " + total);

    cardPanel.SetActive(true);
    diceValueText.gameObject.SetActive(true);

    
    }
    SpiritCard GetRandomCard()
{
    int roll = Random.Range(0,3);

    if(roll == 0)
        return new SpiritCard("+10 Points",5,5);

    if(roll == 1)
        return new SpiritCard("Double Multiplier",5,5);

    return new SpiritCard("Lucky Bonus",5,5);
}
}
