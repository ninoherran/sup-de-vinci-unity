using DefaultNamespace.saveManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumePanelController : MonoBehaviour
{
    [SerializeField] private GameObject resumeButtonPrefab;
    [SerializeField] private Transform container;

    // Start is called before the first frame update
    void Start()
    {
        var saves = SaveManager.GetSaves();
        foreach (var save in saves)
        { 
            Instantiate(resumeButtonPrefab, container).GetComponent<ResumeButtonController>()
                .LoadSave(save);
        }
    }
    
}