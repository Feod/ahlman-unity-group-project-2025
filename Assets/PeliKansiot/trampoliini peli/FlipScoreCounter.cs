using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlipScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Assign in Inspector
    public GameObject winMessage; // Assign in Inspector

    private int score = 0;
    private bool isAirborne = false;
    private float totalRotation = 0f;
    private float lastRotation;
    private bool flipCompleted = false;
    private int flipScore = 0;

    private Rigidbody2D rb;
    private const float rotationThreshold = 300f; // Degrees per point
    private const int winScore = 5; // Score needed to win
    private const float landingTolerance = 20f; // Stricter landing (±10°)
    private bool gameOver = false; // Track if game has ended

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScoreText();

        if (winMessage)
            winMessage.SetActive(false); // Hide win message at start
    }

    void Update()
    {
        if (gameOver || !isAirborne) return; // Stop updates if game is over or grounded

        float currentRotation = transform.eulerAngles.z;
        float rotationDifference = Mathf.DeltaAngle(lastRotation, currentRotation);
        totalRotation += rotationDifference;

        int newFlipScore = Mathf.FloorToInt(Mathf.Abs(totalRotation) / rotationThreshold);

        if (newFlipScore > flipScore) // Ensures each 330° flip counts once
        {
            flipScore = newFlipScore;
            flipCompleted = true;
            Debug.Log($"✅ Flip Counted: {flipScore} (Total Rotation: {totalRotation}°)");
        }

        lastRotation = currentRotation;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameOver) return; // Stop if game is over

        if (isAirborne)
        {
            if (IsLandedCorrectly())
            {
                // Always award 1 point for landing upright
                score += 1;

                // Add additional points for flips
                if (flipCompleted)
                {
                    PelisceneLogiikka.instance.PeliPaattyi(true);

                    score += flipScore;
                    Debug.Log($"🏆 Landed {flipScore * 330}°! Gained {flipScore} points! New Score: {score}");
                }

                UpdateScoreText();

                if (score >= winScore) // Check if player won
                {
                    WinGame();
                    return; // Stop further execution
                }
            }
            else
            {
                Debug.Log("❌ Flip NOT counted - Bad Landing!");
            }
        }

        // Reset tracking after landing
        ResetFlipTracking();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (gameOver || isAirborne) return; // Prevent resetting mid-air

        isAirborne = true;
        lastRotation = transform.eulerAngles.z;
        totalRotation = 0f; // Reset total rotation only when leaving the ground
        flipScore = 0;
        flipCompleted = false;
        Debug.Log("🚀 Took Off - Flip Tracking Started!");
    }

    bool IsLandedCorrectly()
    {
        float zRotation = transform.eulerAngles.z;
        float angleToUpright = Mathf.Abs(Mathf.DeltaAngle(zRotation, 0f));
        bool landedCorrectly = angleToUpright <= landingTolerance;

        Debug.Log(landedCorrectly ? "✅ Proper Landing!" : "❌ Bad Landing!");
        return landedCorrectly;
    }

    void UpdateScoreText()
    {
        if (scoreText)
        {
            scoreText.text = "Score: " + score;
            scoreText.ForceMeshUpdate();
        }
        else
        {
            Debug.LogError("⚠️ scoreText is NOT assigned in the Inspector!");
        }
    }

    void ResetFlipTracking()
    {
        flipCompleted = false;
        totalRotation = 0f;
        isAirborne = false;
        flipScore = 0;
        Debug.Log("🔄 Flip Tracking Reset!");
    }

    void WinGame()
    {
        Debug.Log("🎉 YOU WIN! GAME OVER! 🎉");

        if (winMessage)
        {
            winMessage.SetActive(true); // Show "You Win!" message
        }

        gameOver = true; // Mark game as over
        Time.timeScale = 0; // Completely stop game physics & movement
    }
}
