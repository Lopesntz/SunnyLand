using UnityEngine;

public class PoçãoDevelocidade : MonoBehaviour
{
    private bool foiColetado = false;


    public ParticleSystem efeitoParticulas;

   
    public float aumentoDeVelocidade = 30f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (foiColetado) return;

        if (other.CompareTag("Player"))
        {
            foiColetado = true;

       
            PlayerMovement movimento = other.GetComponent<PlayerMovement>();
            if (movimento != null)
            {
                movimento.runSpeed += aumentoDeVelocidade;
                Debug.Log("Nova velocidade: " + movimento.runSpeed);
            }

 
            if (efeitoParticulas != null)
            {
                ParticleSystem particulas = Instantiate(efeitoParticulas, transform.position, Quaternion.identity);
                particulas.Play();
                Destroy(particulas.gameObject, particulas.main.duration);
            }

            Destroy(gameObject);
        }
    }
}
