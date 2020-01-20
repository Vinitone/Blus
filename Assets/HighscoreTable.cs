using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private void Start()
    {
        entryContainer = transform.Find("ScoreContainer");
        entryTemplate = entryContainer.Find("ScoreTemplate");

        entryTemplate.gameObject.SetActive(false);

        highScoreEntryList = new List<HighScoreEntry>
        {
            new HighScoreEntry
            {
                score = 123123,
                name = "VIN"
            }
        };

        highscoreEntryTransformList = new List<Transform>();

        foreach(HighScoreEntry entry in highScoreEntryList){
            CreateHighscoreEntryTransform(entry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateheigth = 30f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateheigth * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        entryTransform.Find("PosText").GetComponent<Text>().text = rank.ToString();

        //TODO real score passed here

        int score = highScoreEntry.score;

        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();

        //TODO pass name from input

        string name = highScoreEntry.name;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }
    private class HighScoreEntry
    {
        public int score;
        public string name;
    }
}


