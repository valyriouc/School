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
public class Z3 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        int[] gew={100,0,50,500,0,30,0,500};
        
        // Teil a
        
        System.out.println("Folgende Lose haben einen Gewinn > 100:");
        for (int i = 0; i < gew.length; i++) {
           if (gew[i]>100) {
               System.out.println(" Los-Nr:"+(i+1));
           } 
        }
        
        // Teil b
        
        int max=-1;
        for (int i = 0; i < gew.length; i++) {
           if (gew[i]>max) {
               max=gew[i];
           } 
        }
        System.out.print("Den größten Gewinn von "+max+" auf Los/Lose:");
        for (int i = 0; i < gew.length; i++) {
             if (gew[i]==max) {
                 System.out.print((i+1)+" ");
            } 
          
        }  
    }
    
    /* Lösung von Z3b
    *  ==============
    *  a)100 b)55 c)0 d)-2 e)8%5=3 also 8 f)tab1[2]=5 also tab2[5]=2 
    */
    
}
