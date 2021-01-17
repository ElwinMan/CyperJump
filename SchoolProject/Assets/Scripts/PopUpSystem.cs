using UnityEngine;
public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;

    public void PopUp() {
        popUpBox.SetActive(true);
        animator.SetTrigger("pop");
    }
}
