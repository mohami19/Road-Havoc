using TMPro;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas gameCanvas;
    [SerializeField] private float destroyPlyerDelay = 0.6f;
    
    [Header("Hit Effect")]
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] private float sparklingEffectTime = 4f;
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
            Invoke("GameOver",destroyPlyerDelay);
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
        if (other.CompareTag("Award")) {
            string score = Mathf.RoundToInt(GetComponent<PlayerManage>().Score).ToString();
            if (int.TryParse(score, out int scoreInt)) {
                GetComponent<PlayerManage>().Score = scoreInt +2;
                int gemNum = int.Parse(FindObjectOfType<MoneyManagement>().Gems) + 1;
                FindObjectOfType<MoneyManagement>().Gems = gemNum.ToString();
            }
            other.gameObject.SetActive(false);
        }
        playerHealth = gameObject.GetComponent<PlayerManage>().Health;
        if (other.tag == "Obstacle" && gotHit){
            playerHealth -= 1;
            Handheld.Vibrate();
            gotHit = false;
            Invoke("GotHit",sparklingEffectTime);
            hitEffect.Play();
            other.gameObject.SetActive(false);
        } else if (other.tag == "Obstacle") {
            hitEffect.Play();
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

    void GameOver(){
        gameOverCanvas.gameObject.SetActive(true);
        gameCanvas.gameObject.SetActive(false);
        Time.timeScale = 0;
        gameObject.SetActive(false);

        //SceneManager.LoadScene(0);
    }
}
