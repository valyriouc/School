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
public class Z4 {

    
    public static boolean teilbar(int a, int b) {
      return a%b==0;
    } 

    public static int wuerfel() {
      return (int)(Math.random()*6)+1;
    } 

    public static int anzahlZiffern(int zahl) {
        return (int)(Math.log(zahl)/Math.log(10))+1;
 
        /* oder:
        String s=String.valueOf(zahl);
        return s.length();
        */
    }
    
    public static String binaer(int zahl) {
        int anzahlZiffernBinaer=(int)(Math.log(zahl)/Math.log(2))+1;
        int[] bin = new int[anzahlZiffernBinaer];
        int rest=zahl;
        int i=anzahlZiffernBinaer-1;
        int binZiff=-1;
       
        while (rest>0) {
            binZiff=rest%2;
            rest=(rest-binZiff)/2;
            bin[i]=binZiff;
            i--; 
        }
           
        String res="";
        for (int j = 0; j<anzahlZiffernBinaer; j++) {
            res=res+bin[j];
        }
        return res;       
    }
        
    
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        boolean t1 = teilbar(6,2);
        System.out.println("6 durch 2 teilbar:"+t1);
        boolean t2 = teilbar(6,5);
        System.out.println("6 durch 5 teilbar:"+t2);
        
        System.out.print("Ergebnis Würfel:");
        for (int i = 0; i < 10; i++) {
            System.out.print(wuerfel()+" "); 
        }
        System.out.println("");
              
        int z=100000;
        System.out.println("Anzahl Ziffern von"+z+":"+anzahlZiffern(z));
        
        z=258;
        System.out.println("Die Binärdarstellung zu "+z+" lautet: "+binaer(z));
        
    }

    
    
}
