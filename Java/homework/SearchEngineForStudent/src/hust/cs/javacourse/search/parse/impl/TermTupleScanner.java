package hust.cs.javacourse.search.parse.impl;

import hust.cs.javacourse.search.index.AbstractTermTuple;
import hust.cs.javacourse.search.index.impl.TermTuple;
import hust.cs.javacourse.search.parse.AbstractTermTupleScanner;

import java.io.BufferedReader;
import java.io.IOException;

public class TermTupleScanner extends AbstractTermTupleScanner {
    /**
     * 缺省构造函数
     */
    public TermTupleScanner() {
    }

    /**
     * 构造函数
     *
     * @param input ：指定输入流对象，应该关联到一个文本文件
     */
    public TermTupleScanner(BufferedReader input) {
        super(input);
    }

    /**
     * 获得下一个三元组
     *
     * @return 下一个三元组；如果到了流的末尾，返回null
     */
    @Override
    public AbstractTermTuple next() {
        try {
            char[] buf = new char[1024];
            this.input.read(buf);
//            TermTuple termTuple= new TermTuple(,this.input)
        }catch (IOException e){
            e.printStackTrace();
        }
    }
}
