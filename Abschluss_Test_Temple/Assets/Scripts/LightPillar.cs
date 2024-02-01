using UnityEngine;

public class LightPillar : MonoBehaviour
{
    public bool PillarGreen;
    public bool PillarRed;
    public bool PillarBlue;

    private Rizzle2Master rizzle2Master;

    [SerializeField] private GameObject pointLight;

    private void Start()
    {
        rizzle2Master = GameObject.Find("GameMaster").GetComponent<Rizzle2Master>();
    }

    private void OnMouseDown()
    {
        pointLight.SetActive(!pointLight.activeSelf);

        if (pointLight.activeSelf)
        {
            rizzle2Master.TurnedLightOn(gameObject);
        }
    }

    public void SetLightsOff()
    {
        rizzle2Master.TurnLightsOff(gameObject);

        pointLight.SetActive(false);
    }
}
