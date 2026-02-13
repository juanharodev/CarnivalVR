using UnityEngine;
using UnityEngine.Animations.Rigging;

public class IceCreamGameManager : MonoBehaviour
{
    [SerializeField] TwoBoneIKConstraint leftHand;
    [SerializeField] TwoBoneIKConstraint rightHand;
    [SerializeField] Animator animator;
    [SerializeField] Transform iceCreamHandle;
    [SerializeField] Transform icecreamGame;
    [SerializeField] Transform icecream;
    bool isPlaying = false;

    void Awake()
    {
        StopPlaying();
        StopIceCreamGame();
    }

    public void StartPlaying()
    {
        if(isPlaying){return;}
        isPlaying = true;
        animator.SetBool("IsPlaying",true);
        leftHand.weight = 1;
        rightHand.weight = 1;
        iceCreamHandle.gameObject.SetActive(true);
        icecreamGame.gameObject.SetActive(true);
        icecream.gameObject.SetActive(true);

    }

    public void StopPlaying()
    {
        animator.SetBool("IsPlaying",false);
        leftHand.weight = 0;
        rightHand.weight = 0;
        iceCreamHandle.gameObject.SetActive(false);
    }

    public void StopIceCreamGame()
    {
        isPlaying = false;
        icecreamGame.gameObject.SetActive(false);
        icecream.gameObject.SetActive(false);
    }
}
