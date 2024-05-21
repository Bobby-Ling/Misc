package hust.cs.javacourse.search.run;

import hust.cs.javacourse.search.index.AbstractIndex;
import hust.cs.javacourse.search.index.impl.DocumentBuilder;
import hust.cs.javacourse.search.index.impl.Index;
import hust.cs.javacourse.search.index.impl.IndexBuilder;
import hust.cs.javacourse.search.index.impl.Term;
import hust.cs.javacourse.search.parse.AbstractTermTupleStream;
import hust.cs.javacourse.search.query.AbstractHit;
import hust.cs.javacourse.search.query.AbstractIndexSearcher;
import hust.cs.javacourse.search.query.Sort;
import hust.cs.javacourse.search.query.impl.IndexSearcher;
import hust.cs.javacourse.search.query.impl.SimpleSorter;
import hust.cs.javacourse.search.util.Config;
import hust.cs.javacourse.search.util.HightLighter;

import javax.swing.plaf.nimbus.AbstractRegionPainter;
import java.io.File;
import java.util.ArrayList;

/**
 * 测试搜索
 */
public class TestSearchIndex {
    /**
     *  搜索程序入口
     * @param args ：命令行参数
     */
    public static void main(String[] args){
        AbstractIndex index = new IndexBuilder(new DocumentBuilder()).buildIndex(Config.DOC_DIR);
        index.save(new File(Config.INDEX_DIR + Config.INDEX_FILENAME));

        Sort simpleSorter = new SimpleSorter();
        String indexFile = Config.INDEX_DIR + Config.INDEX_FILENAME;
        AbstractIndexSearcher searcher = new IndexSearcher();
        searcher.open(indexFile);

        System.out.println("单搜索词");
        AbstractHit[] hits = searcher.search(new Term("google"), simpleSorter);
        for(AbstractHit hit : hits){
            System.out.println(hit);
            System.out.println("查找结果：");
            System.out.println(HightLighter.hightLight(hit.getContent(),hit.getTermPostingMapping().values().iterator().next().getPositions()));
            System.out.println();
        }

        System.out.println("多搜索词 OR");
        AbstractHit[] hitsOR = searcher.search(
                new Term("google"),
                new Term("apple"),
                simpleSorter,
                AbstractIndexSearcher.LogicalCombination.OR);
        for(AbstractHit hit : hitsOR){
            System.out.println(hit);
            System.out.println("查找结果：");
            System.out.println(HightLighter.hightLight(hit.getContent(),hit.getTermPostingMapping().values().iterator().next().getPositions()));
            System.out.println();
        }

        System.out.println("多搜索词 AND");
    }
}
