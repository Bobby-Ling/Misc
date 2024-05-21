package hust.cs.javacourse.search.util;

import java.util.ArrayList;
import java.util.List;

public class HighLighter {

    /**
     *
     * @param content
     * @param positionList 内部会对其进行自然排序
     * @return
     */
    public String highLight(String content, List<Integer> positionList) {
        List<Integer> positions = new ArrayList<Integer>(positionList);
        positions.sort(Integer::compareTo);
        String[] words = content.split(Config.STRING_SPLITTER_REGEX);
        StringBuilder result = new StringBuilder();
        int index = 0;

        for (int i = 0; i < words.length ; i++) {
            if (index < positions.size() && i == positions.get(index)) {
                result.append("\u001B[1m\u001B[33m").append(words[i]).append("\u001B[0m");
                // 高亮显示单词
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
