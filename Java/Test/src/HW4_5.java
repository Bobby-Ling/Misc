import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class HW4_5 {

    public static void main(String[] args) {
        // T3();
        T4();
    }

    public static void T3() {
        StringBuffer s1 = new StringBuffer("Java");
        StringBuffer s2 = new StringBuffer("HTML");

        // StringBuffer s3=s1.append(" is fun");
        // StringBuffer s3=s1.append(s2);
        // StringBuffer s3=s1.insert(2, "is fun");
        // StringBuffer s3=s1.insert(1,s2);
        // char c = s1.charAt(2);
        // int i = s1.length();
        // StringBuffer s3=s1.deleteCharAt(3);
        // StringBuffer s3=s1.delete(1,3);
        // StringBuffer s3=s1.reverse();
        // StringBuffer s3 = s1.replace(1, 3, "Computer");
        // String s3 = s1.substring(1, 3);
        // String s4 = s1.substring(2);
        StringBuffer s = new StringBuffer("Welcome to JAVA");
        s.setLength(0);
    }

    public static void T4() {
        String s1 = "Welcome";
        String s2 = new String("Welcome");
        String s3 = s2.intern();
        String s4 = "Wel" + "come";
        String s5 = "Wel";
        String s6 = "come";
        String s7 = s5 + s6;
        String s8 = "Wel" + new String("come");

        System.out.println(s1 == s2); //F
        System.out.println(s1 == s3); //T
        System.out.println(s1 == s4); //T
        System.out.println(s1 == s7); //F!!!
        System.out.println(s1 == s8); //F
        System.out.println(s1.equals(s2)); //T
        System.out.println(s1.equals(s3)); //T
        System.out.println(s1.equals(s4)); //T
        System.out.println(s1.equals(s7)); //T
        System.out.println(s1.equals(s8)); //T
    }
}

/**
 * EnCount 
 * U202215495
 */
class EnCount {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String inputStr = input.nextLine();
        int[] count=new int[26];
        for (char ch : inputStr.toCharArray()) {
            if (Character.isAlphabetic(ch)) {
                ch = Character.toUpperCase(ch);
                count[ch-'A'] += 1;
            }
        }
        for (int i = 0; i < count.length; i++) {
            System.out.print((char)('A'+i)+" "+count[i]+"|");
        }
        input.close();
    }
}

/**
 * Random
 * U202215495
 */

class Random {
    public static void main(String[] args) {
        ArrayList<String> licensePlates = new ArrayList<String>();
        while (licensePlates.size() < 5) {
            StringBuffer current = new StringBuffer();
            for (int j = 0; j < 3; j++) {
                current.append((char) (Math.random() * 26 + 'A'));
            }
            for (int j = 0; j < 4; j++) {
                current.append((int) (Math.random() * 10 ));
            }
            if (!licensePlates.contains(current.toString())) {
                licensePlates.add(current.toString());
            }
        }
        for (String current : licensePlates) {
            System.out.println(current);
        }
    }
}