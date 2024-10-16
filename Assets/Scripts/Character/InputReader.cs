using UnityEngine;
using UnityEngine.EventSystems;

public class InputReader : MonoBehaviour
{
    private bool _isJump = false;
    private bool _isAttack = false;

    private void Update()
    {
        ReadJump();
        ReadAttack();
    }

    public bool GetIsJump() =>
        GetBoolAsTrigger(ref _isJump);

    public bool GetIsAttack() =>
        GetBoolAsTrigger(ref _isAttack);

    private void ReadJump()
    {
        if (Input.GetButtonDown(Constants.Hotkey.Jump))
            _isJump = true;
    }

    private void ReadAttack()
    {
        if (Input.GetButtonDown(Constants.Hotkey.Attack) && EventSystem.current.IsPointerOverGameObject() == false)
            _isAttack = true;
    }

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool tempValue = value;
        value = false;
        return tempValue;
    }
}