import java.util.Scanner;
//凌诚睿U202215495
public class HM2 {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("input (0-1000)");
        int x = input.nextInt();
        int n = x % 10;
        x = x - n;
        int m = x / 10;
        int sum = 0;
        sum = sum + n;
        while (m != 0) {
            sum += m % 10;
            m /= 10;
        }
        System.out.print("sum is" + sum);

    }

}
