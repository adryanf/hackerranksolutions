import java.util.*;

public class Solution {
    
    public static boolean canWin(int leap, int[] game) {
        // Return true if you can win the game; otherwise, return false.
        int length= game.length;
        
        if(leap > length-1){
            return true;
        }
        boolean[] locationProcessed= new boolean[length];
        
        return moveToWin(0, locationProcessed, leap, game);   
    }
    
    private static boolean moveToWin(int currentIndex, boolean[] locationProcessed, int leap, int[] game){
        if(currentIndex > game.length-1){
                return true;
        }else{
            if(locationProcessed[currentIndex]){
                return false;  
            }else{
                
                locationProcessed[currentIndex] = true;
                
                if(game[currentIndex] == 0){
                    boolean result = false;
                    
                    result = result || moveToWin(currentIndex+1, locationProcessed, leap, game);
                        
                    result = result || moveToWin(currentIndex+leap, locationProcessed, leap, game);
                    
                    if(currentIndex-1 >= 0){
                        result = result || moveToWin(currentIndex-1, locationProcessed, leap, game);
                    }
                    
                    return result;
                    
                }
                else{
                    return false;
                }
            }
        }
    }
    
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int q = scan.nextInt();
        while (q-- > 0) {
            int n = scan.nextInt();
            int leap = scan.nextInt();
            
            int[] game = new int[n];
            for (int i = 0; i < n; i++) {
                game[i] = scan.nextInt();
            }

            System.out.println( (canWin(leap, game)) ? "YES" : "NO" );
        }
        scan.close();
    }
}
