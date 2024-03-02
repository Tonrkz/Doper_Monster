using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class PlayerUpgrade : MonoBehaviour {

    [SerializeField] GameObject upgradePanel;
    [SerializeField] Button upgrade1;
    [SerializeField] TMP_Text upgrade1Name;
    [SerializeField] TMP_Text upgrade1Effect;
    [SerializeField] Button upgrade2;
    [SerializeField] TMP_Text upgrade2Name;
    [SerializeField] TMP_Text upgrade2Effect;
    [SerializeField] Button upgrade3;
    [SerializeField] TMP_Text upgrade3Name;
    [SerializeField] TMP_Text upgrade3Effect;

    public int scoreRequired = 77;
    public int diff = 77;

    void Start() {
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update() {
        if (PlayerManager.instance.Score >= (scoreRequired)) {
            PlayerManager.instance.Level++;
            RandomUpgrade();
            upgradePanel.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Level Up");
            if (PlayerManager.instance.Level % 2 == 0) {
                PlayerManager.instance.CurrentTier++;
                Debug.Log("Tier Up");
                if (PlayerManager.instance.CurrentTier > 4) {
                    PlayerManager.instance.CurrentTier = 4;
                    Debug.Log("Max Tier");
                }
            }
        }
    }

    void RemoveAllListenerFromAllButton() {
        upgrade1.onClick.RemoveAllListeners();
        upgrade2.onClick.RemoveAllListeners();
        upgrade3.onClick.RemoveAllListeners();
    }

    void RandomUpgrade() {
        diff = (int)(diff * 1.05);
        scoreRequired += diff;
        int firstUpgrade;
        int secondUpgrade;
        int thirdUpgrade;
        switch (PlayerManager.instance.CurrentTier) {
            case 1:
                firstUpgrade = 1;
                secondUpgrade = 2;
                thirdUpgrade = 3;
                AssignUpgradeToList(firstUpgrade, secondUpgrade, thirdUpgrade);
                break;

            case 2:
                firstUpgrade = 0;
                secondUpgrade = 0;
                thirdUpgrade = 0;
                while (firstUpgrade == secondUpgrade || firstUpgrade == thirdUpgrade || secondUpgrade == thirdUpgrade) {
                    firstUpgrade = Random.Range(1, 100);
                    if (firstUpgrade <= 70) {
                        firstUpgrade = Random.Range(1, 4);
                    }
                    else {
                        firstUpgrade = Random.Range(4, 8);
                    }

                    secondUpgrade = Random.Range(1, 100);
                    if (secondUpgrade <= 70) {
                        secondUpgrade = Random.Range(1, 4);
                    }
                    else {
                        secondUpgrade = Random.Range(4, 8);
                    }

                    thirdUpgrade = Random.Range(1, 100);
                    if (thirdUpgrade <= 70) {
                        thirdUpgrade = Random.Range(1, 4);
                    }
                    else {
                        thirdUpgrade = Random.Range(4, 8);
                    }
                }
                AssignUpgradeToList(firstUpgrade, secondUpgrade, thirdUpgrade);
                break;

            case 3:
                firstUpgrade = 0;
                secondUpgrade = 0;
                thirdUpgrade = 0;
                while (firstUpgrade == secondUpgrade || firstUpgrade == thirdUpgrade || secondUpgrade == thirdUpgrade) {
                    firstUpgrade = Random.Range(1, 100);
                    if (firstUpgrade <= 50) {
                        firstUpgrade = Random.Range(1, 4);
                    }
                    else if (firstUpgrade > 50 && firstUpgrade <= 80) {
                        firstUpgrade = Random.Range(4, 8);
                    }
                    else {
                        firstUpgrade = Random.Range(8, 13);
                    }
                    secondUpgrade = Random.Range(1, 100);
                    if (secondUpgrade <= 50) {
                        secondUpgrade = Random.Range(1, 4);
                    }
                    else if (secondUpgrade > 50 && secondUpgrade <= 80) {
                        secondUpgrade = Random.Range(4, 8);
                    }
                    else {
                        secondUpgrade = Random.Range(8, 13);
                    }
                    thirdUpgrade = Random.Range(1, 100);
                    if (thirdUpgrade <= 50) {
                        thirdUpgrade = Random.Range(1, 4);
                    }
                    else if (thirdUpgrade > 50 && thirdUpgrade <= 80) {
                        thirdUpgrade = Random.Range(4, 8);
                    }
                    else {
                        thirdUpgrade = Random.Range(8, 13);
                    }
                }
                AssignUpgradeToList(firstUpgrade, secondUpgrade, thirdUpgrade);
                break;

            case 4:
                firstUpgrade = 0;
                secondUpgrade = 0;
                thirdUpgrade = 0;
                while (firstUpgrade == secondUpgrade || firstUpgrade == thirdUpgrade || secondUpgrade == thirdUpgrade) {
                    firstUpgrade = Random.Range(1, 100);
                    if (firstUpgrade <= 40) {
                        firstUpgrade = Random.Range(1, 4);
                    }
                    else if (firstUpgrade > 40 && firstUpgrade <= 70) {
                        firstUpgrade = Random.Range(4, 8);
                    }
                    else if (firstUpgrade > 70 && firstUpgrade <= 90) {
                        firstUpgrade = Random.Range(8, 13);
                    }
                    else {
                        firstUpgrade = Random.Range(13, 17);
                    }
                    secondUpgrade = Random.Range(1, 100);
                    if (secondUpgrade <= 40) {
                        secondUpgrade = Random.Range(1, 4);
                    }
                    else if (secondUpgrade > 40 && secondUpgrade <= 70) {
                        secondUpgrade = Random.Range(4, 8);
                    }
                    else if (secondUpgrade > 70 && secondUpgrade <= 90) {
                        secondUpgrade = Random.Range(8, 13);
                    }
                    else {
                        secondUpgrade = Random.Range(13, 17);
                    }
                    thirdUpgrade = Random.Range(1, 100);
                    if (thirdUpgrade <= 40) {
                        thirdUpgrade = Random.Range(1, 4);
                    }
                    else if (thirdUpgrade > 40 && thirdUpgrade <= 70) {
                        thirdUpgrade = Random.Range(4, 8);
                    }
                    else if (thirdUpgrade > 70 && thirdUpgrade <= 90) {
                        thirdUpgrade = Random.Range(8, 13);
                    }
                    else {
                        thirdUpgrade = Random.Range(13, 17);
                    }
                }
                AssignUpgradeToList(firstUpgrade, secondUpgrade, thirdUpgrade);
                break;

            default:
                firstUpgrade = 1;
                secondUpgrade = 2;
                thirdUpgrade = 3;
                AssignUpgradeToList(firstUpgrade, secondUpgrade, thirdUpgrade);
                break;
        }
    }

    void AssignUpgradeToList(int first, int second, int third) {
        switch (first) {
            case 1:
                upgrade1.onClick.AddListener(TierIUpgrade01);
                upgrade1Name.text = "Speedy";
                upgrade1Effect.text = "+1 Max Speed, -3 Max Sanity";
                break;
            case 2:
                upgrade1.onClick.AddListener(TierIUpgrade02);
                upgrade1Name.text = "Healthy";
                upgrade1Effect.text = "+3 Max Sanity, -1 Max Speed";
                break;
            case 3:
                upgrade1.onClick.AddListener(TierIUpgrade03);
                upgrade1Name.text = "Sugar Dope";
                upgrade1Effect.text = "+15% Sanity From Max Sanity";
                break;
            case 4:
                upgrade1.onClick.AddListener(TierIIUpgrade01);
                upgrade1Name.text = "Sugar Chunk";
                upgrade1Effect.text = "+30% Sanity From Max Sanity";
                break;
            case 5:
                upgrade1.onClick.AddListener(TierIIUpgrade02);
                upgrade1Name.text = "Speedy II";
                upgrade1Effect.text = "+1 Max Speed";
                break;
            case 6:
                upgrade1.onClick.AddListener(TierIIUpgrade03);
                upgrade1Name.text = "Healthy II";
                upgrade1Effect.text = "+5 Max Sanity, -1 Max Speed";
                break;
            case 7:
                upgrade1.onClick.AddListener(TierIIUpgrade04);
                upgrade1Name.text = "Better Sugar";
                upgrade1Effect.text = "+1 Base Candy Point";
                break;
            case 8:
                upgrade1.onClick.AddListener(TierIIIUpgrade01);
                upgrade1Name.text = "Speedy III";
                upgrade1Effect.text = "+2 Max Speed, -5 Max Sanity";
                break;
            case 9:
                upgrade1.onClick.AddListener(TierIIIUpgrade02);
                upgrade1Name.text = "Healthy III";
                upgrade1Effect.text = "+8 Max Sanity, -2 Max Speed";
                break;
            case 10:
                upgrade1.onClick.AddListener(TierIIIUpgrade03);
                upgrade1Name.text = "Preservatives On Top";
                upgrade1Effect.text = "+0.1s Min/Max Expire Time";
                break;
            case 11:
                upgrade1.onClick.AddListener(TierIIIUpgrade04);
                upgrade1Name.text = "Best Sugar";
                upgrade1Effect.text = "+2 Base Candy Point";
                break;
            case 12:
                upgrade1.onClick.AddListener(TierIIIUpgrade05);
                upgrade1Name.text = "Grow";
                upgrade1Effect.text = "Ignore Rock, +Size, -1 Max Speed";
                break;
            case 13:
                upgrade1.onClick.AddListener(TierIVUpgrade01);
                upgrade1Name.text = "Speedy IV";
                upgrade1Effect.text = "+3 Max Speed, -6 Max Sanity";
                break;
            case 14:
                upgrade1.onClick.AddListener(TierIVUpgrade02);
                upgrade1Name.text = "Careful";
                upgrade1Effect.text = "Ignore Slow, -5 Max Speed";
                break;
            case 15:
                upgrade1.onClick.AddListener(TierIVUpgrade03);
                upgrade1Name.text = "More Preservatives On Top";
                upgrade1Effect.text = "+0.2s Min/Max Expire Time";
                break;
            case 16:
                upgrade1.onClick.AddListener(TierIVUpgrade04);
                upgrade1Name.text = "Big Guy";
                upgrade1Effect.text = "Ignore Soft Wall, ++Size, -3 Max Speed";
                break;
            default:
                upgrade1.onClick.AddListener(TierIUpgrade01);
                upgrade1Name.text = "Speedy";
                upgrade1Effect.text = "+1 Max Speed, -3 Max Sanity";
                break;
        }

        switch (second) {
            case 1:
                upgrade2.onClick.AddListener(TierIUpgrade01);
                upgrade2Name.text = "Speedy";
                upgrade2Effect.text = "+1 Max Speed, -3 Max Sanity";
                break;
            case 2:
                upgrade2.onClick.AddListener(TierIUpgrade02);
                upgrade2Name.text = "Healthy";
                upgrade2Effect.text = "+3 Max Sanity, -1 Max Speed";
                break;
            case 3:
                upgrade2.onClick.AddListener(TierIUpgrade03);
                upgrade2Name.text = "Sugar Dope";
                upgrade2Effect.text = "+15% Sanity From Max Sanity";
                break;
            case 4:
                upgrade2.onClick.AddListener(TierIIUpgrade01);
                upgrade2Name.text = "Sugar Chunk";
                upgrade2Effect.text = "+30% Sanity From Max Sanity";
                break;
            case 5:
                upgrade2.onClick.AddListener(TierIIUpgrade02);
                upgrade2Name.text = "Speedy II";
                upgrade2Effect.text = "+1 Max Speed";
                break;
            case 6:
                upgrade2.onClick.AddListener(TierIIUpgrade03);
                upgrade2Name.text = "Healthy II";
                upgrade2Effect.text = "+5 Max Sanity, -1 Max Speed";
                break;
            case 7:
                upgrade2.onClick.AddListener(TierIIUpgrade04);
                upgrade2Name.text = "Better Sugar";
                upgrade2Effect.text = "+1 Base Candy Point";
                break;
            case 8:
                upgrade2.onClick.AddListener(TierIIIUpgrade01);
                upgrade2Name.text = "Speedy III";
                upgrade2Effect.text = "+2 Max Speed, -5 Max Sanity";
                break;
            case 9:
                upgrade2.onClick.AddListener(TierIIIUpgrade02);
                upgrade2Name.text = "Healthy III";
                upgrade2Effect.text = "+8 Max Sanity, -2 Max Speed";
                break;
            case 10:
                upgrade2.onClick.AddListener(TierIIIUpgrade03);
                upgrade2Name.text = "Sugar Rush";
                upgrade2Effect.text = "+0.1s Min/Max Expire Time";
                break;
            case 11:
                upgrade2.onClick.AddListener(TierIIIUpgrade04);
                upgrade2Name.text = "Best Sugar";
                upgrade2Effect.text = "+2 Base Candy Point";
                break;
            case 12:
                upgrade2.onClick.AddListener(TierIIIUpgrade05);
                upgrade2Name.text = "Grow";
                upgrade2Effect.text = "Ignore Rock, +Size, -Max Speed";
                break;
            case 13:
                upgrade2.onClick.AddListener(TierIVUpgrade01);
                upgrade2Name.text = "Speedy IV";
                upgrade2Effect.text = "+3 Max Speed, -6 Max Sanity";
                break;
            case 14:
                upgrade2.onClick.AddListener(TierIVUpgrade02);
                upgrade2Name.text = "Careful";
                upgrade2Effect.text = "Ignore Slow, -Max Speed";
                break;
            case 15:
                upgrade2.onClick.AddListener(TierIVUpgrade03);
                upgrade2Name.text = "More Preservatives On Top";
                upgrade2Effect.text = "+0.2s Min/Max Expire Time";
                break;
            case 16:
                upgrade2.onClick.AddListener(TierIVUpgrade04);
                upgrade2Name.text = "Big Guy";
                upgrade2Effect.text = "Ignore Soft Wall, +Size, -Max Speed";
                break;
            default:
                upgrade2.onClick.AddListener(TierIUpgrade02);
                upgrade2Name.text = "Healthy";
                upgrade2Effect.text = "+3 Max Sanity, -1 Max Speed";
                break;
        }

        switch (third) {
            case 1:
                upgrade3.onClick.AddListener(TierIUpgrade01);
                upgrade3Name.text = "Speedy";
                upgrade3Effect.text = "+1 Max Speed, -3 Max Sanity";
                break;
            case 2:
                upgrade3.onClick.AddListener(TierIUpgrade02);
                upgrade3Name.text = "Healthy";
                upgrade3Effect.text = "+3 Max Sanity, -1 Max Speed";
                break;
            case 3:
                upgrade3.onClick.AddListener(TierIUpgrade03);
                upgrade3Name.text = "Sugar Dope";
                upgrade3Effect.text = "+15% Sanity From Max Sanity";
                break;
            case 4:
                upgrade3.onClick.AddListener(TierIIUpgrade01);
                upgrade3Name.text = "Sugar Chunk";
                upgrade3Effect.text = "+30% Sanity From Max Sanity";
                break;
            case 5:
                upgrade3.onClick.AddListener(TierIIUpgrade02);
                upgrade3Name.text = "Speedy II";
                upgrade3Effect.text = "+1 Max Speed";
                break;
            case 6:
                upgrade3.onClick.AddListener(TierIIUpgrade03);
                upgrade3Name.text = "Healthy II";
                upgrade3Effect.text = "+5 Max Sanity, -1 Max Speed";
                break;
            case 7:
                upgrade3.onClick.AddListener(TierIIUpgrade04);
                upgrade3Name.text = "Better Sugar";
                upgrade3Effect.text = "+1 Base Candy Point";
                break;
            case 8:
                upgrade3.onClick.AddListener(TierIIIUpgrade01);
                upgrade3Name.text = "Speedy III";
                upgrade3Effect.text = "+2 Max Speed, -5 Max Sanity";
                break;
            case 9:
                upgrade3.onClick.AddListener(TierIIIUpgrade02);
                upgrade3Name.text = "Healthy III";
                upgrade3Effect.text = "+8 Max Sanity, -2 Max Speed";
                break;
            case 10:
                upgrade3.onClick.AddListener(TierIIIUpgrade03);
                upgrade3Name.text = "Preservatives On Top";
                upgrade3Effect.text = "+0.1s Min/Max Expire Time";
                break;
            case 11:
                upgrade3.onClick.AddListener(TierIIIUpgrade04);
                upgrade3Name.text = "Best Sugar";
                upgrade3Effect.text = "+2 Base Candy Point";
                break;
            case 12:
                upgrade3.onClick.AddListener(TierIIIUpgrade05);
                upgrade3Name.text = "Grow";
                upgrade3Effect.text = "Ignore Rock, +Size, -Max Speed";
                break;
            case 13:
                upgrade3.onClick.AddListener(TierIVUpgrade01);
                upgrade3Name.text = "Speedy IV";
                upgrade3Effect.text = "+3 Max Speed, -6 Max Sanity";
                break;
            case 14:
                upgrade3.onClick.AddListener(TierIVUpgrade02);
                upgrade3Name.text = "Careful";
                upgrade3Effect.text = "Ignore Slow, -Max Speed";
                break;
            case 15:
                upgrade3.onClick.AddListener(TierIVUpgrade03);
                upgrade3Name.text = "More Preservatives On Top";
                upgrade3Effect.text = "+0.2s Min/Max Expire Time";
                break;
            case 16:
                upgrade3.onClick.AddListener(TierIVUpgrade04);
                upgrade3Name.text = "Big Guy";
                upgrade3Effect.text = "Ignore Soft Wall, +Size, -Max Speed";
                break;
            default:
                upgrade3.onClick.AddListener(TierIUpgrade03);
                upgrade3Name.text = "Sugar Dope";
                upgrade3Effect.text = "+15% Sanity From Max Sanity";
                break;
        }
    }

    public void TierIUpgrade01() {
        //+maxSpeed, -maxSanity (Tier 1)
        PlayerMovement.instance.MaxMoveSpeed += 1;
        PlayerManager.instance.MaxSanity -= 3;
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }

    public void TierIUpgrade02() {
        //+maxSanity, -maxSpeed (Tier 1)
        PlayerManager.instance.MaxSanity += 3;
        PlayerMovement.instance.MaxMoveSpeed -= 1;
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }

    public void TierIUpgrade03() {
        //+sanity (Tier 1)
        PlayerManager.instance.Sanity += (int)(PlayerManager.instance.MaxSanity * 0.15);
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }

    public void TierIIUpgrade01() {
        //++sanity (Tier 2)
        PlayerManager.instance.Sanity += (int)(PlayerManager.instance.MaxSanity * 0.3);
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }

    public void TierIIUpgrade02() {
        //+maxSpeed (Tier 2)
        PlayerMovement.instance.MaxMoveSpeed += 1;
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }

    public void TierIIUpgrade03() {
        //++maxSanity, -maxSpeed (Tier 2)
        PlayerManager.instance.MaxSanity += 5;
        PlayerMovement.instance.MaxMoveSpeed -= 1;
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }

    public void TierIIUpgrade04() {
        //+candyPoint (Tier 2)
        DessertSpawner.instance.DessertBasePoint += 1;
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }

    public void TierIIIUpgrade01() {
        //++maxSpeed, -maxSanity (Tier 3)
        PlayerMovement.instance.MaxMoveSpeed += 2;
        PlayerManager.instance.MaxSanity -= 5;
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }

    public void TierIIIUpgrade02() {
        //+++maxSanity, --maxSpeed (Tier 3)
        PlayerManager.instance.MaxSanity += 8;
        PlayerMovement.instance.MaxMoveSpeed -= 2;
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }

    public void TierIIIUpgrade03() {
        //+expireTime
        DessertSpawner.instance.MinExpireTime += 0.1f;
        DessertSpawner.instance.MaxExpireTime += 0.1f;
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }

    public void TierIIIUpgrade04() {
        //++candyPoint
        DessertSpawner.instance.DessertBasePoint += 2;
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }

    public void TierIIIUpgrade05() {
        //Ignore rock, +Size, -maxSpeed (Tier 3)
        foreach (var item in PlayerManager.instance.obstacleList) {
            if (item.tag == "Rock") {
                Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), item.GetComponent<BoxCollider2D>(), true);
            }
        }
        if (transform.localScale.x <= 0.13f) {
            transform.localScale = new Vector3(0.13f, 0.13f, 0.13f);
        }
        PlayerMovement.instance.MaxMoveSpeed -= 1;
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }

    public void TierIVUpgrade01() {
        //+++maxSpeed, --maxSanity (Tier 4)
        PlayerMovement.instance.MaxMoveSpeed += 3;
        PlayerManager.instance.MaxSanity -= 6;
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }

    public void TierIVUpgrade02() {
        //Ignore slow, -maxSpeed (Tier 4)
        foreach (var item in PlayerManager.instance.obstacleList) {
            if (item.tag == "SlowFloor") {
                Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), item.GetComponent<BoxCollider2D>(), true);
            }
        }
        PlayerMovement.instance.MaxMoveSpeed -= 5;
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }

    public void TierIVUpgrade03() {
        //++expireTime (Tier 4)
        DessertSpawner.instance.MinExpireTime += 0.2f;
        DessertSpawner.instance.MaxExpireTime += 0.2f;
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }

    public void TierIVUpgrade04() {
        //Ignore softWall, ++Size, --maxSpeed (Tier 4)
        foreach (var item in PlayerManager.instance.obstacleList) {
            if (item.tag == "SoftWall") {
                Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), item.GetComponent<BoxCollider2D>(), true);
            }
        }
        if (transform.localScale.x < 0.16f) {
            transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
        }
        PlayerMovement.instance.MaxMoveSpeed -= 3;
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        RemoveAllListenerFromAllButton();
    }
}
