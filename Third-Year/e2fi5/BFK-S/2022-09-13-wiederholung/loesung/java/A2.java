/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package javawdh;

import java.util.Scanner;

/**
 *
 * @author baldes
 */
public class A2 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        Scanner s = new Scanner(System.in);
        int z=1;
        //String s1 = s.nextLine();
        float kehrwert;
        do {
          System.out.print("Eingabe: ");
          z = s.nextInt();  
          if (z!=0) {
            kehrwert = 1/(float)z;    
            System.out.println("Kehrwert "+kehrwert);
          }
        } while (z!=0);
        
         
    }
    
}
