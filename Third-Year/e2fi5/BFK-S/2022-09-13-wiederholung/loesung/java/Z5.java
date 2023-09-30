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
public class Z5 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
            MenschZ5 patrick = new MenschZ5();
            patrick.name = "Patrick";
            patrick.alter = 19;
            patrick.haarfarbe = "Braun";
            patrick.schlafen();
            patrick.zustand();
            
            MenschZ5 tim = new MenschZ5();
            tim.name = "Tim";
            tim.alter = 20;
            tim.haarfarbe = "Blond";
            tim.sitzen();
            tim.weckt(patrick);
            patrick.zustand();
            tim.zustand();
    }
    
}
