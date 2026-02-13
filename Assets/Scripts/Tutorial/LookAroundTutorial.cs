using UnityEngine;
using UnityEngine.InputSystem;

public class LookAroundTutorial : MonoBehaviour
{
    [SerializeField] InputActionReference lookReference;
    [SerializeField] int times;
    float nexTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nexTime <= Time.deltaTime && lookReference.action.ReadValue<Vector2>().x != 0 )
        {
            nexTime++;
            times--;
            if (times <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
