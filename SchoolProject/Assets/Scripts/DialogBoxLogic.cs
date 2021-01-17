using UnityEngine;

public class DialogBoxLogic : MonoBehaviour
{
    public Transform chest;
    public LayerMask player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerInRange()) {
            AudioManagerScript.PlaySound ("ChestSound");
            Debug.Log("pop");
            PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
            pop.PopUp();
        }
    }


    public bool playerInRange() {
        // checks if the player is touching the chest
        Collider2D collisionCheck = Physics2D.OverlapCircle(chest.position, 0.5f, player);
         if (collisionCheck != null) {
            return true;
        } else {
            return false;
        }
    }
}
