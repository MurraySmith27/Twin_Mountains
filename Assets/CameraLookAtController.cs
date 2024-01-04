using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtController : MonoBehaviour
{
    public Transform PlayerPos;

    public Transform characterPos;
    public Transform twinPeaksPos;
    public float characterToTwinPeaksStartZ = 0;
    public float TwinPeaksHoldTime = 5;
    public float TimeFromTwinPeaksToPlayer = 2;

    public bool IsTrackPlayerMode = true;

    [SerializeField] private bool InTwinPeaksTilt = false;
    private bool HasDoneTwinPeaksTilt = false;
    private bool StartTransitionBackToPlayer = false;
    private float CharacterToPeaksTransitionTime = 0;
    private float PeaksToCharacterTransitionTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = characterPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        float z = PlayerPos.position.z;
        if (z >= characterToTwinPeaksStartZ && !InTwinPeaksTilt && !HasDoneTwinPeaksTilt)
        {
            IsTrackPlayerMode = false;
            InTwinPeaksTilt = true;
            CharacterToPeaksTransitionTime = 0;
        }
        if (InTwinPeaksTilt)
        {
            CharacterToPeaksTransitionTime += Time.deltaTime / TwinPeaksHoldTime;
            if (CharacterToPeaksTransitionTime >= 1)
            {
                HasDoneTwinPeaksTilt = true;
                InTwinPeaksTilt = false;
                //transition back to player
                StartTransitionBackToPlayer = true;

            }
            else
            {
                gameObject.transform.position = Vector3.Lerp(characterPos.position, twinPeaksPos.position, Mathf.Min(CharacterToPeaksTransitionTime, 1));
            }
        }

    

        if (StartTransitionBackToPlayer && PeaksToCharacterTransitionTime < 1)
        {
            PeaksToCharacterTransitionTime += Time.deltaTime / TimeFromTwinPeaksToPlayer;
            Debug.Log($"lerping back to player. t: {PeaksToCharacterTransitionTime}");
            gameObject.transform.position = Vector3.Lerp(twinPeaksPos.position, characterPos.position, Mathf.Min(PeaksToCharacterTransitionTime, 1));
        }
        else if (PeaksToCharacterTransitionTime >= 1) 
        {
            StartTransitionBackToPlayer = false;
            IsTrackPlayerMode = true;
        }

        if (IsTrackPlayerMode)
        {
            gameObject.transform.position = PlayerPos.transform.position;
        }
    }
}
