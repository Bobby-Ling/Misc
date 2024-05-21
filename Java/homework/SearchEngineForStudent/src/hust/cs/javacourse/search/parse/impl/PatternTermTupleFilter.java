package hust.cs.javacourse.search.parse.impl;

import hust.cs.javacourse.search.index.AbstractTermTuple;
import hust.cs.javacourse.search.parse.AbstractTermTupleFilter;
import hust.cs.javacourse.search.parse.AbstractTermTupleStream;
import hust.cs.javacourse.search.util.Config;

import java.util.regex.Pattern;

public class PatternTermTupleFilter extends AbstractTermTupleFilter {
    private Pattern pattern = Pattern.compile(Config.TERM_FILTER_PATTERN);

    /**
     * 构造函数
     *
     * @param input ：Filter的输入，类型为AbstractTermTupleStream
     */
    public PatternTermTupleFilter(AbstractTermTupleStream input) {
        super(input);
    }

    /**
     * 构造函数
     * @param input ：Filter的输入，类型为AbstractTermTupleStream
     * @param regex ：正则表达式字符串
     */
    public PatternTermTupleFilter(AbstractTermTupleStream input, String regex) {
        super(input);
        this.pattern = Pattern.compile(regex);
    }

    /**
     * 获得下一个三元组
     *
     * @return 下一个三元组；如果到了流的末尾，返回null
     */
    @Override
    public AbstractTermTuple next() {
        AbstractTermTuple nextTermTuple = input.next();
        if(nextTermTuple == null){
            return null;
        }
        if(pattern.matcher(nextTermTuple.term.getContent()).matches()){
            return nextTermTuple;
        }else{
            return this.next();
        }
    }

    /**
     * 手动设置regex, 默认regex为Config.TERM_FILTER_PATTERN
     * @param regex 正则表达式字符串
     */
    public void setPattern(String regex) {
        this.pattern = Pattern.compile(regex);
    }
}
