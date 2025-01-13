using UnityEngine;

public class CarCondition : MonoBehaviour
{

    private Car currentCar;
    public float condition = 100f; // Başlangıçta %100

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 5f) // Çarpışma şiddeti
        {
            float damage = collision.relativeVelocity.magnitude * 2f; // Hasar hesaplama
            condition -= damage;
            condition = Mathf.Clamp(condition, 0f, 100f); // Kondisyon sınırlarını koru
            currentCar.condition = condition; 
        }
    }
}