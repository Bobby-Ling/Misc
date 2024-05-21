package hust.cs.javacourse.search.util;

import java.util.LinkedList;
import java.util.List;

public class HightLighter {
    public static String hightLight(String content, List<Integer> postions) {
        String[] words = content.split(Config.STRING_SPLITTER_REGEX);
        StringBuilder result = new StringBuilder();
        int index = 0;

        for (int i = 0; i < words.length ; i++) {
            if (index < postions.size() && i == postions.get(index)) {
                result.append("\u001B[1m\u001B[33m").append(words[i]).append("\u001B[0m");
                // 高亮显示第n个单词
                index++;
            } else {
                result.append(words[i]);
            }
            if (i < words.length - 1) {
                result.append(" ");
            }
        }
        return result.toString();
    }
}
