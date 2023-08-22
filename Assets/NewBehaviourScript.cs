using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int hp = 30;
    int mp = 25;
    int level=5;
        float strength = 15.5f;
        string playername = "나검사";
        bool isFullLevel = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello unity!");

        

        Debug.Log("용사의 레벨은?");
        Debug.Log(level);
        Debug.Log("용사의 이름은?");
        Debug.Log(playername);
        Debug.Log("용사의 힘능력치는?");
        Debug.Log(strength);
        Debug.Log("용사는 만렙인가?");
        Debug.Log(isFullLevel);


        string[] monsters = {"슬라임", "사막뱀", "악마뱀"};
        int[] monsterLevel = new int[3];

        monsterLevel[0]= 1;
        monsterLevel[1] = 2;
        monsterLevel[2] = 3;

        Debug.Log("맵에 존재하는 몬스터의 레벨");
        Debug.Log(monsterLevel[0]);
        Debug.Log(monsterLevel[1]);
        Debug.Log(monsterLevel[2]);

        List<string> items = new List<string>();
        items.Add("생명물약30");
        items.Add("마나물약30");

        // items.RemoveAt(0);

        Debug.Log("가지고 있는 아이템");
        Debug.Log(items[0]);
        Debug.Log(items[1]);


        int exp = 1500;
        
        exp = 1500+320;
        exp = exp -10;
        level = exp / 300;
        strength = level * 3.1f;

        int nextExp = 300 - (exp % 300);
        Debug.Log("다음 레벨까지 경험치");
        Debug.Log(nextExp);

        string title = "전설의";
        Debug.Log("용사의 이름은?");
        Debug.Log(title+" "+playername);

        int fullLevel = 99;
        isFullLevel = level == fullLevel;
        Debug.Log("용사는 만렙입니까?" + isFullLevel);

        bool isEndTutorial = level >10;
        Debug.Log("튜토리얼이 끝난 용사입니까?" + isEndTutorial);

        // int hp = 30;
        int mp = 25;
        // bool isBadCondition = hp<50 && mp<=20;
        bool isBadCondition = hp<50 || mp<=20;


        Debug.Log("지금 용사의 상태가 나쁩니까?" + isBadCondition);

        string condition = isBadCondition ? "나쁨" : "좋음";

        Debug.Log("용사의 컨디션은?"+ condition);

        if(condition == "나쁨"){
            Debug.Log("플레이어의 상태가 나쁘니 아이템을 사용하세요.");
        }else{
            Debug.Log("플레이어의 상태가 좋습니다.");
        }

        if(isBadCondition && items[0] =="생명물약30"){
            items.RemoveAt(0);
            hp+=30;
            Debug.Log("생명포션30을 사용하였습니다.");
        }
        else if(isBadCondition && items[1] =="마나물약30"){
            items.RemoveAt(0);
            mp+=30;
            Debug.Log("마나포션30을 사용하였습니다.");
        }

        string MonsterAlarm;
        switch (monsters[0])
        {
            case "슬라임":
            MonsterAlarm="소형 몬스터 출현!";
                break;

            case "사막뱀":
            MonsterAlarm="중형 몬스터 출현!";

            break;

            case "비단뱀":
            MonsterAlarm="대형 몬스터 출현!";

            break;
            
            default:
            MonsterAlarm="몬스터 출현!";
            break;
        }

        while(hp>0){
            hp--;
            if(hp>0)
            Debug.Log("독 데미지를 입었습니다" +hp);

            else
            Debug.Log("사망하였습니다.");

            if(hp==10){
                Debug.Log("해독제를 사용합니다.");
                break;
            }

        }

        for(int count = 0; count<10; count++){
            hp++;
            Debug.Log("붕대로 치료중..."+hp);
        }

        // for(int index = 0; index<monsters.Length; index++){
        //     Debug.Log("이 지역에 있는 몬스터: "+monsters[index]);
        // }

        foreach(string monster in monsters){
            Debug.Log("이 지역에 있는 몬스터: "+ monster);
        }

        Heal();

        for(int i = 0; i < monsters.Length; i++){
            Debug.Log("용사는 "+monsters[i]+"에게 "+
                Battle(monsterLevel[i]));
        }

        Actor player= new Actor();
        player.id = 0;
        player.name = "나마법사";
        player.title = "현명한";
        player.strength = 2.4f; 
        player.weapon = "나무지팡이";

        Debug.Log(player.Talk());
        Debug.Log(player.HasWeapon());

        player.LevelUp();
        Debug.Log(player.name+ "의 레벨은 "+ player.level);
    }


    //함수 메소드
    void Heal(){
        hp += 10;
        Debug.Log("힐을 받았습니다."+hp);
    }

    string Battle(int monsterLevel){
        string result;
        if(level >= monsterLevel)
            result = "이겼습니다.";
        else
            result = "졌습니다.";

        return result;
    
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
