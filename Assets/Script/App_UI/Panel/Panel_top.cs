using UnityEngine;
using UnityEngine.UI;

public class Panel_top : MonoBehaviour {

    [SerializeField] Image elePrefab;

    public int cellCount;

    public void Ctor() {
    }

    public void Init() {
        cellCount = 10;
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }

}