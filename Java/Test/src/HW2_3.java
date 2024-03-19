public class HW2_3 {
    static boolean a;

    public static void main(String[] args) {
            // TIP Press <shortcut actionId="ShowIntentionActions"/> with your caret at the
        // highlighted text
        // to see how IntelliJ IDEA suggests fixing it.
        System.out.print("Hello and welcome!");
        boolean bool = true;
        System.out.println(bool);
        System.out.println(a);
        System.out.println((a = true) || (a = false));
        System.out.println(a);
        int x = 0, y = 0;
        System.out.println(((x > 1) && (++x == 0)) + " " + x);
        System.out.println(((y < 1) | (y++ == 0)) + " " + y);
        int a = 1;
        System.out.println(a);
        int z = a + (++a);
        System.out.println(z);

        a = 0;
        int b = (a++) + (++a) + (++a);
        System.out.println(b);

        x = 1;
        System.out.print((x > 1) & (x++ > 1));
        System.out.print(" ");
        System.out.print((x > 1) && (x++ > 1));

        StringTest();

    }

    public static void StringTest() {

        System.out.println(" \n");
        // 这里使用常量池存在的字符串，构建字符串对象
        String s = new String("1");
        s.intern();
        String s2 = "1";
        System.out.println(s == s2);

        // 这里构建一个常量池不存在的字符串对象
        String s3 = new String("1") + new String("1");
        s3.intern();
        String s4 = "11";
        System.out.println(s3 == s4);

        String str = "Welcome to Java".toUpperCase();

    }
}
