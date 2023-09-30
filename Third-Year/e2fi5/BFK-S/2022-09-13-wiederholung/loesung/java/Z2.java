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
public class Z2 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        long counterMax=1000;
        int sign=-1;
        double pi=1;        
        for(long counter=1;counter<=counterMax;counter++) {
            pi=pi+sign*1.0/(counter*2+1);
            System.out.println(counter+":"+(pi*4));
            sign=sign*(-1);
        }
    }
    
}
