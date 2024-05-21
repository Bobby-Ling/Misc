package hust.cs.javacourse.search.parse.impl;

import hust.cs.javacourse.search.index.AbstractTerm;
import hust.cs.javacourse.search.index.AbstractTermTuple;
import hust.cs.javacourse.search.parse.AbstractTermTupleFilter;
import hust.cs.javacourse.search.parse.AbstractTermTupleStream;
import hust.cs.javacourse.search.util.StopWords;

import java.util.Arrays;

public class StopWordTermTupleFilter extends AbstractTermTupleFilter {
    private String[] stopWords;

    /**
     * 构造函数
     *
     * @param input ：Filter的输入，类型为AbstractTermTupleStream
     */
    public StopWordTermTupleFilter(AbstractTermTupleStream input) {
        super(input);
        // 关键: 这里将super.input指向了input
        // 导致this.next()具备多态性, 而单独input.next()不会
        stopWords=StopWords.STOP_WORDS;
    }

    /**
     * 构造函数
     * @param input Filter的输入，类型为AbstractTermTupleStream
     * @param stopWords 手动设置stopWords
     */
    public StopWordTermTupleFilter(AbstractTermTupleStream input , String[] stopWords) {
        super(input);
        this.stopWords=stopWords;
    }

    /**
     * 获得下一个三元组
     *
     * @return 下一个三元组；如果到了流的末尾，返回null
     */
    @Override
    public AbstractTermTuple next() {
        // 先调用实际的被装饰者的next方法
        AbstractTermTuple nextTermTuple = input.next();
        if(nextTermTuple == null){
            return null;
        }
        // 实现自己"新装饰"的next()逻辑
        if(Arrays.stream(stopWords).toList().contains(nextTermTuple.term.getContent())){
            return this.next();
        }else {
            return nextTermTuple;
        }
    }

    /**
     * 手动设置stopWords, 默认值为StopWords.STOP_WORDS
     * @param stopWords
     */
    public void setStopWords(String[] stopWords) {
        this.stopWords = stopWords;
    }
}
