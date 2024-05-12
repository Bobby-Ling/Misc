package hust.cs.javacourse.search.run;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

public class TreeMapTest {
    public static void main(String[] args) {
        Map<Integer,String> map = new TreeMap<Integer,String>();
        map.put(1, "one");
        map.put(2, "two");
        map.put(3, "three");

        map.put(3, "four");
        System.out.println(map);

        Map<Integer, List<String>> map2 = new TreeMap<Integer,List<String>>();
        map2.put(1,new ArrayList<String>());
        map2.get(1).add("one");



        System.out.println(map2);
    }
}
