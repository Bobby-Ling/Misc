public class HW6_7 {
    public static void main(String[] args) {
        T1(new StringBuffer("str"), 1);
        T2_1();
    }

    public static void T1(final StringBuffer strBuf, final int a) {
        char[][] chArr = new char[4][5];
        int[] intArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        // a = 1;//ERROR
        strBuf.append("append");// OK
    }

    public static void T2_1() {
        String[][] strArr = {
                { "Beijing", "Wuhan" },
                { "Shanghai", "Guangzhou", "Xian" },
                { "Chongqing", "Chengdu" }
        };
        System.out.println(strArr[strArr.length - 1].length);
        System.out.println(strArr[strArr.length - 1][strArr[2].length - 1].length());
    }

}

class Test3 {
    public static void main(String[] args) {
        int[][] intArr2D= createArray(4);
        printArray(intArr2D);
    }
    /**
     *  创建一个不规则二维数组
     *  第一行row列
     *  第二行row - 1列
     *  ...
     *  最后一行1列
     *    数组元素值都为默认值
     * @param row 行数
     * @return 创建好的不规则数组
     */
    public static int[][] createArray(int row) {
        if (row <= 0) {
            return null;
        }
        int[][] intArr2D = new int[row][];
        for (int i = 0; i < intArr2D.length; i++) {
            intArr2D[i] = new int[intArr2D.length - i];
        }
        return intArr2D;
    }

    /**
     * 逐行打印出二维数组, 数组元素之间以空格分开
     * @param a
     */
    public static  void printArray(int[][] a){
        for (int[] row : a) {
            for (int element : row) {
                System.out.print(element + " ");
            }
            System.out.println("");
        }
    }
}

