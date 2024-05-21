package hust.cs.javacourse.search.index.impl;

import hust.cs.javacourse.search.index.AbstractDocument;
import hust.cs.javacourse.search.index.AbstractDocumentBuilder;
import hust.cs.javacourse.search.index.AbstractTermTuple;
import hust.cs.javacourse.search.parse.AbstractTermTupleStream;
import hust.cs.javacourse.search.parse.impl.LengthTermTupleFilter;
import hust.cs.javacourse.search.parse.impl.PatternTermTupleFilter;
import hust.cs.javacourse.search.parse.impl.StopWordTermTupleFilter;
import hust.cs.javacourse.search.parse.impl.TermTupleScanner;
import hust.cs.javacourse.search.util.Config;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;

/**
 * (docId,docPath,file) ->  AbstractDocument
 */
public class DocumentBuilder extends AbstractDocumentBuilder {
    /**
     * <pre>
     * 由解析文本文档得到的TermTupleStream,构造Document对象.
     * @param docId             : 文档id
     * @param docPath           : 文档绝对路径
     * @param termTupleStream   : 文档对应的TermTupleStream
     * @return Document对象
     * </pre>
     */
    @Override
    public AbstractDocument build(int docId, String docPath, AbstractTermTupleStream termTupleStream) {
        AbstractDocument document = new Document(docId, docPath);
        AbstractTermTuple termTuple = null;
        while ((termTuple = termTupleStream.next()) != null) {
            document.addTuple(termTuple);
        }
        termTupleStream.close();
        return document;
    }

    /**
     * <pre>
     * 由给定的File,构造Document对象.
     * 该方法利用输入参数file构造出AbstractTermTupleStream子类对象后,内部调用
     *      AbstractDocument build(int docId, String docPath, AbstractTermTupleStream termTupleStream)
     * @param docId     : 文档id
     * @param docPath   : 文档绝对路径
     * @param file      : 文档对应File对象
     * @return          : Document对象
     * </pre>
     */
    @Override
    public AbstractDocument build(int docId, String docPath, File file) {
        try {
            AbstractTermTupleStream termTupleStream =
                new StopWordTermTupleFilter(
                    new PatternTermTupleFilter(
                        new LengthTermTupleFilter(
                            new TermTupleScanner(
                                new BufferedReader(
                                    new FileReader(file)
                                        )))));
            // 一层层地装饰
            return build(docId, docPath, termTupleStream);
        }catch (IOException e){e.printStackTrace();}
        return null;
    }

    public static void main(String[] args) {
        DocumentBuilder documentBuilder = new DocumentBuilder();
        String path = "C:\\Users\\bobby\\DATA\\Git\\Java\\homework\\SearchEngineForStudent\\Experiment1Test(JDK17)\\test\\text\\2.txt";
        AbstractDocument document = documentBuilder.build(1,path,new File(path));
//        AbstractDocument document = documentBuilder.build(1, Config.DOC_DIR+"1.txt",new File(Config.DOC_DIR+"1.txt"));
        System.out.println(document);
    }
}
