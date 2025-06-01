using UnityEngine;
using UnityEngine.InputSystem;

public class ExitPanelScript : MonoBehaviour
{
    public RectTransform uiElement;
    public float edgeThreshold = 0.1f; // % from edges where alpha is 0
    public float middleRadius = 0.2f;  // radius around center where alpha is 0

    public float minimumAlphaTreshold = 0.3f;


    public CanvasGroup canvasGroup;

    void Start()
    {
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();

        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 screen = new Vector2(Screen.width, Screen.height);
        Vector2 normalizedPos = new Vector2(mousePos.x / screen.x, mousePos.y / screen.y);


        //float alphaEdgeX = Mathf.InverseLerp(0, edgeThreshold, Mathf.Min(normalizedPos.x, 1 - normalizedPos.x));
        //float alphaEdgeY = Mathf.InverseLerp(0, edgeThreshold, Mathf.Min(normalizedPos.y, 1 - normalizedPos.y));
        //float alphaEdge = Mathf.Min(alphaEdgeX, alphaEdgeY);

        Vector2 center = new Vector2(0.5f, 0.5f);
        float distToCenter = Vector2.Distance(normalizedPos, center);


        float alphaMiddle = Mathf.InverseLerp(0, middleRadius, distToCenter);

        float alpha = 0;
        alpha = alphaMiddle;
        if (Mathf.Min(normalizedPos.x, 1 - normalizedPos.x) < edgeThreshold || Mathf.Min(normalizedPos.y, 1 - normalizedPos.y) < edgeThreshold)
        {
            alpha = 0;
        }
        if (minimumAlphaTreshold > alpha)
        {
            alpha = 0;
        }
        alpha = Mathf.Clamp01(alpha);

        canvasGroup.alpha = alpha;
    }

}
