package hust.cs.javacourse.search.index.impl;

import hust.cs.javacourse.search.index.AbstractTermTuple;

/**
 * TermTuple(单词，出现频率==1，出现的当前位置)
 */
public class TermTuple extends AbstractTermTuple {
    /**
     * (单词，出现频率==1，出现的当前位置)
     * @param term 单词
     * @param curPos 出现位置
     */
    public TermTuple(Term term,int curPos) {
        this.term = term;
        this.curPos = curPos;
    }

    /**
     * 判断二个三元组内容是否相同
     *
     * @param obj ：要比较的另外一个三元组
     * @return 如果内容相等（三个属性内容都相等）返回true，否则返回false
     */
    @Override
    public boolean equals(Object obj) {
        if (obj instanceof TermTuple anotherTermTuple) {
            if(this==anotherTermTuple){
                return true;
            }
            return this.term.equals(anotherTermTuple.term);
        };
        return false;
    }

    /**
     * 获得三元组的字符串表示
     *
     * @return  三元组的字符串表示
     */
    @Override
    public String toString() {
        return "term: "+this.term+"freq: "+freq+"curPos: "+curPos;
    }
}
