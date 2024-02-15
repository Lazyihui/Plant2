using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    [SerializeField] Panel_Login panel_Login;


    void Start() {

        panel_Login.Ctor();
        panel_Login.Show();
        panel_Login.OnStartClickHandle += () => {
            panel_Login.Close();
            LoginBusiness.Enter();
            GameBusiness.Enter();
        };




    }

    void Update() {

    }
}
