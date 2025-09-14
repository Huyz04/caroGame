using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    public GameObject end_text;
    public TextMeshProUGUI winner;

    public void SetName (string name)
    {
        winner.text = name + " win";
    }
}
