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
public class Z1 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
       int zahl = 123456;
       int ziffer = 0;
       while (zahl>0) {
           ziffer = zahl % 10;
           zahl = zahl / 10;
           System.out.println(ziffer);
       }
    }
    
}
