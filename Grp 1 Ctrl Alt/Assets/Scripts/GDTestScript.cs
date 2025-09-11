using UnityEngine;
using UnityEngine.InputSystem;

public class GDTestScript : MonoBehaviour
{
    public SusRessource sus;
    public PissRessource piss;
    public EnergyRessource energy;

    [SerializeField]
    private float SusAddValue, SusRemoveValue, PissAddValue, PissRemoveValue, EnergyAddValue, EnergyRemoveValue;

    public void OnSusAdd(InputValue _)
    {
        sus.Add(SusAddValue);
    }

    public void OnSusRemove(InputValue _)
    {
        sus.Remove(SusRemoveValue);
    }

    public void OnPissAdd(InputValue _)
    {
        piss.Add(PissAddValue);
    }

    public void OnPissRemove(InputValue _)
    {
        piss.Remove(PissRemoveValue);
    }

    public void OnEnergyAdd(InputValue _)
    {
        energy.Add(EnergyAddValue);
    }

    public void OnEnergyRemove(InputValue _)
    {
        energy.Remove(EnergyRemoveValue);
    }

}
