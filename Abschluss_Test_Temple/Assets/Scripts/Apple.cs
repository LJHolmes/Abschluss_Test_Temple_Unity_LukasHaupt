using UnityEngine;

public class Apple : MonoBehaviour
{
    public bool IsInPlace = false;

    private SoundManager soundManager;
    private GameMaster gameMaster;
    private Rigidbody appleRB;

    [SerializeField] private bool appleTR;
    [SerializeField] private bool appleBL;
    [SerializeField] private bool appleTL;
    [SerializeField] private bool appleBR;

    [SerializeField] private GameObject SpotTR;
    [SerializeField] private GameObject SpotBL;
    [SerializeField] private GameObject SpotTL;
    [SerializeField] private GameObject SpotBR;

    [SerializeField] private float distance;
    [SerializeField] private float rightDistance = 1f;


    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        soundManager = GameObject.Find("Main Camera").GetComponent<SoundManager>();

        appleRB = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
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

        gameMaster.AppleScore++;

        appleRB.useGravity = false;
        appleRB.isKinematic = true;
    }
}
