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
public class A3 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        int[] gew = new int[8];
        gew[0] = 100;
        gew[1] = 0;
        gew[2] = 50;
        gew[3] = 500;
        gew[4] = 0;
        gew[5] = 30;
        gew[6] = 0;
        gew[7] = 500;
        
        //Alternative
        // int[] gew={100,0,50,500,0,30,0,500};

        int summe=0;
        int nieten=0;
        for (int i = 0; i < gew.length; i++) {
            System.out.println("Losnummer:"+(i+1)+" Gewinn:"+gew[i]);
            if(gew[i]==0) nieten++;
            summe=summe+gew[i];
        }
        System.out.println("Summe:"+summe+" Anzahl Nieten:"+nieten);
    }
    
}
