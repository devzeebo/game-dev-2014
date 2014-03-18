using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerController : MonoBehaviour {
	public GameObject TowerBase;
	public GameObject TowerModule;
	public GameObject TowerWeapon;
	static private int buttonwidth = 30;
    static private float buttonheight;
    public CustomTower WorkingTower;
    public GameObject WorkingTowerSpawn;
    public List<GameObject> SavedTowers;
    public Vector3 TowerCenter;

    int WorkingSlot;

	// Use this for initialization
	void Start () {
        TowerCenter = Utilities.ScreenToWorld(new Vector2(this.Width(.5f), this.Height(.25f)));
        SavedTowers = new List<GameObject>();
        TowerBase.SetActive(true);
        TowerModule.SetActive(false);
        TowerWeapon.SetActive(false);
        buttonheight = this.Height(.2f);
        SelectSlot(0);
	}
    void RenderSlotButton(int index) {
        TowerSelectionMenu.Instance[index].Spawn(Utilities.ScreenToWorld(new Vector2(this.Width(.25f)+this.Height(.15f)*index, this.Height(.9f))));
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
        if (WorkingTowerSpawn != null) {
            Destroy(WorkingTowerSpawn);
        }
        WorkingTowerSpawn = WorkingTower.Spawn(TowerCenter);
        TowerSelectionMenu.Instance[WorkingSlot] = WorkingTower;
    }

    void SelectSlot(int slot) {
        WorkingSlot = slot;
        Destroy(WorkingTowerSpawn);
        WorkingTower = TowerSelectionMenu.Instance[slot];
        WorkingTowerSpawn = WorkingTower.Spawn(TowerCenter);
        WorkingTowerSpawn.transform.localScale = new Vector3(2f, 2f, 0f);
    }
	void OnGUI(){
        
		//Edit Tower Slot Button Loop
        for (int i = 0; i < 8; i++) {
            RenderSlotButton(i);
        }
        /*
		if (GUI.Button(this.CenteredRect(this.Width(.5f), this.Height(.66f), buttonheight, buttonheight),"Slot 0"))
		{
            SelectSlot(0);
            Vector3 Button1 = new Vector3(screenwidth / 3 - 50, screenheight / 2 - 50, 0);
            TowerSelectionMenu.Instance[0].Spawn(Button1);
            TowerSelectionMenu.Instance[0] = WorkingTower;
		}
		if (GUI.Button(new Rect(2*screenwidth/3-50 , screenheight/2-50, 100, 100),"Slot 2"))
		{
            SelectSlot(1);
		}
        //*/
        // Use Tower Button
        if (GUI.Button(this.CenteredRect(this.Width(.5f), this.Height(.66f), buttonheight, buttonheight), "Use Tower"))
			// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
		{
			Debug.Log("Clicked the button with an image");
			Application.LoadLevel(2);

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
