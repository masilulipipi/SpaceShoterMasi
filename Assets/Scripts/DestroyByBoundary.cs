using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    /* ontriggerenter cuando OTRO entra en contacto
     * ontrigerstay cuando un collider permanece en contacto
     * on trigger exit cuando un colider deja de estar en contacto
     */


    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
