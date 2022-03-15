using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextController : MonoBehaviour
{
    [SerializeField] Text storyText;
    [SerializeField] ImageController imageController;
    [SerializeField] LevelStateController levelStateController;
    private enum States
    {
        defeat, defeat_dog, defeat_vacuum, defeat_agony, defeat_questionmark, victory, victory_questionmark, home, room, hallway, bathroom, armory, bridge, powerroom, bathroom_near_window, brushing_teeth, bridge1, bridge2, bridge3, bridge3_2
    }

    private States myState;

    // Start is called before the first frame update
    void Start()
    {
        storyText.text = "Our first start text!!";
        myState = States.home;

        Instantiate(levelStateController);
        if(levelStateController== null){
            print("levelStateController is null");
        }

        Instantiate(imageController);
        if(imageController== null){
            print("imageController is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space)){
        // storyText.text = "Spacebar pressed!";
        // }
        if (myState == States.defeat)
        {
            defeat();
        }
        else if (myState == States.defeat_dog)
        {
            defeat_dog();
        }        
        else if (myState == States.defeat_agony)
        {
            defeat_agony();
        }
        else if (myState == States.victory)
        {
            victory();
        }
        else if (myState == States.home)
        {
            home();
        }
        else if (myState == States.room)
        {
            room();
        }
        else if (myState == States.hallway)
        {
            hallway();
        }
        else if (myState == States.bathroom)
        {
            bathroom();
        }
        else if (myState == States.armory)
        {
            armory();
        }
        else if (myState == States.bridge)
        {
            bridge();
        }
        else if (myState == States.powerroom)
        {
            powerroom();
        }
        else if (myState == States.bathroom_near_window)
        {
            bathroom_near_window();
        }
        else if (myState == States.defeat_vacuum)
        {
            defeat_vacuum();
        }
        else if (myState == States.brushing_teeth)
        {
            brushing_teeth();
        }
        else if (myState == States.victory_questionmark)
        {
            victory_questionmark();
        }
        else if (myState == States.bridge1)
        {
            bridge1();
        }
        else if (myState == States.bridge2)
        {
            bridge2();
        }
        else if (myState == States.bridge3)
        {
            bridge3();
        }
        else if (myState == States.bridge3_2)
        {
            bridge3_2();
        }
        else
        {
            storyText.text = "UNDEFINED STATE ERROR";
        }
    }

    void defeat() {
        imageController.SetAndShowImage(2,levelStateController.Power);
        storyText.text = "Defeat!\n" +
        "\n -> Press S to start over";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.home;
        }
    }    
    void defeat_dog() {
        // imageController TODO show dogman
        imageController.SetAndShowImage(3,levelStateController.Power);
        storyText.text = "Defeat!"+
        "\nYou tried to run away, but eventually you got caught, " +
        "\nand now they fused your head with the body of a dog."+
        "\n(because that is what aliens like to do)"+
        "\n -> Press S to start over";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.home;
        }
    }    
    void defeat_vacuum(){
        imageController.SetAndShowImage(2,levelStateController.Power);
        storyText.text = "Defeat!"+
        "\nYou have been sucked into outer space. Sadge."+
        "\n"+
        "\n -> Press S to start over";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.home;
        }      
    }
    void defeat_agony(){
        imageController.SetAndShowImage(2,levelStateController.Power);
        storyText.text = "Defeat!"+
        "\nYou died while suffering agonizing pain caused by alien bacteria."+
        "\n"+
        "\n -> Press S to start over";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.home;
        }           
    }
    void victory() {
        imageController.SetAndShowImage(2,levelStateController.Power);
        storyText.text = "Victory!" +
        "\n"+
        "\n -> Press S to start again";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.home;
        }
    }
    
    void victory_questionmark(){
        imageController.SetAndShowImage(9,levelStateController.Power);
        storyText.text = "Alien bacteria caused you to lose consciousness. " +
        "Moments later, you woke up and saw an alien staring at you. "+
        "The alien played a recording of his translated speech: "+
        "\"At first, we wanted to fuse your head with a dog and keep you as a pet, "+
        "but then we got amazed by your dental hygiene and decided to leave you be.\" "+

        "\n -> Press Space to continue";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myState = States.victory;
        }
    }

    void home() {
        levelStateController.ResetValues();
        imageController.SetAndShowImage(2,levelStateController.Power);

        storyText.text = "You are a professor that just came home and went straight to the bed after a very exhausting day. " +
       "A sudden flash of light breaks your sleep. "+
       "You open your eyes and see you are no longer in your room... " +
       "\n\n -> Press space to continue";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myState = States.room;
        }
    }
    void room() {
        imageController.SetAndShowImage(10,levelStateController.Power);

        storyText.text = "It really seems like you've been teleported to an alien spaceship, but it is absurd to even think about it being a possibility... Right?"+
        "\n"+
        "\n -> Press space to continue";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myState = States.hallway;
        }
    }
    void hallway() {
        imageController.SetAndShowImage(4,levelStateController.Power);

        // print("Power is: "+levelStateController.Power);
        storyText.text = "You are in a hallway. There are 4 doors marked by images shown below. " +
            "Some noise can be heard coming from the 3rd room." +
            "\n"+
            "\n -> Press 1, 2, 3 or 4 to enter one of the rooms marked below.";


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            myState = States.bathroom;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            myState = States.armory;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            myState = States.bridge;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            myState = States.powerroom;
        }
    }
    void bathroom() {
        imageController.SetAndShowImage(1,levelStateController.Power);

        storyText.text="You are in the bathroom."+
        "\n -> Press E to escape through the window"+
        "\n -> Press T to brush your teeth"+
        "\n -> Press L to leave the room";
        if (Input.GetKeyDown(KeyCode.E))
        {
            // escape through the window -> death by vacuum
            myState=States.bathroom_near_window;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            // brush your teeth -> used someone elses brush; drink mouthwash? -> victory?ž
            myState=States.brushing_teeth;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Leave bathroom
            myState=States.hallway;
        }
    }
    void armory() { 
        imageController.SetAndShowImage(6,levelStateController.Power);

        if(levelStateController.Weapon==0){
            storyText.text="You have found some weapons. You can carry only one weapon. "+
            "\n -> Press 1, 2 or 3 to take a weapon"+
            "\n -> Press L to leave the room";
        }        
        if(levelStateController.Weapon==1){
            storyText.text="You chose Alien Blaster (1). You can carry only one weapon. "+
            "\n -> Press 2 or 3 to swap a weapon"+
            "\n -> Press L to leave the room";
        }        
        if(levelStateController.Weapon==2){
            storyText.text="You chose Tesla Coil (2). You can carry only one weapon. "+
            "\n -> Press 1 or 3 to swap a weapon"+
            "\n -> Press L to leave the room";
        }        
        if(levelStateController.Weapon==3){
            storyText.text="You chose Dual Nunchucks (3). You can carry only one weapon. "+
            "\n -> Press 1 or 2 to swap a weapon"+
            "\n -> Press L to leave the room";
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            levelStateController.Weapon=1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            levelStateController.Weapon=2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            levelStateController.Weapon=3;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            myState=States.hallway;
        }
    }
    void bridge() { 
        imageController.SetAndShowImage(0,levelStateController.Power);

        if(levelStateController.Weapon==0){ 
            storyText.text="You have entered what seems to be the control room."+
            "\nA number of aliens have taken a look at you and started running towards you."+
            "\n -> Press R to run";
        }     
        else if(levelStateController.Weapon==1 && levelStateController.Power==true){
            storyText.text="You have entered what seems to be the control room."+
            "\nA number of aliens have taken a look at you and started running towards you."+
            "\n -> Press W to use your weapon"+
            "\n -> Press R to run";  
        }
        else if(levelStateController.Weapon==2 && levelStateController.Power==true){
            storyText.text="You have entered what seems to be the control room."+
            "\nA number of aliens have taken a look at you and started running towards you."+
            "\n -> Press W to use your weapon"+
            "\n -> Press R to run";     
        }    
        else if(levelStateController.Weapon==3 && levelStateController.Power==true){
            storyText.text="You have entered what seems to be the control room."+
            "\nA number of aliens have taken a look at you and started running towards you."+
            "\n -> Press W to use your weapon"+
            "\n -> Press R to run";     
        }
        else if(levelStateController.Weapon==1 && levelStateController.Power==false){
            storyText.text="You have entered what might be the control room."+
            "The room reeks of ugly aliens."+
            "\n -> Press W to use your weapon"+
            "\n -> Press R to run";     
        }
        else if(levelStateController.Weapon==2 && levelStateController.Power==false){
            storyText.text="You have entered what might be the control room."+
            "The room reeks of ugly aliens."+
            "\n -> Press W to use your weapon"+
            "\n -> Press R to run";  
      
        }    
        else if(levelStateController.Weapon==3 && levelStateController.Power==false){
            storyText.text="You have entered what might be the control room."+
            "The room reeks of ugly aliens."+
            "\n -> Press W to use your weapon"+
            "\n -> Press R to run";   
        }  
        else{} 
        if(Input.GetKeyDown(KeyCode.W)){
            print(levelStateController.Weapon);
            print(levelStateController.Power);
            if(levelStateController.Weapon==1 && levelStateController.Power==false){myState=States.bridge1;}
            if(levelStateController.Weapon==1 && levelStateController.Power==true){myState=States.bridge1;}
            if(levelStateController.Weapon==2 && levelStateController.Power==false){myState=States.bridge2;}
            if(levelStateController.Weapon==2 && levelStateController.Power==true){myState=States.bridge2;}
            if(levelStateController.Weapon==3 && levelStateController.Power==false){myState=States.bridge3;}
            if(levelStateController.Weapon==3 && levelStateController.Power==true){myState=States.bridge3;}
        }   
        if(Input.GetKeyDown(KeyCode.R)){
            myState=States.defeat_dog;
        }              
    }
    void powerroom() {
        storyText.text="There is what seems to be the power generator in the room."+        
        "\n -> Press S to sabotage"+
        "\n -> Press L to leave the room";

        imageController.SetAndShowImage(5,levelStateController.Power);

        if (Input.GetKeyDown(KeyCode.S))
        {
            levelStateController.Power = false;
        }   
        if (Input.GetKeyDown(KeyCode.L))
        {
            myState=States.hallway;
        }         
     }

     void bathroom_near_window(){
        imageController.SetAndShowImage(7,levelStateController.Power);
        storyText.text="Are you sure about escaping through the window?"+    
        "\n -> Press Y to escape through the window"+
        "\n -> Press N to step away from the window";

        if (Input.GetKeyDown(KeyCode.Y))
        {
            // Yes - death by vacuum
            myState=States.defeat_vacuum;
        }   
        if (Input.GetKeyDown(KeyCode.N))
        {
            myState=States.bathroom;
        }               
     }

    void brushing_teeth(){
        imageController.SetAndShowImage(8,levelStateController.Power);
        storyText.text="You brushed your teeth, but then you've realized you used someone elses toothbrush. "+ 
        "Moreover, the original user is an alien! You quickly found a bottle that just might be a mouthwash."+  
        "\n -> Press Y to use the mouthwash"+
        "\n -> Press N if you are not afraid of alien germs";
        if (Input.GetKeyDown(KeyCode.Y))
        {
            myState=States.victory_questionmark;
        }   
        if (Input.GetKeyDown(KeyCode.N))
        {
            myState=States.defeat_agony;
        }     
    }
    void bridge1(){
        if(levelStateController.Power==false){
            storyText.text="You were taking down aliens one by one with your blaster, but unluckily didn't see one coming from aside. "+
            "\n -> Press Space to continue";          
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myState=States.defeat;
            }             
        }else if(levelStateController.Power==true){
             storyText.text="You shot all the aliens one by one with your blaster. Some of them survived, but the shock rendered them unable to move. "+
      
            "\n -> Press Space to continue";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myState=States.victory;
            }  
        }
    
    }
    void bridge2(){
        if(levelStateController.Power==false){
            storyText.text="After activating Tesla Coil by pulling its lever, every living being in front of you turned into dust. "+
            "\n"+  
            "\n -> Press Space to continue";          
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myState=States.victory;
            }             
        }else if(levelStateController.Power==true){
            storyText.text="After activating Tesla Coil by pulling its lever, every living being in front of you turned into dust. "+
            "\n"+
            "\n -> Press Space to continue";  
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myState=States.victory;
            }  
        }
    }
    void bridge3(){
            if(levelStateController.Power==false){
                storyText.text="You have just realized you don't know how to fight with Dual Nunchucks. "+
                "\n -> Press C to close your eyes and take a deep breath while accepting the inevitable"+
                "\n -> Press R to run"; 
                if (Input.GetKeyDown(KeyCode.C))
                {
                    myState=States.bridge3_2;
                } 
                if (Input.GetKeyDown(KeyCode.R))
                {
                    myState=States.defeat_dog;
                }   
            }else{ 
                storyText.text="You have just realized you don't know how to fight with Dual Nunchucks. "+
                "\n -> Press C to close your eyes and take a deep breath while accepting the inevitable"+
                "\n -> Press R to run";  
                if (Input.GetKeyDown(KeyCode.C))
                {
                    myState=States.defeat;
                } 
                if (Input.GetKeyDown(KeyCode.R))
                {
                    myState=States.defeat_dog;
                }   
            }
    }
    void bridge3_2(){
         storyText.text="A flash of Jackie Chan movies comes to your mind and you become enlightened by the knowledge of the black belt. "+
            "After beating a half of the aliens, the other half ran away like unhonorable cowards they are. "+
            "\n -> Press Space to continue"; 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myState=States.victory;
            }  
    }
}