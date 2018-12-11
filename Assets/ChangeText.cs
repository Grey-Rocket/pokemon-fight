using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{

    public int playerHealth;
    public int enemyHealth;

    //health bars
    public Text enemyHealthText;
    public Text playerHealthText;

    //victory sign
    public Image victoryPanel;
    public Text endText;

    public Button attack;

    //text box
    public Image gameTextPanel;
    public Text gameText;

    // Use this for initialization
    void Start()
    {

        enemyHealthText.text = "enemy health : " + enemyHealth;
        playerHealthText.text = "player health : " + playerHealth;

        attack.onClick.AddListener(Attack);
    }

    void Attack()
    {         
        //waiting can be done only in courutines,
        //which must be ienumerators, 
        //but ienumerators cannot be conected to a button
        StartCoroutine(Interacton());
    }

    IEnumerator Interacton()
    {

        // player attack
        //random.range has range [x, y-1]
        int dmg = Random.Range(5, 21);
        enemyHealth -= dmg;
        //button is deactivated
        attack.onClick.RemoveListener(Attack);
        if (enemyHealth <= 0)
        {
            enemyHealthText.text = "enemy health : dead";
            endText.text = "YOU WIN";
            //set active to true and false can only be done on a "gameObject"
            victoryPanel.gameObject.SetActive(true);
            //exits corutine
            yield break;
        }
        else
        {
            enemyHealthText.text = "enemy health : " + enemyHealth;
        }
        gameText.text = "You did " + dmg + " damage";

        //here the program waits
        yield return new WaitForSeconds(1f);

        //enemy attack

        dmg = Random.Range(5, 20);
        playerHealth -= dmg;
        if (playerHealth <= 0)
        {
            playerHealthText.text = "player health : dead";
            endText.text = "YOU LOOSE";
            victoryPanel.gameObject.SetActive(true);
            yield break;
        }
        else
        {
            playerHealthText.text = "player health : " + playerHealth;
        }
        gameText.text = "Enemy did " + dmg + " damage";

        yield return new WaitForSeconds(0.2f);

        attack.onClick.AddListener(Attack);
    }

}
