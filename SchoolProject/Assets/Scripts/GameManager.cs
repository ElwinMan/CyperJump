using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    public ClearCondition clearConditionScript;
    
    // Create a array for the questions to fill in, in the inspector.
    public Question[] questions;

    // Create a List for all the unanswered questions.
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private TMP_Text questionText;
    [SerializeField]
    private Text firstAnswer;
    [SerializeField]
    private Text secondAnswer;
    [SerializeField]
    private Text thirdAnswer;
    [SerializeField]
    private Text fourthAnswer;

    void Start() {
        // load all the questions into the unansweredQuestionsList for start of the game.
        if (unansweredQuestions == null || unansweredQuestions.Count == 0) {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
    }

    void SetCurrentQuestion() {
        // Choose a random question from the unansweredQuestion list.
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        // Change the UI text to the question and answers.
        questionText.text = currentQuestion.question;
        firstAnswer.text = currentQuestion.answerOne;
        secondAnswer.text = currentQuestion.answerTwo;
        thirdAnswer.text = currentQuestion.answerThree;
        fourthAnswer.text = currentQuestion.answerFour;

        // Remove the Question that got chosen from the unansweredQuestion list.
        unansweredQuestions.RemoveAt(randomQuestionIndex);
    }


    public void UserSelectOne() {
        if (currentQuestion.isOne) {
            Debug.Log("CORRECT");
            clearConditionScript.Correct();
        } else {
            Debug.Log("WRONG!");
        }
    }

    public void UserSelectTwo() {
        if (currentQuestion.isTwo) {
            Debug.Log("CORRECT");
            clearConditionScript.Correct();
        } else {
            Debug.Log("WRONG!");
        }
    }

    public void UserSelectThree() {
        if (currentQuestion.isThree) {
            Debug.Log("CORRECT");
            clearConditionScript.Correct();
        } else {
            Debug.Log("WRONG!");
        }
    }

    public void UserSelectFour() {
        if (currentQuestion.isFour) {
            Debug.Log("CORRECT");
            clearConditionScript.Correct();
        } else {
            Debug.Log("WRONG!");
        }
    }
}
