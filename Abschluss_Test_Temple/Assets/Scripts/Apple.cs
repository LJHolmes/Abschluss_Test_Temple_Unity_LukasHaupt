using UnityEngine;

public class Apple : MonoBehaviour
{
    public bool IsInPlace = false;

    private SoundManager soundManager;
    private Rizzle1Master gameMaster;
    private Rigidbody rb;

    [SerializeField] private bool appleTR;
    [SerializeField] private bool appleBL;
    [SerializeField] private bool appleTL;
    [SerializeField] private bool appleBR;

    [SerializeField] private bool appleFinished = false;

    [SerializeField] private GameObject SpotTR;
    [SerializeField] private GameObject SpotBL;
    [SerializeField] private GameObject SpotTL;
    [SerializeField] private GameObject SpotBR;

    [SerializeField] private float distance;
    [SerializeField] private float rightDistance = 1f;


    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<Rizzle1Master>();
        soundManager = GameObject.Find("Main Camera").GetComponent<SoundManager>();

        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (appleFinished)
        {
            return;
        }

        if (appleTR)
        {
            distance = Vector3.Distance(transform.position, SpotTR.transform.position);

            if (distance < rightDistance)
            {
                AppleInPlace();
                transform.position = SpotTR.transform.position;
            }
        }
        if (appleBL)
        {
            distance = Vector3.Distance(transform.position, SpotBL.transform.position);

            if (distance < rightDistance)
            {
                AppleInPlace();
                transform.position = SpotBL.transform.position;
            }
        }
        if (appleTL)
        {
            distance = Vector3.Distance(transform.position, SpotTL.transform.position);

            if (distance < rightDistance)
            {
                AppleInPlace();
                transform.position = SpotTL.transform.position;
            }
        }
        if (appleBR)
        {
            distance = Vector3.Distance(transform.position, SpotBR.transform.position);

            if (distance < rightDistance)
            {
                AppleInPlace();
                transform.position = SpotBR.transform.position;
            }
        }
    }

    private void AppleInPlace()
    {
        soundManager.PlayCorectSound();

        IsInPlace = true;
        appleFinished = true;

        gameMaster.AppleScore++;

        rb.useGravity = false;
        rb.isKinematic = true;
    }
}
