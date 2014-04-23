using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerController : MonoBehaviour {

	public GameObject TowerBase;
	public GameObject TowerModule;
	public GameObject TowerWeapon;
	
	private static int buttonwidth = 30;
    private static float buttonheight;
    public CustomTower WorkingTower;
    public GameObject WorkingTowerSpawn;
    public Vector3 TowerCenter;

    int WorkingSlot;

	public List<CustomTower> CustomTowers {
		get {
			return TowerSelectionMenu.Instance.towers;
		}
	}

	public List<GameObject> SavedTowers {
		get {
			return TowerSelectionMenu.Instance.towerInstances;
		}
	}

	// Use this for initialization
	void Start () {
        TowerCenter = GUIUtilities.GuiScreenToWorld(new Vector2(this.Width(.5f), this.Height(.25f)));
        TowerBase.SetActive(true);
        TowerModule.SetActive(false);
        TowerWeapon.SetActive(false);

        buttonheight = this.Height(.2f);
        for (int i = 0; i < 8; i++) {
			SavedTowers[i].transform.position = GUIUtilities.GuiScreenToWorld(new Vector2(this.Width(.3f) + this.Height(.125f) * i, this.Height(.9f)));
			SavedTowers[i].SetActive(true);
        }
        SelectSlot(0);
	}

    public void SetComponent(string module, GameObject obj) {
        switch(module)
        {
            case "Base":
                WorkingTower.towerBase = obj;
                break;
            case "Module":
                WorkingTower.towerModule = obj;
                break;
            case "Weapon":
                WorkingTower.towerWeapon = obj;
                break;
        }
		CustomTowers[WorkingSlot] = WorkingTower;
		TowerSelectionMenu.Instance.RefreshTower(WorkingSlot);
		SelectSlot(WorkingSlot);
    }

    void SelectSlot(int slot) {
		if (WorkingTowerSpawn != null) {
			Destroy(WorkingTowerSpawn);
		}
		Destroy(WorkingTowerSpawn);

        WorkingSlot = slot;
		WorkingTower = CustomTowers[slot];
        WorkingTowerSpawn = WorkingTower.Spawn(TowerCenter);
        WorkingTowerSpawn.transform.localScale = new Vector3(2f, 2f, 0f);
    }
	void OnGUI() {
        
		//Edit Tower Slot Button Loop
        for (int i = 0; i < 8; i++) {
            
            if (GUI.Button(this.CenteredRect(this.Width(.3f) + this.Height(.125f) * i, this.Height(.9f), this.Height(.1f) + 1, this.Height(.1f) + 1), "" + (i + 1))) {
                SelectSlot(i);
            }
        }

        // Use Tower Button
        if (GUI.Button(this.CenteredRect(this.Width(.5f), this.Height(.66f), buttonheight, buttonheight), "Play Game"))
			// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
		{
			Debug.Log("Clicked the button with an image");
			Application.LoadLevel("level-1");

			// use get component to get the prefab info for whichever prefab is selected
		}
		// Component Selection Window
        if (GUI.Button(new Rect(this.Width(.75f), this.Height(.66f), buttonwidth, this.Height(.33f)), "b\na\ns\ne"))
		{
			Debug.Log("Clicked the button with an image");
			//btnTexture3=btnTexture;
            TowerBase.SetActive ( true);
            TowerModule.SetActive (false);
            TowerWeapon.SetActive (false);
		}
        if (GUI.Button(new Rect(this.Width(.75f), this.Height(.33f), buttonwidth, this.Height(.33f)), "m\no\nd\nu\nl\ne"))
		{
			Debug.Log("Clicked the button with an image");
			//btnTexture3=btnTexture;
            TowerBase.SetActive(false);
            TowerModule.SetActive(true);
            TowerWeapon.SetActive(false);
		}
        if (GUI.Button(new Rect(this.Width(.75f), this.Height(.0f), buttonwidth, this.Height(.33f)), "w\ne\na\np\no\nn"))
		{
			Debug.Log("Clicked the button with an image");
            TowerBase.SetActive(false);
            TowerModule.SetActive(false);
            TowerWeapon.SetActive(true);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
