using UnityEngine;

public enum ShakerAnimState
{
    None = 0,
    Idle,
    Shake
}

public class ShakerAnim : MonoBehaviour
{
    [SerializeField] private Animator Animator_Shaker;

    private ShakerAnimState _currentState;

    public void SteShakerAnimState(ShakerAnimState newState)
    {
        _currentState = newState;

        switch (_currentState)
        {
            case ShakerAnimState.Idle:
                ResetAllAnimParameters();
                break;
            case ShakerAnimState.Shake:
                Animator_Shaker.SetBool("IsShake", true);
                break;
        }
    }

    private void ResetAllAnimParameters()
    {
        Animator_Shaker.SetBool("IsShake", false);
        Animator_Shaker.Rebind();
        Animator_Shaker.Update(0f);
    }

}