using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
  [SerializeField]
  private TextMeshPro texthp;
  [SerializeField]
  private float blockHP = 99;
  [SerializeField]
  private float fallingSpeed = 120.0f;
  private float timer;

  public  AudioSource aus;
  public AudioClip blockBreak;
  public AudioClip damege;

  public GameObject particleSystem;

  [SerializeField]
  public Text showScore;
  [SerializeField]
  public Text showHighScore;
  public int score;
  public int highScore;

    // Start is called before the first frame update
    void Start()
    {
        texthp.text = blockHP.ToString();
        timer = fallingSpeed;
        highScore = PlayerPrefs.GetInt("HighScore");
        showHighScore.text = "HighScore: " + highScore.ToString();
        PlayerPrefs.DeleteKey("Score");
    }
    // Update is called once per frame
    void Update()
    {
        // moi 3s khoi block se dich chuyen xuong 1 Languages
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
          gameObject.transform.position =
          new Vector2(gameObject.transform.position.x,
          gameObject.transform.position.y - 2f);
            timer = fallingSpeed;
        }
    }
    public void OnDameged(float damage)
    {
      if(blockHP > 0){
        //hp cua block se bi giam bang luong damge cua destination
        blockHP -= damage;
      if(aus && damege)
        {
           aus.PlayOneShot(damege);
        }
        // cap nhat lai hien thi cua hp tren BlockingObjects
       texthp.text = blockHP.ToString();
      }
      // neu HP nho hon hoac bang 0 block se bi destroy
      if(blockHP <= 0)
      {
        Destroy(gameObject);
        addScore();
        UpdateScore();
        // tao hieu ung cho khoi block
        GameObject explosive = Instantiate(particleSystem,transform.position,transform.rotation);
        particleSystem.SetActive(true);
        //hieu ung huy sau 2 giay
        Destroy(explosive,2);
        if(aus && blockBreak)
        {
           aus.PlayOneShot(blockBreak);
        }
        BlockController.instance.blockCount -= 1;

        if(BlockController.instance.blockCount <= 0)
        {
          BlockController.instance.ActiveWinPopUp();
        }
        }
    }
    public void addScore()
    {
      // score++;
      // score = PlayerPrefs.GetInt("HighScore") +1;
      score++;
      score = PlayerPrefs.GetInt("Score") +1;
    }

    public void UpdateScore()
      {
        PlayerPrefs.SetInt ("Score", score);
        PlayerPrefs.Save();
        if (score > highScore)
        {
          highScore = score;
         PlayerPrefs.SetInt ("HighScore", highScore);
         PlayerPrefs.Save();
       }
        showScore.text = "Score: " + score.ToString();
        showHighScore.text = "HighScore: " + highScore.ToString();
      }
  }
