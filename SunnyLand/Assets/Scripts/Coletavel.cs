        using UnityEngine;

        public class Coletavel : MonoBehaviour
        {
            private bool foiColetado = false;

     
            public ParticleSystem efeitoParticulas;

            void OnTriggerEnter2D(Collider2D other)
            {
                if (foiColetado) return;  

                if (other.CompareTag("Player"))
                {
                    foiColetado = true;  

        
                    GameManager gm = FindObjectOfType<GameManager>();
                    if (gm != null)
                    {
                        gm.AddPoints(1);
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
