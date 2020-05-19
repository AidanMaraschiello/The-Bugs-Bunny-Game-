using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int hotspot;
    public TextBox textBox;
    public FirstPersonController control;
    public Inventory inv;

    public List<string> log = new List<string>();

    public bool interacting;

    public Soundboard soundboard;

    public Material soldOut;
    public GameObject spray;
    public GameObject machete;
    public GameObject cherries;
    public GameObject vines;
    public Material vinesCut;
    public Animation manfred;
    public Animation hypnotize;
    public GameObject crunch;
    public GameObject crunchWalter;
    public Animation walter;
    public Animation frog;
    public Animation secretDoor;
    public GameObject keypad;
    public Animation WallaceAndGromit;
    public Animation ice;
    public GameObject cheese;
    public GameObject icepick;
    public Animation throwCheese;
    public GameObject wallaceDoorBlock;
    public Animation wallace;
    public GameObject SwatTeam;
    public Animation crush;
    public Animation water;
    public Animation lightning;
    public ParticleSystem fire;
    public Animation baby;
    public GameObject EndSoldiers;
    public bool babyInChamber;
    public int babyHealth;
    public GameObject HealthBar;
    public RectTransform meter;
    public Text healthText;
    public GameObject tesseract;
    public GameObject pancakes;

    public AudioSource onettMusic;
    public AudioSource metroidMusic;

    // Start is called before the first frame update
    void Start()
    {
        interacting = false;
        control = GetComponent<FirstPersonController>();
        StartCoroutine(Interact(38));
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f)), out hit, 200f);

        if (!interacting && hit.collider != null && hit.collider.gameObject.GetComponent<Hotspot>() != null)
        {
            if (Mathf.Sqrt(Mathf.Pow(hit.collider.transform.position.x - transform.position.x, 2) + Mathf.Pow(hit.collider.transform.position.z - transform.position.z, 2)) <= 5f) {

                hotspot = hit.collider.GetComponent<Hotspot>().id;
            } else {
                hotspot = -1;
            }
        }
        else
        {
            hotspot = -1;
        }

        if (Input.GetMouseButtonDown(0) && hotspot >= 0) {
            StartCoroutine(Interact(hotspot));
        }
    }

    public IEnumerator Interact(int id) {
        interacting = true;
        yield return null;

        if (id == 0) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            if (log.Contains("strangerGold")) {
                StartCoroutine(textBox.Display("kind stranger", "Excuse me, I already gave you a gold"));
                while (textBox.typing) {
                    yield return null;
                }
            }
            else {
                log.Add("strangerGold");
                StartCoroutine(textBox.Display("kind stranger", "Here, have a gold"));
                while (textBox.typing) {
                    yield return null;
                }
                StartCoroutine(textBox.Display("you", "Thank you kind stranger!!"));
                while (textBox.typing) {
                    yield return null;
                }
                inv.AddItem("coin");
            }

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 1) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;
            if (inv.inv.Contains("coin")) {
                StartCoroutine(textBox.Display("", "You buy the machete"));
                while (textBox.typing) {
                    yield return null;
                }
                machete.GetComponent<MeshRenderer>().material = soldOut;
                machete.GetComponent<BoxCollider>().enabled = false;
                inv.RemoveItem("coin");
                inv.AddItem("machete");
                StartCoroutine(textBox.Display("", "Its good for cutting through vines and stuff"));
                while (textBox.typing) {
                    yield return null;
                }
            }
            else {
                StartCoroutine(textBox.Display("", "You don't have enough money"));
                while (textBox.typing) {
                    yield return null;
                }
                StartCoroutine(textBox.Display("", "peasant"));
                while (textBox.typing) {
                    yield return null;
                }
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 2) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            int coins = 0;
            foreach (string item in inv.inv) {
                if (item == "coin") {
                    coins += 1;
                }
            }

            if (coins >= 2) {
                StartCoroutine(textBox.Display("", "You buy the Anti Frog Spray"));
                while (textBox.typing) {
                    yield return null;
                }
                spray.GetComponent<MeshRenderer>().material = soldOut;
                spray.GetComponent<BoxCollider>().enabled = false;
                inv.RemoveItem("coin");
                inv.RemoveItem("coin");
                inv.AddItem("spray");
            }
            else {
                StartCoroutine(textBox.Display("", "You don't have enough money"));
                while (textBox.typing) {
                    yield return null;
                }
                StartCoroutine(textBox.Display("", "peasant"));
                while (textBox.typing) {
                    yield return null;
                }
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 3) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            int coins = 0;
            foreach (string item in inv.inv) {
                if (item == "coin") {
                    coins += 1;
                }
            }

            if (coins >= 3) {
                StartCoroutine(textBox.Display("", "You buy the hypnotic cherries"));
                while (textBox.typing) {
                    yield return null;
                }
                cherries.GetComponent<MeshRenderer>().material = soldOut;
                cherries.GetComponent<BoxCollider>().enabled = false;
                inv.RemoveItem("coin");
                inv.RemoveItem("coin");
                inv.RemoveItem("coin");
                inv.AddItem("hypnotic");
            }
            else {
                StartCoroutine(textBox.Display("", "You don't have enough money"));
                while (textBox.typing) {
                    yield return null;
                }
                StartCoroutine(textBox.Display("", "peasant"));
                while (textBox.typing) {
                    yield return null;
                }
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 4) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;
            if (inv.inv.Contains("machete")) {
                StartCoroutine(textBox.Display("", "You cut through the vines with the machete"));
                while (textBox.typing) {
                    yield return null;
                }
                vines.GetComponent<MeshRenderer>().material = vinesCut;
                vines.GetComponent<BoxCollider>().enabled = false;
            }
            else {
                StartCoroutine(textBox.Display("", "You can't get past these thick vines"));
                while (textBox.typing) {
                    yield return null;
                }
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 5) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;
            StartCoroutine(textBox.Display("Shrek", "Hello and Welcome to me swamp donkeh"));
            while (textBox.typing) {
                yield return null;
            }
            if (inv.inv.Contains("hypnotic")) {
                StartCoroutine(textBox.Display("", "You feed the hypnotic cherries to the prehistoric mammal"));
                while (textBox.typing) {
                    yield return null;
                }
                inv.RemoveItem("hypnotic");
                hypnotize.Play();
                StartCoroutine(textBox.Display("you", "y o u  w i l l  t e l l  u s  t h e  l o c a t i o n  o f  t h e  c h i l d"));
                while (textBox.typing) {
                    yield return null;
                }
                StartCoroutine(textBox.Display("manfred", "his secret lair is located in MacDoonolds"));
                while (textBox.typing) {
                    yield return null;
                }
                StartCoroutine(textBox.Display("manfred", "take my key card"));
                while (textBox.typing) {
                    yield return null;
                }
                inv.AddItem("keycard");
                log.Add("keycard");
                StartCoroutine(textBox.Display("manfred", "..."));
                while (textBox.typing) {
                    yield return null;
                }
                StartCoroutine(textBox.Display("manfred", "i'm sorry roshan..."));
                while (textBox.typing) {
                    yield return null;
                }
                manfred.GetComponent<BoxCollider>().enabled = false;
                manfred.Play();
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 6) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;
            StartCoroutine(textBox.Display("ronald", "So am I the only one upset about how WWII ended? I mean they built Hitler up to be the big bad and"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("ronald", "just when he is about to face justice, he goes and kills himself. WTF was the point of him if FDR and"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("ronald", "Churchill were not going to fight him in an epic duel to save the world? And don't get me started on FDR!"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("ronald", "They just kill him half way through the war. Truman totally did not deserve to win the war, his character arc was not about war winning. "));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("ronald", "And another thing that pissed me off is that in the last episode of the war we find out that Stalin was a bad guy the entire time! Where was this foreshadowed to us? WTF, absolute character assassination."));
            while (textBox.typing) {
                yield return null;
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 7) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;
            StartCoroutine(textBox.Display("you", "Hi can i get uhhhh.... borgar"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("squard", "nyet"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("you", "why not"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("squard", "because nyet"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("you", "aight"));
            while (textBox.typing) {
                yield return null;
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 8) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;
            StartCoroutine(textBox.Display("Wally", "Hey guys, Wally here from Papa's Pancakaria"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("Wally", "I am here with my son"));
            while (textBox.typing) {
                yield return null;
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 9) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;
            if (log.Contains("walterCrunch")) {
                StartCoroutine(textBox.Display("walter", "thanks"));
                while (textBox.typing) {
                    yield return null;
                }
            }
            else
            {
                StartCoroutine(textBox.Display("walter", "i require the crünch"));
                while (textBox.typing) {
                    yield return null;
                }
            }

            if (inv.inv.Contains("crunch")) {
                StartCoroutine(textBox.Display("", "You give him the crünch"));
                while (textBox.typing) {
                    yield return null;
                }
                inv.RemoveItem("crunch");
                crunchWalter.SetActive(true);
                walter.Play();
                log.Add("walterCrunch");
            }
            StartCoroutine(textBox.Display("walter", "walter"));
            while (textBox.typing) {
                yield return null;
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 10) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;
            StartCoroutine(textBox.Display("", "You obtain the crünch"));
            while (textBox.typing) {
                yield return null;
            }
            crunch.SetActive(false);
            inv.AddItem("crunch");
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 11) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("peter griffin", "We must protect the crünch"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("wide frog", "dont worry"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("wide frog", "i will protect the crünch"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("peter griffin", "Thank you wide frog"));
            while (textBox.typing) {
                yield return null;
            }

            if (inv.inv.Contains("spray")) {
                StartCoroutine(textBox.Display("", "You apply the anti-frog spray to the wide amphibian"));
                while (textBox.typing) {
                    yield return null;
                }
                inv.RemoveItem("spray");
                frog.Play();
                frog.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(textBox.Display("peter griffin", "wide frog"));
                while (textBox.typing) {
                    yield return null;
                }
                StartCoroutine(textBox.Display("peter griffin", "no"));
                while (textBox.typing) {
                    yield return null;
                }
            }

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;

        }
        else if (id == 12) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;
            StartCoroutine(textBox.Display("peter griffin", "it's me, Family Guy hehehehehhehhehehehhehehhehehhehe"));
            while (textBox.typing) {
                yield return null;
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 13) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;
            StartCoroutine(textBox.Display("bing bong", "Please browse my wares"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bing bong", "bing bøng"));
            while (textBox.typing) {
                yield return null;
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 14) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            if (inv.inv.Contains("keycard")) {
                StartCoroutine(textBox.Display("", "You scan the keycard into the scanner"));
                while (textBox.typing) {
                    yield return null;
                }
                keypad.GetComponent<BoxCollider>().enabled = false;
                secretDoor.Play();
                soundboard.Play("doorOpen");
                onettMusic = metroidMusic;
            } else {
                StartCoroutine(textBox.Display("", "It's some kind of scanner"));
                while (textBox.typing) {
                    yield return null;
                }
            }

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 15) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            WallaceAndGromit.Play();
            WallaceAndGromit.GetComponent<AudioSource>().Play();

            StartCoroutine(textBox.Display("you", "Oh"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("you", "Oh no..."));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("you", "It can't be"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("you", "It's the Ice Age Baby's infamous bodyguards..."));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("you", "Wolliss and Dog"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("you", "There's no way I can get past themm..."));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("you", "their only weakness is CHEESE"));
            while (textBox.typing) {
                yield return null;
            }

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 16) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            if (inv.inv.Contains("cheese")) {
                StartCoroutine(textBox.Display("", "You throw the cheese at the bodyguards"));
                while (textBox.typing) {
                    yield return null;
                }
                throwCheese.Play();
                WallaceAndGromit.Play("Distracted");
                wallace.Play("WallaceDistract");
                WallaceAndGromit.GetComponent<BoxCollider>().size = new Vector3(4f, 4f, 1f);
                WallaceAndGromit.GetComponent<BoxCollider>().center = new Vector3(1.5f, 0f, 0f);
                wallaceDoorBlock.SetActive(false);
                inv.RemoveItem("cheese");
                WallaceAndGromit.GetComponent<AudioSource>().volume = 0.1f;
                StartCoroutine(CrackersDelay());

            }
            else {
                StartCoroutine(textBox.Display("", "They aren't responding"));
                while (textBox.typing) {
                    yield return null;
                }
            }



            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 17) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            if (inv.inv.Contains("icepick")) {
                StartCoroutine(textBox.Display("", "You break the ice surrounding the cheese"));
                while (textBox.typing) {
                    yield return null;
                }
                ice.Play();
            } else {
                StartCoroutine(textBox.Display("", "This cheese is frozen in a block of ice"));
                while (textBox.typing) {
                    yield return null;
                }
                StartCoroutine(textBox.Display("", "Ice Age Baby must have been here..."));
                while (textBox.typing) {
                    yield return null;
                }
            }

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 18) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("", "You take the cheese"));
            while (textBox.typing) {
                yield return null;
            }
            inv.AddItem("cheese");
            cheese.SetActive(false);

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 19) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("", "You take the ice pick"));
            while (textBox.typing) {
                yield return null;
            }
            inv.AddItem("icepick");
            icepick.SetActive(false);

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 20) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            SwatTeam.SetActive(true);
            soundboard.Play("gun");

            StartCoroutine(textBox.Display("bernie sanders", "It's over, Ice Age Baby"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie sanders", "You are surrounded"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie sanders", "Excellent work, soldier"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie sanders", "Alright men, let's take this criminal scum to the Execution Chamber"));
            while (textBox.typing) {
                yield return null;
            }
            baby.gameObject.SetActive(true);
            EndSoldiers.SetActive(true);
            babyInChamber = true;
            babyHealth = 100;
            inv.inv = new List<string>();
            inv.SetInv();
            control.enabled = false;
            transform.position = new Vector3(14.31f, 2.7f, 39.58f);
            yield return new WaitForSeconds(0.2f);
            control.enabled = true;
            onettMusic.Stop();
            soundboard.Play("soldiersEnd");

            StartCoroutine(textBox.Display("bernie sanders", "Ice Age Baby, you are found guilty of numerous war crimes and are sentenced to death"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie sanders", "You may do the honors, soldier"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie sanders", "Whenever you are ready"));
            while (textBox.typing) {
                yield return null;
            }
            HealthBar.SetActive(true);
            meter.gameObject.SetActive(true);

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 21) {
            fire.Play();
            soundboard.Play("fire");
            if (babyInChamber) {
                baby["BabyFlash"].time = 0f;
                baby.Play();
                if (babyHealth > 1) {
                    babyHealth -= 3;
                    healthText.text = "" + babyHealth;
                    meter.sizeDelta = new Vector2(360f * (babyHealth / 100f), 400f);
                    meter.localPosition = new Vector3(-180f + (180f * (babyHealth / 100f)), 182f, 0f);
                    //100 = 0
                    //1 = -178
                }
                else {
                    StartCoroutine(Interact(25));
                }
            }
        }
        else if (id == 22) {
            water["Water"].time = 0f;
            water.Play();
            soundboard.Play("water");
            if (babyInChamber) {
                baby["BabyFlash"].time = 0f;
                baby.Play();
                if (babyHealth > 1) {
                    babyHealth -= 3;
                    healthText.text = "" + babyHealth;
                    meter.sizeDelta = new Vector2(360f * (babyHealth / 100f), 400f);
                    meter.localPosition = new Vector3(-180f + (180f * (babyHealth / 100f)), 182f, 0f);
                    //100 = 0
                    //1 = -178
                }
                else {
                    StartCoroutine(Interact(25));
                }
            }
        }
        else if (id == 23) {
            lightning["Lightning"].time = 0f;
            lightning.Play();
            soundboard.Play("lightning");
            if (babyInChamber) {
                baby["BabyFlash"].time = 0f;
                baby.Play();
                if (babyHealth > 1) {
                    babyHealth -= 3;
                    healthText.text = "" + babyHealth;
                    meter.sizeDelta = new Vector2(360f * (babyHealth / 100f), 400f);
                    meter.localPosition = new Vector3(-180f + (180f * (babyHealth / 100f)), 182f, 0f);
                    //100 = 0
                    //1 = -178
                }
                else {
                    StartCoroutine(Interact(25));
                }
            }
        }
        else if (id == 24) {
            crush["Crush"].time = 0f;
            crush.Play();
            soundboard.Play("crush");
            if (babyInChamber) {
                baby["BabyFlash"].time = 0f;
                baby.Play();
                if (babyHealth > 1) {
                    babyHealth -= 3;
                    healthText.text = "" + babyHealth;
                    meter.sizeDelta = new Vector2(360f * (babyHealth / 100f), 400f);
                    meter.localPosition = new Vector3(-180f + (180f * (babyHealth / 100f)), 182f, 0f);
                    //100 = 0
                    //1 = -178
                }
                else {
                    StartCoroutine(Interact(25));
                }
            }
        }
        else if (id == 25) {
            interacting = true;
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            babyInChamber = false;
            StartCoroutine(textBox.Display("bernie sanders", "Alright. The fiend is weakened. It's time to finish the job."));
            while (textBox.typing) {
                yield return null;
            }
            baby.Play("BabyEscape");
            StartCoroutine(textBox.Display("bernie sanders", "Where is he going???"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie sanders", "Someone stop him!!!!"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie sanders", "He is escaping through the open window!!!!"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie sanders", "..."));
            while (textBox.typing) {
                yield return null;
            }
            HealthBar.SetActive(false);
            meter.gameObject.SetActive(false);
            StartCoroutine(textBox.Display("bernie sanders", "Damn. We'll get him next time for sure."));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie sanders", "Ok this is the end of the game because I ran out of ideas."));
            while (textBox.typing) {
                yield return null;
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 26) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            if (log.Contains("keycard")) {
                StartCoroutine(textBox.Display("troops", "where he go"));
                while (textBox.typing) {
                    yield return null;
                }
            }
            else {
                StartCoroutine(textBox.Display("troops", "Tell us the location of Ice Age Baby or we will open fire"));
                while (textBox.typing) {
                    yield return null;
                }
            }

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 27) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("conkeldurr", "It is I, Conkeldurr"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("conkeldurr", "The objectively best pokemon"));
            while (textBox.typing) {
                yield return null;
            }

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 28) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            if (log.Contains("chestGold")) {
                StartCoroutine(textBox.Display("", "The chest is empty"));
                while (textBox.typing) {
                    yield return null;
                }
            }
            else {
                StartCoroutine(textBox.Display("", "Inside the chest is one gold coin"));
                while (textBox.typing) {
                    yield return null;
                }
                log.Add("chestGold");
                inv.AddItem("coin");
            }

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;

        }
        else if (id == 29) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("", "You absorb the four-dimensional hypercube"));
            while (textBox.typing) {
                yield return null;
            }
            tesseract.SetActive(false);
            inv.AddItem("tesseract");
            StartCoroutine(textBox.Display("", "Maybe a geometric being nearby would like it...?"));
            while (textBox.typing) {
                yield return null;
            }

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 30) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("plane", "`¥ú√tyRp[N¢uRpÿ˙†uRè±†°uRÖ\nkObuÚ£¿û¢uQ_[$çªVö#Ñˆ“ˆúth6÷2ÑÃÁ5S	Ç∫‰"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("plane", "´¿lÂï;“h,∑¿lÂµSö#îÖ•\néáø¯ƒ‘Ãó™∑∂˙í1≤nÕú‘áﬁ”≥V∆”22ÈµÜ?÷k˘íhn°Ñf…_&ûi;n·<f˘Pi∞jM∂»j·GäΩˇ;—ﬁ˛9û41—áûh—∂¨âWææTÍhµ÷ø˜íÈhøo±1vû¥Óﬁë’Ï¶2ë’¨Økir—"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("plane", "µÓíiÈËjiii©“â–f—Êî˜’{–’›ˆr!ÃUÇø¨¬6∞Sﬁ«Yüî¢SûñaÚå∑†44««®´KÂ	Å≥L≈¸g4ÍlÕ¢„‚nµn~GÅ "));
            while (textBox.typing) {
                yield return null;
            }
            if (inv.inv.Contains("tesseract")) {
                StartCoroutine(textBox.Display("", "You give the hypercube to the plane"));
                while (textBox.typing) {
                    yield return null;
                }
                inv.RemoveItem("tesseract");
                StartCoroutine(textBox.Display("", "It appears to be thankful"));
                while (textBox.typing) {
                    yield return null;
                }
                StartCoroutine(textBox.Display("", "You got one gold coin"));
                while (textBox.typing) {
                    yield return null;
                }
                inv.AddItem("coin");
            }

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 31) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("", "You take the pancakes"));
            while (textBox.typing) {
                yield return null;
            }
            inv.AddItem("pancakes");
            pancakes.SetActive(false);

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 32) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            if (log.Contains("sansPancakes")) {
                StartCoroutine(textBox.Display("sans", "thanks"));
                while (textBox.typing) {
                    yield return null;
                }
            }
            else {
                StartCoroutine(textBox.Display("sans", "hey"));
                while (textBox.typing) {
                    yield return null;
                }
                StartCoroutine(textBox.Display("sans", "you got any of those uhhhhh"));
                while (textBox.typing) {
                    yield return null;
                }
                StartCoroutine(textBox.Display("sans", "pancakes"));
                while (textBox.typing) {
                    yield return null;
                }
                if (inv.inv.Contains("pancakes")) {
                    StartCoroutine(textBox.Display("", "You give him the pancakes"));
                    while (textBox.typing) {
                        yield return null;
                    }
                    inv.RemoveItem("pancakes");
                    log.Add("sansPancakes");
                    StartCoroutine(textBox.Display("sans", "ayy nice"));
                    while (textBox.typing) {
                        yield return null;
                    }
                    StartCoroutine(textBox.Display("sans", "take this for your troubles"));
                    while (textBox.typing) {
                        yield return null;
                    }
                    StartCoroutine(textBox.Display("", "You got one gold coin"));
                    while (textBox.typing) {
                        yield return null;
                    }
                    inv.AddItem("coin");
                }
                else {
                    StartCoroutine(textBox.Display("sans", "i will literally pay you 1 dollar for some pancakes"));
                    while (textBox.typing) {
                        yield return null;
                    }
                }
            }

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;


        }
        else if (id == 33) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("garfield", "hey its me garfeld"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("garfield", "im just doin some bouncing uwu"));
            while (textBox.typing) {
                yield return null;
            }
            if (!log.Contains("garfieldCoin")) {
                log.Add("garfieldCoin");
                StartCoroutine(textBox.Display("garfield", "please take this gold coin"));
                while (textBox.typing) {
                    yield return null;
                }
                inv.AddItem("coin");
            }

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 34) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("carl azuz", "Whaddup it's carl azuz with CNN 10"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("carl azuz", "We're out here in Iraq where ice age baby is said to be hiding"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("carl azuz", "that's one baby who be icy"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("carl azuz", "im carl azuz from cnn 10 catch you next week"));
            while (textBox.typing) {
                yield return null;
            }
            if (!log.Contains("carlCoin")) {
                log.Add("carlCoin");
                StartCoroutine(textBox.Display("", "You recieved one gold coin"));
                while (textBox.typing) {
                    yield return null;
                }
                inv.AddItem("coin");
            }

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 35) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("bernie", "coincidence? I think NOT!!!!!!!!!!!!!"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie", "-bernie the teacher from the incredibles movie"));
            while (textBox.typing) {
                yield return null;
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 36) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("mexican stalin", "сука Блядь пить водку Меня зовут мексиканский Сталин, и я был сделан моими друзьями"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("mexican stalin", "(translation: There is an associate of Ice Age Baby down that way. We must interrogate him to find out the target's hiding place.)"));
            while (textBox.typing) {
                yield return null;
            }

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 37) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("rick", "ohhh lets go and commit some tax evasion morty"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("rick", "im pickle rick wubba lubba dub dub"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("morty", "I am not comfortable with these activities richard"));
            while (textBox.typing) {
                yield return null;
            }

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 38) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("bernie sanders", "alright bois"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie sanders", "we're in Iraq, where Ice Age Baby was sighted"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie sanders", "I am once again asking for your shooty shooty support"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie sanders", "the mission is simple:"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie sanders", "Find Ice Age Baby"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie sanders", "Kill Ice Age Baby"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bernie sanders", "Lets a go"));
            while (textBox.typing) {
                yield return null;
            }
            onettMusic.Play();

            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 39) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("bernie sanders", "Did you locate the ice age baby yet??"));
            while (textBox.typing) {
                yield return null;
            }

            StartCoroutine(textBox.Display("bernie sanders", "No?"));
            while (textBox.typing) {
                yield return null;
            }


            StartCoroutine(textBox.Display("bernie sanders", "THEN KEEP SEARCHING"));
            while (textBox.typing) {
                yield return null;
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 40) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("troops", "find"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("troops", "kill"));
            while (textBox.typing) {
                yield return null;
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 41) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("bill nye", "No secrets down this way bruh"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("bill nye", "Also I'm stuck in the floor"));
            while (textBox.typing) {
                yield return null;
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 42) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("vsauce michael", "HEY VSAUCE MICHAEL HERE"));
            while (textBox.typing) {
                yield return null;
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }
        else if (id == 43) {
            control.m_WalkSpeed = 0f;
            control.m_RunSpeed = 0f;

            StartCoroutine(textBox.Display("peter goomba", "peter goomba"));
            while (textBox.typing) {
                yield return null;
            }
            StartCoroutine(textBox.Display("peter goomba", "peter goomba"));
            while (textBox.typing) {
                yield return null;
            }
            control.m_WalkSpeed = 5f;
            control.m_RunSpeed = 10f;
        }





        interacting = false;
    }

    public IEnumerator CrackersDelay() {
        yield return new WaitForSeconds(4f);
        soundboard.Play("crackers");
    }


    public void OnTriggerEnter(Collider col) {
        if (col.gameObject.name == "WallaceGromitTrigger" && !log.Contains("encounterWallaceGromit")) {
            log.Add("encounterWallaceGromit");
            StartCoroutine(Interact(15));
        }
        else if (col.gameObject.name == "BabyTrigger") {
            StartCoroutine(Interact(20));
        }
        else if (col.gameObject.name == "shopMusic") {
            onettMusic.Stop();
            col.GetComponent<AudioSource>().Play();
        }
    }

    public void OnTriggerExit(Collider col) {
        if (col.gameObject.name == "shopMusic") {
            col.GetComponent<AudioSource>().Stop();
            onettMusic.Play();
        }
    }
}
