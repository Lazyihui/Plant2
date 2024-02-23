using UnityEngine;
using System.Collections.Generic;

public class AssetsContext {


    public Dictionary<string, GameObject> entities;

    public Dictionary<string, GameObject> panels;

    public AssetsContext() {
        entities = new Dictionary<string, GameObject>();
        panels = new Dictionary<string, GameObject>();
    }

    public bool Panel_TryGetPrefab(string name, out GameObject prefab) {
        return panels.TryGetValue(name, out prefab);
    }
    public bool Entity_TryGetPrefab(string name, out GameObject prefab) {
        return entities.TryGetValue(name, out prefab);
    }


}
