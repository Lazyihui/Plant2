using UnityEngine;
using UnityEngine.UI;
using System;
public class Panel_Login : MonoBehaviour {
    [SerializeField] Button startButton;

    public Action OnStartClickHandle;
    public void Ctor() {

        // startButton.onClick.AddListener(OnStartButtonClicked);
        //匿名函数
        startButton.onClick.AddListener(() => {
            //表示函数指针
            OnStartClickHandle.Invoke();

        });
    }
    
    public void Show() {
        gameObject.SetActive(true);
    }
    public void Close() {
        gameObject.SetActive(false);
    }


    void OnStartClicked() {
        Debug.Log("Start Button Clicked");
    }
}