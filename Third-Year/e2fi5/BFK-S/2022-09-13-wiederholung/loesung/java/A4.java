/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package javawdh;

/**
 *
 * @author baldes
 */
public class A4 {

    
    public static float durchschnitt(int note1, int note2) {
         float erg=(float)(note1+note2)/2;
         return erg;
    } 
    
    public static String notenText(int note) {
      if (note==1) {
          return "sehr gut";
      } else if (note==2) {
          return "gut";
      } else if (note==3) {
          return "befriedigend";
      } else if (note==4) {
          return "ausreichend";
      } else if (note==5) {
          return "mangelhaft";
      } else if (note==6) {
          return "ungenügend";
      } else {
          return "Fehler";
      }
    }
    
    
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        float d1 = durchschnitt(1,3);
        System.out.println("Durchschnitt1:"+d1);
        float d2 = durchschnitt(1,6);
        System.out.println("Durchschnitt1:"+d2);
        String text1 = notenText(1);
        System.out.println("Note1:"+text1);
        String text2 = notenText(5);
        System.out.println("Note2:"+text2);

    }
    
}
