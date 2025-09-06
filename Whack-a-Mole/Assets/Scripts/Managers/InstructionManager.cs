using UnityEngine;

public class InstructionManager : MonoBehaviour
{

    public GameObject instructionPanel;

    public void ActivateInstruction(bool status)
    {
        instructionPanel.gameObject.SetActive(status);
    }
}
