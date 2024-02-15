using UnityEngine;
using UnityEngine.UI;

public class Panel_Login : MonoBehaviour {
    [SerializeField] Button startButton;

    public void Ctor() {
        startButton.onClick.AddListener(OnStartButtonClicked);
        //匿名函数
        startButton.onClick.AddListener(() => {
            Debug.Log("Start Button Clicked");
        });
    }


    void OnStartButtonClicked() {
        Debug.Log("Start Button Clicked");
    }
}