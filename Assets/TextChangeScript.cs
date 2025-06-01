using TMPro;
using UnityEngine;
using DG.Tweening;

public class TextChangeScript : MonoBehaviour
{

    public FloatReference currency;
    public TextMeshProUGUI  textField;

    public void OnTextChange()
    {
        textField.text = ""+currency.Value;       
    }
}
