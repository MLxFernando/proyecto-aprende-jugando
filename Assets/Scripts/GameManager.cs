using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject[] gamePanels; // Paneles del juego
    public TMP_Text[] questionTexts; // Un TMP_Text para cada panel
    public TMP_Text[] feedbackTexts; // Un TMP_Text para feedback en cada panel

    private Button[] answerButtons; // Botones de respuesta en cada panel
    private int currentPanelIndex = 0;
    private int currentQuestionIndex = 0;

    private Question[] questions;

    void Start()
    {
        LoadQuestions();
        SetupCurrentPanel();
    }

    void LoadQuestions()
    {
        questions = new Question[]
        {
            new Question("¿Cuántas naranjas hay?", new string[] {"2", "4", "3"}, 2),
            new Question("¿Cuántas manzanas hay?", new string[] {"1", "4", "3"}, 0),
            new Question("¿Cuántas fresas hay?", new string[] {"5", "2", "3"}, 1),
            new Question("¿Cuántas peras hay?", new string[] {"2", "4", "1"}, 2)
        };
    }

    void SetupCurrentPanel()
    {
        // Desactiva todos los paneles y activa solo el actual
        for (int i = 0; i < gamePanels.Length; i++)
        {
            gamePanels[i].SetActive(i == currentPanelIndex);
        }

        // Busca los botones en el panel actual
        answerButtons = gamePanels[currentPanelIndex].GetComponentsInChildren<Button>();

        ShowQuestion();
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            Question currentQuestion = questions[currentQuestionIndex];

            // Asegurar que cada panel muestre su propia pregunta
            questionTexts[currentPanelIndex].text = currentQuestion.text;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (i < currentQuestion.answers.Length) 
                {
                    answerButtons[i].GetComponentInChildren<TMP_Text>().text = currentQuestion.answers[i];

                    int index = i;
                    answerButtons[i].onClick.RemoveAllListeners();
                    answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
                }
            }

            // Ocultar mensaje de error del panel actual
            feedbackTexts[currentPanelIndex].text = "";
            feedbackTexts[currentPanelIndex].gameObject.SetActive(false);
        }
    }

    void CheckAnswer(int selectedIndex)
    {
        if (selectedIndex == questions[currentQuestionIndex].correctAnswer)
        {
            Debug.Log("¡Respuesta correcta!");
            feedbackTexts[currentPanelIndex].text = "¡Correcto!";
            feedbackTexts[currentPanelIndex].color = Color.green;
            feedbackTexts[currentPanelIndex].gameObject.SetActive(true);

            currentQuestionIndex++;

            if (currentQuestionIndex < questions.Length)
            {
                Invoke("ShowQuestion", 1.5f);
            }
            else
            {
                MoveToNextPanel();
            }
        }
        else
        {
            Debug.Log("Respuesta incorrecta.");
            feedbackTexts[currentPanelIndex].text = "Respuesta incorrecta, intenta de nuevo.";
            feedbackTexts[currentPanelIndex].color = Color.red;
            feedbackTexts[currentPanelIndex].gameObject.SetActive(true);
        }
    }

    void MoveToNextPanel()
    {
        if (currentPanelIndex < gamePanels.Length - 1)
        {
            currentPanelIndex++;
            currentQuestionIndex = 0;
            SetupCurrentPanel();
        }
        else
        {
            Debug.Log("¡Juego terminado!");
            feedbackTexts[currentPanelIndex].text = "¡Felicidades, terminaste el juego!";
            feedbackTexts[currentPanelIndex].color = Color.blue;
            feedbackTexts[currentPanelIndex].gameObject.SetActive(true);
        }
    }
}

public class Question
{
    public string text;
    public string[] answers;
    public int correctAnswer;

    public Question(string text, string[] answers, int correctAnswer)
    {
        this.text = text;
        this.answers = answers;
        this.correctAnswer = correctAnswer;
    }
}
