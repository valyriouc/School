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
public class A5 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Mensch m1 = new Mensch();
        m1.name="Sascha";
        m1.alter=18;
        m1.laufen();
        System.out.println("Alter von m1 "+m1.alter);
    }
    
}
