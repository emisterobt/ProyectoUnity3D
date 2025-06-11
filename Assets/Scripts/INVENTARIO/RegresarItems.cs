
using UnityEngine;

public class RegresarItems : MonoBehaviour
{
    private Transform playerLoc;
    private Vector3 lastLoc;
    [SerializeField] private float spawnOffsetRadius = 1.0f;

    private Items items;

    void Start()
    {
        lastLoc = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && player.activeInHierarchy)
        {
            playerLoc = player.transform;
            lastLoc = playerLoc.position;
        }
    }


        

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUpItem"))
        {

            Vector3 spawnPosition = (playerLoc != null) ? playerLoc.position : lastLoc;

            Vector3 randomOffset = Random.insideUnitSphere * spawnOffsetRadius;
            randomOffset.y = 0;

            spawnPosition += randomOffset;

            Items obj = other.gameObject.GetComponent<Items>();
            Inventario2.Instance.RemoveItem(obj);
            GameObject clone = Instantiate(other.gameObject, spawnPosition, Quaternion.identity);
            Destroy(clone.GetComponent<PhyssicalInventoryu>());
            Destroy(clone.GetComponent<Rigidbody>());
            Destroy(other.gameObject);
        }
        CamaraInventario.Instance.CambiarCamara();
    }
}
