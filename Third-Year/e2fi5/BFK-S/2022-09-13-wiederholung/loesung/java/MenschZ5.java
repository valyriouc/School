/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javawdh;

/**
 *
 * @author spangpa
 */
public class MenschZ5 {
     String name;
    String haarfarbe;
    int alter;
    String zustand;
    
    public void schlafen(){
        zustand = "schläft";
    }
    
    public void wecken(){
        zustand = "wach";
    }
    
    public void weckt(MenschZ5 mensch){
        if (mensch.zustand.equals("schläft"))
          mensch.wecken();
    }
    
    public void sitzen(){
        zustand = "sitzt";
    }
    
    public void zustand(){
        System.out.println(name + " " + zustand);
    }   
}
