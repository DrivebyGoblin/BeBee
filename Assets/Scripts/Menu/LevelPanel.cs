using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void OpenLevelsPanel()
    {
        this.gameObject.SetActive(true);
        animator.Play("openLevels");
    }

    public void CloseLevelsPanel() => animator.Play("closeLevels");

}
