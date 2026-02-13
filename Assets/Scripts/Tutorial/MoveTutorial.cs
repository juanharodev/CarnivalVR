using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTutorial : MonoBehaviour
{
    [SerializeField] InputActionReference movement;
    [SerializeField] float time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movement.action.ReadValue<Vector2>() != Vector2.zero)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
