using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ClearCondition : MonoBehaviour
{
    public TextMeshProUGUI text;
    int score;
    public Transform door;
    public LayerMask player;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerInRange()) {
            NextLevel();
            Debug.Log("Open");
        }

        if (score == 1) {
            ChangeClearCondition();
        }
    }

    private void NextLevel() {
        if (score == 1) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Correct() {
        score = 1;
    }

    public bool playerInRange() {
        // checks if the player is touching the door
        Collider2D collisionCheck = Physics2D.OverlapCircle(door.position, 0.5f, player);
         if (collisionCheck != null) {
            return true;
        } else {
            return false;
        }
    }

    private void ChangeClearCondition() {
       text.text = "Clear Condition: O";
   }
}