using UnityEngine;

public class LookGameObject : MonoBehaviour
{
    public GameObject cam;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = cam.transform.rotation;

        if (CharacterManager.Instance.Player.equipment.curEquip != null && gameObject.CompareTag("ClearTxt"))
        {
            Debug.Log("??");
            Destroy(this.gameObject);
        }
    }
}
