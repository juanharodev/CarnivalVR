using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootignGame : MonoBehaviour
{
    [SerializeField] List<Transform> bigTargets;
    [SerializeField] List<Transform> smallTargets;
    bool isReady;
    bool isPlaying;
    [SerializeField] Animator courtainAnimator;
    [SerializeField] float waitTime;
    [SerializeField] Rigidbody gun;
    [SerializeField] Transform gunStartPoint;

    void Start()
    {
        ResetGun();
        TurnOffTargets();
    }


    public void StartGame()
    {
        if(isPlaying){return;}
        StartCoroutine(GameRoutine());
    }

    IEnumerator GameRoutine()
    {
        isPlaying = true;
        isReady = false;
        int round = 1;
        
        while(round <= 3)
        {
            //Turn of all targets
            TurnOffTargets();

            //Copy to manipulate non-selected targets
            List<Transform> smallInactives = new List<Transform>(smallTargets);
            List<Transform> bigInactives = new List<Transform>(bigTargets);
            //Activate small targets
            for (int i = 0; i < round; i++)
            {
                int index = Random.Range(0, smallInactives.Count);
                smallInactives[index].gameObject.SetActive(true);
                smallInactives.RemoveAt(index);
            }
            //Activate big targets
            for (int i = 0; i < round + 1; i++)
            {
                int index = Random.Range(0, bigInactives.Count);
                bigInactives[index].gameObject.SetActive(true);
                bigInactives.RemoveAt(index);
            }

            //Start animation
            courtainAnimator.Play("Open");
            //Start game when courtains fully open
            yield return new WaitUntil(() => isReady);
            isReady = false;
            yield return new WaitForSeconds(waitTime);
            courtainAnimator.Play("Close");
            yield return new WaitUntil(() => isReady);
            isReady = false;
            round++;
        }
        isPlaying = false;
        ResetGun();    
    }

    public void SetReady()
    {
        isReady = true;
    }

    private void TurnOffTargets()
    {
        foreach (Transform t in smallTargets)
        {
            t.gameObject.SetActive(false);
        }
        foreach (Transform t in bigTargets)
        {
            t.gameObject.SetActive(false);
        }
    }
    
    public void ResetGun()
    {
        gun.gameObject.SetActive(false);
        gun.transform.position = gunStartPoint.position;
        gun.linearVelocity = Vector3.zero;
        gun.angularVelocity = Vector3.zero;
    }
}
