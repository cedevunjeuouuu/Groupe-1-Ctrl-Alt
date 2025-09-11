using UnityEngine;

public class GDTestScript : MonoBehaviour
{
    public SusRessource sus;
    public PissRessource piss;
    public EnergyRessource energy;

    [SerializeField]
    private float SusAddValue, SusRemoveValue, PissAddValue, PissRemoveValue, EnergyAddValue, EnergyRemoveValue;

    public void OnSusAdd()
    {
        sus.Add(SusAddValue);
    }

    public void OnSusRemove()
    {
        sus.Remove(SusRemoveValue);
    }

    public void OnPissAdd()
    {
        piss.Add(PissAddValue);
    }

    public void OnPissRemove()
    {
        piss.Remove(PissRemoveValue);
    }

    public void OnEnergyAdd()
    {
        energy.Add(EnergyAddValue);
    }

    public void OnEnergyRemove()
    {
        energy.Remove(EnergyRemoveValue);
    }

}
