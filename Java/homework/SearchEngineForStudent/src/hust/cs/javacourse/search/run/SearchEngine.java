package hust.cs.javacourse.search.run;

import hust.cs.javacourse.search.index.AbstractDocumentBuilder;
import hust.cs.javacourse.search.index.AbstractIndex;
import hust.cs.javacourse.search.index.AbstractIndexBuilder;
import hust.cs.javacourse.search.index.impl.DocumentBuilder;
import hust.cs.javacourse.search.index.impl.Index;
import hust.cs.javacourse.search.index.impl.IndexBuilder;
import hust.cs.javacourse.search.index.impl.Term;
import hust.cs.javacourse.search.query.AbstractHit;
import hust.cs.javacourse.search.query.AbstractIndexSearcher;
import hust.cs.javacourse.search.query.Sort;
import hust.cs.javacourse.search.query.impl.IndexSearcher;
import hust.cs.javacourse.search.query.impl.SimpleSorter;
import hust.cs.javacourse.search.util.Config;
import hust.cs.javacourse.search.util.HighLighter;

import java.io.File;
import java.util.Scanner;

public class SearchEngine {
    public static void main(String[] args) {
        System.out.println("凌诚睿 CS2205 U202215495\n");

        AbstractIndex index;
        String indexFile = Config.INDEX_DIR+Config.INDEX_FILENAME;

        String option = "-1";
        while (option != "0") {
            switch (option) {
                case "0":
                    return;
                case "1":
                    System.out.println("当前Config: \n" + new Config().toString());
                    System.out.println("输入DOC_DIR(默认为Config.DOC_DIR)");
                    String docDir = new Scanner(System.in).nextLine(); // 读取一行输入
                    File file = new File(docDir);
                    if(docDir.isEmpty()||!(file.exists()&&file.isDirectory())){
                        System.out.println("使用默认值");
                        docDir = Config.DOC_DIR;
                    }
                    // 开始建立索引
                    AbstractDocumentBuilder documentBuilder = new DocumentBuilder();
                    AbstractIndexBuilder indexBuilder = new IndexBuilder(documentBuilder);
                    System.out.println("开始建立index ... 输入目录为: " + docDir);
                    index = indexBuilder.buildIndex(Config.DOC_DIR);
                    index.optimize();
                    //控制台打印index的内容
                    System.out.println("打印index的内容:");
                    System.out.println(index);
                    //索引保存到文件
                    System.out.println("index保存在" + indexFile);
                    index.save(new File(indexFile));
                    break;
                case "2":
                    System.out.println("输入index的路径(默认为:"+indexFile+")");
                    String indexPath = new Scanner(System.in).nextLine(); // 读取一行输入
                    File newIndexFile = new File(indexPath);
                    if(indexPath.isEmpty()||!(newIndexFile.exists()&&newIndexFile.isFile())){
                        System.out.println("使用默认值");
                        indexPath = indexFile;
                        newIndexFile = new File(indexPath);
                    }

                    //从文件读取index
                    index = new Index();
                    //创建一个空的index
                    index.load(newIndexFile);
                    //从文件加载对象的内容
                    System.out.println("打印index的内容:");
                    System.out.println(index);
                    break;
                case "3":
                    System.out.println("输入搜索词:");
                    String input = new Scanner(System.in).nextLine();
                    String[] words = input.split(" ");

                    Sort simpleSorter = new SimpleSorter();
                    AbstractIndexSearcher searcher = new IndexSearcher();
                    searcher.open(indexFile);

                    switch (words.length) {
                        case 1:
                            System.out.println("单搜索词\n");
                            AbstractHit[] hits = searcher.search(new Term(words[0]), simpleSorter);
                            for(AbstractHit hit : hits){
                                System.out.println(hit);
                                System.out.println("查找结果：");
                                System.out.println(new HighLighter().highLight(hit.getContent(),hit.getTermPostingMapping().values().iterator().next().getPositions()));
                                System.out.println();
                            }
                            break;
                        case 3:
                            switch (words[1]) {
                                case "&":
                                    System.out.println("多搜索词 AND");
                                    AbstractHit[] hitsAnd = searcher.search(
                                            new Term(words[0]),
                                            new Term(words[2]),
                                            simpleSorter,
                                            AbstractIndexSearcher.LogicalCombination.AND);
                                    for(AbstractHit hit : hitsAnd){
                                        System.out.println(hit);
                                        System.out.println("查找结果：");
                                        System.out.println(hit.toHighLightString(new HighLighter()));
                                        System.out.println();
                                    }
                                    break;
                                case "|":
                                    System.out.println("多搜索词 OR\n");
                                    AbstractHit[] hitsOR = searcher.search(
                                            new Term(words[0]),
                                            new Term(words[2]),
                                            simpleSorter,
                                            AbstractIndexSearcher.LogicalCombination.OR);
                                    for(AbstractHit hit : hitsOR){
                                        System.out.println(hit);
                                        System.out.println("查找结果：");
                                        System.out.println(hit.toHighLightString(new HighLighter()));
                                        System.out.println();
                                    }
                                    break;
                                default:
                            }
                            break;
                        default:
                            System.out.println("无效输入");
                    }
                    break;
                default:
                    System.out.println("1:\t从目录建立索引并保存");
                    System.out.println("2:\t读取构建好的索引");
                    System.out.println("3:\t搜索");
                    System.out.println("\t一行输入1个为单搜索词");
                    System.out.println("\t双搜索词输入方法如下(通过空格区分)");
                    System.out.println("\t\t双搜索词OR:  A | B\t显示含有搜索词A/B任意一个的结果");
                    System.out.println("\t\t双搜索词AND: A & B\t显示同时含有搜索词A/B的结果");
                    System.out.println("0:\t退出");
                    System.out.println("其他:\t打印操作说明");
            }
            option = new Scanner(System.in).nextLine();
        }
        return;
    }
}
