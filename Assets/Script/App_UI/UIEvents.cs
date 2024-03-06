using System;

public class UIEvents {

    public Action Login_StartGameHandle;
    public void Login_StartGame() {
        if (Login_StartGameHandle != null) {
            Login_StartGameHandle.Invoke();
        }
    }

    public Action SelectElement_SelectHandle;

    public void Shovel_Select() {
        if (SelectElement_SelectHandle != null) {
            SelectElement_SelectHandle.Invoke();
        }
    }

    public Action ShovelElement_ShovelHandle;  

    public void Panel_ShovelElement_Shovel() {
        if (ShovelElement_ShovelHandle != null) {
            ShovelElement_ShovelHandle.Invoke();
        }
    }


    public UIEvents() {}

}