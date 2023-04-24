using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    [SerializeField] Animator myAnimator;
    [SerializeField] bool isCrashTheCar, isStopTheCar, isFinishTheRace;

    [SerializeField] GameObject cleanCar, shatteredCar;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            myAnimator.SetBool("grabbed", true);
            gameObject.SetActive(false);

            NanoGameManager.playerWon = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        float radius = 5f, force = 7000f;

        if (other.tag == "Enemy" && isCrashTheCar && NanoGameManager.gameHasStarted && !NanoGameManager.playerWon && !NanoGameManager.playerLost)
        {
            shatteredCar.transform.localPosition = cleanCar.transform.localPosition;
            shatteredCar.SetActive(true);

            Collider[] colliders = Physics.OverlapSphere(transform.position, 5);
            foreach (Collider nearbyObject in colliders)
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null && nearbyObject.tag != "Enemy")
                    rb.AddExplosionForce(force, transform.position, radius);
            }

            NanoGameManager.playerWon = true;
            cleanCar.SetActive(false);
        }
        else if (other.tag == "Enemy" && isStopTheCar && NanoGameManager.gameHasStarted && !NanoGameManager.playerWon && !NanoGameManager.playerLost)
        {
            shatteredCar.transform.localPosition = cleanCar.transform.localPosition;
            shatteredCar.SetActive(true);

            Collider[] colliders = Physics.OverlapSphere(transform.position, 5);
            foreach (Collider nearbyObject in colliders)
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null && nearbyObject.tag != "Enemy")
                    rb.AddExplosionForce(force, transform.position, radius);
            }

            NanoGameManager.playerLost = true;

            cleanCar.SetActive(false);
        }
        else if (other.tag == "FinishLine" && isFinishTheRace && NanoGameManager.gameHasStarted && !NanoGameManager.playerWon && !NanoGameManager.playerLost)
        {
            NanoGameManager.playerWon = true;
        }
    }

}
