using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour//elegxei olo to dialogue, apo to na ton ksekinshei, na typwsei tis protaseis kai nt ton kleisei
{
    public bool chief = false;
    public bool endeddial=false;
    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI dialogueText;
    public GameObject boss;
    public Animator animator;
    public GameObject arrow;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        endeddial = false;
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartDialogue(Dialogue dialogue)//arzxizei to dialogue
    {
        arrow.SetActive(false);
        animator.SetBool("IsOpen", true);//anoigei to dialogue box na fainetai sthn othoni

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);//pernaei tis protaseis sto queue sentences
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()//pernaeimia mia tis protaseis sto typesentences gia ektypwsh
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }
    IEnumerator TypeSentence(string sentence)//typwnei xarakthra-xarakthra thn protash
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()//teleiwnei o dialogos kai kleinei to dialoguebox
    {
        arrow.SetActive(true);
        animator.SetBool("IsOpen", false);
        endeddial = true;
        if (chief == true)//an einai h teleutaia protash tou telikou boss, ton energopoiei gai na epitethei
        {
            boss.GetComponent<Enemy>().enabled = true;
        }
        chief = false;
        Debug.Log("End of conversation.");
    }
}
