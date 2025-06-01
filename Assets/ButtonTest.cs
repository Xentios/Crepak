using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    [SerializeField]
    private float fillSpeed = 1.0f;

    [SerializeField]
    private Image pointerEnterImage;


    private bool pointerInside = false;
    private RectTransform pointerRectTransform;
    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        pointerRectTransform = pointerEnterImage.GetComponent<RectTransform>();
    }

    public void OnPointerEntered()
    {
        pointerInside = true;
        Debug.Log("Pointer entered.");
    }

    public void OnPointerExited()
    {
        Debug.Log("Pointer exited.");
        pointerEnterImage.transform.localScale = Vector3.zero;
        pointerInside = false;
    }

    private void Update()
    {
        if (pointerInside == true)
        {
            pointerEnterImage.transform.localScale += fillSpeed * Vector3.one * Time.deltaTime;
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            pointerRectTransform.position = mousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
         pointerRectTransform as RectTransform,
         mousePosition,
         Camera.main,
         out Vector2 localPoint
     );
            // pointerRectTransform.anchoredPosition = localPoint;
        }

    }

    public void OnClick()
    {
        Application.Quit();
    }


}
