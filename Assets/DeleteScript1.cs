using UnityEngine;

public class DeleteScript1 : MonoBehaviour
{
    // Start is called
    //
    // once before the first execution of Update after the MonoBehaviour is created

    private CharacterController characterController;
    public float speed = 1;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move(Vector3.right * Time.deltaTime * speed);
    }
}
