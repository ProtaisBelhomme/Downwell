using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class Overview_UnityMethods : MonoBehaviour
{
    #region Unity Messages
    // Awake is called when the script instance is being loaded
    private void Awake() { }
    // This function is called when the MonoBehaviour will be destroyed
    private void OnDestroy() { }

    // Reset is called when the user hits the Reset button in the Inspector's
    private void Reset() { }
    // Start is called before the first frame update
    private void Start() { }

    // Update is called once per frame
    private void Update() { }
    // LateUpdate is called every frame, if the Behaviour is enabled
    private void LateUpdate() { }
    // FixedUpdate is called every fixed framerate frame
    private void FixedUpdate() { }

    // This function is called when the object becomes enabled and active
    private void OnEnable() { }
    // This function is called when the behaviour becomes disabled
    private void OnDisable() { }

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnCollisionEnter(Collision collision) { }
    // OnTriggerStay is called once per frame for every Collider other that is touching the trigger
    private void OnCollisionStay(Collision collision) { }
    // OnTriggerExit is called when the Collider other has stopped touching the trigger
    private void OnCollisionExit(Collision collision) { }

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter2D(Collider2D collision) { }
    // OnTriggerStay is called once per frame for every Collider other that is touching the trigger
    private void OnTriggerStay2D(Collider2D collision) { }
    // OnTriggerExit is called when the Collider other has stopped touching the trigger
    private void OnTriggerExit2D(Collider2D collision) { }

    // This function is called when the script is loaded or a value is changed in the inspector (Called in the editor only)
    private void OnValidate() { }
    // OnDrawGizmos is called when the object is drawn in the scene
    private void OnDrawGizmos() { }
    // OnDrawGizmosSelected is called only if the object is selected
    private void OnDrawGizmosSelected() { }

    // Sent to all game objects when the player gets or loses focus
    private void OnApplicationFocus(bool focus) { }
    // Sent to all game objects before the application is quit
    private void OnApplicationQuit() { }
    #endregion

    #region Event Essential
    public UnityEvent onEvent = null;
    public UnityEvent<int> onEventInt = null;

    public UnityAction onAction = null;
    public UnityAction<int> onActionInt = null;
    #endregion

    #region Coroutine Essential
    // Coroutine Declaration
    private Coroutine _coroutine;
    // Start Coroutine
    private void StartCoroutineExample()
    {
        _coroutine = StartCoroutine(MyCoroutine());
    }
    // Stop Coroutine
    private void StopCoroutineExample()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
    // Coroutine Method
    private IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1f);
    }
    #endregion

    #region Essential for Unity
    // Instantiate a GameObject
    public GameObject InstantiateGameObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        return Instantiate(prefab, position, rotation);
    }

    // Destroy a GameObject
    public void DestroyGameObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    // Find a GameObject by name
    // Note: Expensive operation, avoid using it
    public GameObject FindGameObjectByName(string name)
    {
        return GameObject.Find(name);
    }

    // Exemple of FindObjectsOfType
    // Note: Expensive operation, avoid using it
    public void FindObjectsOfTypeExample()
    {
        // Find all objects of type Camera
        Camera[] cameras = FindObjectsOfType<Camera>();
    }

    // exemple of camera.main
    public void CameraMainExample()
    {
        // Get the main camera
        Camera mainCamera = Camera.main;
    }

    //exemple of getComponent
    public void GetComponentExample()
    {
        // Get the Transform component
        Transform transform = GetComponent<Transform>();
    }
    #endregion

}
