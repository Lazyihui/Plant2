using System;

public class UIEvents {

    public Action Login_StartGameHandle;
    public void Login_StartGame() {
        if (Login_StartGameHandle != null) {
            Login_StartGameHandle.Invoke();
        }
    }

    public Action<int> SelectElement_SelectHandle;

    public void SelectElement_Select(int typeID) {
        if (SelectElement_SelectHandle != null) {
            SelectElement_SelectHandle.Invoke(typeID);
        }
    }

    public Action ShovelElement_ShovelHandle;

    public void ShovelElement_Shovel() {
        if (ShovelElement_ShovelHandle != null) {
            ShovelElement_ShovelHandle.Invoke();
        }
    }

    public Action<int> PlantManifestElement_PlantHandle;

    public void PlantManifestElement_Plant(int typeID) {
        if (PlantManifestElement_PlantHandle != null) {
            PlantManifestElement_PlantHandle.Invoke(typeID);
        }
    }


    public Action Panel_Start_StartHandle;

    public void Panel_Start_Start() {
        if (Panel_Start_StartHandle != null) {
            Panel_Start_StartHandle.Invoke();
        }
    }

    public UIEvents() { }

}