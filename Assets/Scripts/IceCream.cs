using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace BehaviourTrees
{
    public class IceCream : MonoBehaviour
    {
        BehaviourTree tree;

        [Header("VR Hands")]
        [SerializeField] List<Transform> playerHands;
        [SerializeField] float grabDistance = 0.25f;
        [SerializeField] float triggerDistance = 0.5f;

        [Header("Ice Cream")]
        [SerializeField] GameObject cone;
        [SerializeField] XRGrabInteractable interactable;
        [SerializeField] Rigidbody rb;

        [Header("Vendor Positions")]
        [SerializeField] List<Transform> positions;
        [SerializeField] float moveSpeed = 1.5f;

        [Header("Gameplay")]
        [SerializeField] int pity = 5;
        [SerializeField] float fakeGiveWindow = 0.35f;

        float grabTimer;

        int currentIndex = 0;
        int targetIndex = 0;

        void Awake()
        {
            interactable.enabled = false;
            BuildTree();
        }

        void Update()
        {
            tree.Process();

            if (grabTimer > 0f)
                grabTimer -= Time.deltaTime;
        }

        void BuildTree()
        {
            tree = new BehaviourTree("IceCreamVendor");

            // CONDITIONS
            Condition playerClose = new Condition(PlayerIsClose);
            Condition playerGrabbedInTime = new Condition(PlayerGrabbedInWindow);
            Condition outOfPity = new Condition(() => pity <= 0);

            // ACTIONS
            ActionStrategy startFakeGive = new ActionStrategy(StartFakeGive);
            ActionStrategy punishGrab = new ActionStrategy(PullBack);
            ActionStrategy choosePosition = new ActionStrategy(ChooseNewPosition);
            ActionStrategy enableGrab = new ActionStrategy(EnableGrab);

            MoveToTransform moveToPosition = new MoveToTransform(
                transform,
                () => positions[targetIndex],
                moveSpeed
            );

            // GIVE ICE CREAM
            Sequence giveIceCream = new Sequence("GiveIceCream");
            giveIceCream.AddChild(new Leaf("OutOfPity?", outOfPity));
            giveIceCream.AddChild(new Leaf("EnableGrab", enableGrab));

            // TEASE
            Sequence tease = new Sequence("Tease");
            tease.AddChild(new Leaf("PlayerClose?", playerClose));
            tease.AddChild(new Leaf("StartFakeGive", startFakeGive));
            tease.AddChild(new Leaf("GrabbedInTime?", playerGrabbedInTime));
            tease.AddChild(new Leaf("Punish", punishGrab));
            tease.AddChild(new Leaf("ChoosePosition", choosePosition));
            tease.AddChild(new Leaf("MoveAway", moveToPosition));

            Selector root = new Selector("Root");
            root.AddChild(giveIceCream);
            root.AddChild(tease);

            tree.AddChild(root);
        }

        // ===================== CONDITIONS =====================

        bool PlayerIsClose()
        {
            foreach (var hand in playerHands)
            {
                if (Vector3.Distance(hand.position, cone.transform.position) < triggerDistance)
                    return true;
            }
            return false;
        }

        bool PlayerGrabbedInWindow()
        {
            if (grabTimer <= 0f)
                return false;

            foreach (var hand in playerHands)
            {
                if (Vector3.Distance(hand.position, cone.transform.position) < grabDistance)
                    return true;
            }
            return false;
        }

        // ===================== ACTIONS =====================

        void StartFakeGive()
        {
            grabTimer = fakeGiveWindow;
        }

        void PullBack()
        {
            pity--;
            transform.Rotate(180f, 0f, 0f);
        }

        void ChooseNewPosition()
        {
            if (positions.Count <= 1)
                return;

            int newIndex;
            do
            {
                newIndex = Random.Range(0, positions.Count);
            }
            while (newIndex == currentIndex);

            targetIndex = newIndex;
            currentIndex = newIndex;
        }

        void EnableGrab()
        {
            interactable.enabled = true;
            rb.useGravity = true;
        }
    }
}