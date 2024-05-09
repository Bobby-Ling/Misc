package homework.ch11_13.p4;

public class Test {
    public static void main(String[] args) {
//        Component computer = ComponentFactory.create();
//        System.out.println(computer);

        //利用迭代器遍历组件树的根节点以下每个节点
        //首先打印根节点
        Component computer = ComponentFactory.create();
        System.out.println("id: " + computer.getId() + ", name: " +
                computer.getName() + ", price:" + computer.getPrice());
        ComponentIterator it = computer.createIterator(); // 首先得到迭代器
        while (it.hasNext()) {
            Component c = it.next();
            //注意这里不能打印c.toString(), toString()方法会递归调用子组件的toString()
            System.out.println("id: " + c.getId() + ", name: " +
                    c.getName() + ", price:" + c.getPrice());
        }
        new Test().test1();
    }

    public void test1() {
        int id = 0;
        String aName1 = "aaa1";
        String aName2 = "aaa2";
        String aName3 = "aaa3";
        String aName4 = "aaa4";
        double aPrice1 = 5.0;
        double aPrice2 = 10.0;
        double aPrice3 = 15.0;
        double aPrice4 = 25.0;
        Component a1 = new AtomicComponent(id++, aName1, aPrice1);
        Component a2 = new AtomicComponent(id++, aName2, aPrice2);
        Component a3 = new AtomicComponent(id++, aName3, aPrice3);
        Component a4 = new AtomicComponent(id++, aName4, aPrice4);
        String cName1 = "ccc1";
        String cName2 = "ccc2";
        String cName3 = "ccc3";
        Component c1 = new CompositeComponent(id++, cName1, 10.0);
        Component c2 = new CompositeComponent(id++, cName2, 10.0);
        String tName = "root";
        Component root = new CompositeComponent(id++, tName, 100.0);
        c1.add(a1);
        c1.add(a2);
        c1.add(c2);
        c2.add(a3);
        c2.add(a4);
        root.add(c1);

        ComponentIterator it = root.createIterator(); // 首先得到迭代器
        while (it.hasNext()) {
            Component c = it.next();
            //注意这里不能打印c.toString(), toString()方法会递归调用子组件的toString()
            System.out.println("id: " + c.getId() + ", name: " +
                    c.getName() + ", price:" + c.getPrice());
        }

        System.out.println(root.calcPrice());
        System.out.println(root.getPrice());
        System.out.println(c1.calcPrice());
        System.out.println(c1.getPrice());
    }
}
