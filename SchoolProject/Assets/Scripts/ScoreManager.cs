using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int coinAmount;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        }
    }

    // Change the coin value on the GUI
    public void ChangeCoinAmount(int coinValue) {
        coinAmount += coinValue;
        text.text = "x" + coinAmount.ToString();
    }
}
