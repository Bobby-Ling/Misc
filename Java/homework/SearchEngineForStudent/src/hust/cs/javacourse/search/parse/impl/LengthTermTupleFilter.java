package hust.cs.javacourse.search.parse.impl;

import hust.cs.javacourse.search.index.AbstractTermTuple;
import hust.cs.javacourse.search.parse.AbstractTermTupleFilter;
import hust.cs.javacourse.search.parse.AbstractTermTupleStream;
import hust.cs.javacourse.search.util.Config;

public class LengthTermTupleFilter extends AbstractTermTupleFilter {
    /**
     * 构造函数
     *
     * @param input ：Filter的输入，类型为AbstractTermTupleStream
     */
    public LengthTermTupleFilter(AbstractTermTupleStream input) {
        super(input);
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
        String termString=nextTermTuple.term.getContent();
        if(termString.length()<= Config.TERM_FILTER_MAXLENGTH &&
                termString.length()>=Config.TERM_FILTER_MINLENGTH){
            return nextTermTuple;
        }else{
            return this.next();
        }
    }
}
