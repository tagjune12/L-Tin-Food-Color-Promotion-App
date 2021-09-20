using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

[RequireComponent(typeof(ARPointCloudManager))]
public class PointCloudController : MonoBehaviour
{
    [Tooltip("The UI Text element used to display point cloud messages.")]
    [SerializeField]
    Text m_TogglePointCloudText;

    /// <summary>
    /// The UI Text element used to display plane detection messages.
    /// </summary>
    public Text togglePointCloudText
    {
        get { return m_TogglePointCloudText; }
        set { m_TogglePointCloudText = value; }
    }

    /// <summary>
    /// Toggles plane detection and the visualization of the planes.
    /// </summary>
    public void TogglePlaneDetection()
    {
        m_ARPointCloudManager.enabled = !m_ARPointCloudManager.enabled;

        string planeDetectionMessage = "";
        if (m_ARPointCloudManager.enabled)
        {
            planeDetectionMessage = "PointCloude 끄기";
            SetAllPlanesActive(true);
        }
        else
        {
            planeDetectionMessage = "PointCloude 켜기";
            SetAllPlanesActive(false);
        }

        if (togglePointCloudText != null)
            togglePointCloudText.text = planeDetectionMessage;
    }

    /// <summary>
    /// Iterates over all the existing planes and activates
    /// or deactivates their <c>GameObject</c>s'.
    /// </summary>
    /// <param name="value">Each planes' GameObject is SetActive with this value.</param>
    void SetAllPlanesActive(bool value)
    {
        foreach (var pointCloud in m_ARPointCloudManager.trackables)
            pointCloud.gameObject.SetActive(value);
    }



    void Awake()
    {
        m_ARPointCloudManager = GetComponent<ARPointCloudManager>();

    }

    ARPointCloudManager m_ARPointCloudManager;




}
