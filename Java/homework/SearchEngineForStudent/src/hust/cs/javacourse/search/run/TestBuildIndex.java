package hust.cs.javacourse.search.run;

import hust.cs.javacourse.search.index.AbstractDocumentBuilder;
import hust.cs.javacourse.search.index.AbstractIndex;
import hust.cs.javacourse.search.index.AbstractIndexBuilder;
import hust.cs.javacourse.search.index.AbstractTermTuple;
import hust.cs.javacourse.search.index.impl.DocumentBuilder;
import hust.cs.javacourse.search.index.impl.Index;
import hust.cs.javacourse.search.index.impl.IndexBuilder;
import hust.cs.javacourse.search.parse.AbstractTermTupleStream;
import hust.cs.javacourse.search.parse.impl.LengthTermTupleFilter;
import hust.cs.javacourse.search.parse.impl.PatternTermTupleFilter;
import hust.cs.javacourse.search.parse.impl.StopWordTermTupleFilter;
import hust.cs.javacourse.search.parse.impl.TermTupleScanner;
import hust.cs.javacourse.search.util.Config;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;

/**
 * 测试索引构建
 */
public class TestBuildIndex {
    public static void main(String[] args){
        AbstractDocumentBuilder documentBuilder = new DocumentBuilder();
        AbstractIndexBuilder indexBuilder = new IndexBuilder(documentBuilder);
        String rootDir = Config.DOC_DIR;
        System.out.println("Start build index ...");
        AbstractIndex index = indexBuilder.buildIndex(rootDir);
        index.optimize();
        System.out.println(index);
        //控制台打印index的内容

        //测试保存到文件
        String indexFile = Config.INDEX_DIR + "index.dat";
        index.save(new File(indexFile));
        //索引保存到文件

        //测试从文件读取
        AbstractIndex index2 = new Index();
        //创建一个空的index
        index2.load(new File(indexFile));
        //从文件加载对象的内容
        System.out.println("\n-------------------\n");
        System.out.println(index2);
        //控制台打印index2的内容
    }
}


//public class TestBuildIndex {
//    /**
//     *  索引构建程序入口
//     * @param args : 命令行参数
//     */
//    public static void main(String[] args){
//        AbstractIndexBuilder indexBuilder = new IndexBuilder(new DocumentBuilder());
////        AbstractIndex index = indexBuilder.buildIndex(Config.DOC_DIR);
//        AbstractIndex index = indexBuilder.buildIndex("C:\\Users\\bobby\\DATA\\Git\\Java\\homework\\SearchEngineForStudent\\Experiment1Test(JDK17)\\test\\text");
//        System.out.println(index.toString());
//        File file = new File(Config.INDEX_DIR + Config.INDEX_FILENAME);
//        index.save(file);
//    }
//}

