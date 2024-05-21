package hust.cs.javacourse.search.parse.impl;

import hust.cs.javacourse.search.index.AbstractTermTuple;
import hust.cs.javacourse.search.index.impl.Term;
import hust.cs.javacourse.search.index.impl.TermTuple;
import hust.cs.javacourse.search.parse.AbstractTermTupleScanner;
import hust.cs.javacourse.search.parse.AbstractTermTupleStream;
import hust.cs.javacourse.search.util.Config;
import hust.cs.javacourse.search.util.StringSplitter;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class TermTupleScanner extends AbstractTermTupleScanner {

    StringSplitter splitter = new StringSplitter();
    List<String> termsBuf = new ArrayList<>();
    int termPosition = 0;

    {
        splitter.setSplitRegex(Config.STRING_SPLITTER_REGEX);
    }
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
            // termsBuf为空时读取一行并保存
            while (termsBuf.isEmpty()){
                String line = input.readLine();
                if(line == null){
                    // 文件结尾
                    return null;
                }
                termsBuf=splitter.splitByRegex(line);
                // 这里termsBuf也可能为空
            }
            // 接下来构造一个Term
            Term term=new Term(termsBuf.get(0).toLowerCase());
            termsBuf.remove(0);

            // 接下来构造一个TermTuple并返回之
            return new TermTuple(term, termPosition++);
        }catch (IOException e){
            e.printStackTrace();
        }
        return null;
    }

    public static void main(String[]args){
        try {
            AbstractTermTupleStream stream = new TermTupleScanner(
                    new BufferedReader(
                            new FileReader(
                                    new File(Config.DOC_DIR+"1.txt")))
            );
            stream=new LengthTermTupleFilter(stream);
            stream=new PatternTermTupleFilter(stream);
            stream=new StopWordTermTupleFilter(stream);

            AbstractTermTuple termTuple = null;
            while ((termTuple = stream.next())!=null){
                System.out.print(termTuple);
                termTuple = stream.next();
            }

        } catch (FileNotFoundException e) {
            throw new RuntimeException(e);
        }
    }
}
