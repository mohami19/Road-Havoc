using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    [SerializeField] private float destroyPlyerDelay = 0.6f;
    [SerializeField] private ParticleSystem hitEffect;

    private float sparklingEffect = 4f;

    [SerializeField] private float alphaChangeSpeed = 2f;
    private bool gotHit = true;
    private int playerHealth;
    private SpriteRenderer spriteRenderer;
    private float alphaTimer;

    private void Start() {
        playerHealth = gameObject.GetComponent<PlayerManage>().Health;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        alphaTimer = 0f;
    }

    private void Update() {
        if (playerHealth < 1) {
            hitEffect.Play();
            Invoke("DestroyPlayer",destroyPlyerDelay);
        }
        if (!gotHit)
        {
            alphaTimer += Time.deltaTime * alphaChangeSpeed;
            Color tmp = spriteRenderer.color;
            tmp.a = 0.65f + 0.35f * Mathf.Sin(alphaTimer);
            spriteRenderer.color = tmp;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        playerHealth = gameObject.GetComponent<PlayerManage>().Health;
        if (other.tag == "Obstacle" && gotHit){
            playerHealth -= 1;
            gotHit = false;
            Invoke("GotHit",sparklingEffect);
            other.gameObject.SetActive(false);
        } else if (other.tag == "Obstacle") {
            other.gameObject.SetActive(false);
        }
        gameObject.GetComponent<PlayerManage>().Health = playerHealth;
    }

    void GotHit() {
        gotHit = true;
        Color tmp = spriteRenderer.color;
        tmp.a = 1f;
        spriteRenderer.color = tmp;
        alphaTimer = 0f;
    }

    void DestroyPlayer(){
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
