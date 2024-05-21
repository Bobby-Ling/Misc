package hust.cs.javacourse.search.query.impl;

import hust.cs.javacourse.search.index.AbstractPosting;
import hust.cs.javacourse.search.index.AbstractPostingList;
import hust.cs.javacourse.search.index.AbstractTerm;
import hust.cs.javacourse.search.index.impl.Index;
import hust.cs.javacourse.search.index.impl.IndexBuilder;
import hust.cs.javacourse.search.query.AbstractHit;
import hust.cs.javacourse.search.query.AbstractIndexSearcher;
import hust.cs.javacourse.search.query.Sort;
import hust.cs.javacourse.search.util.HighLighter;

import java.io.File;
import java.util.*;

public class IndexSearcher extends AbstractIndexSearcher {
    /**
     * 从指定索引文件打开索引，加载到index对象里. 一定要先打开索引，才能执行search方法
     *
     * @param indexFile ：指定索引文件
     */
    @Override
    public void open(String indexFile) {
        index.load(new File(indexFile));
        index.optimize();
    }

    /**
     * 根据单个检索词进行搜索
     *
     * @param queryTerm ：检索词
     * @param sorter    ：排序器
     * @return 命中结果数组, 搜不到返回null
     */
    @Override
    public AbstractHit[] search(AbstractTerm queryTerm, Sort sorter) {
        List<AbstractHit> hits = new ArrayList<>();
        AbstractPostingList postingList = index.search(queryTerm);
        if (postingList == null) {
            // 可能搜索不出来
            return null;
        }
        for (int i = 0; i < postingList.size(); i++) {
            AbstractPosting posting = postingList.get(i);
            int docId = posting.getDocId();
            String docPath = index.getDocName(posting.getDocId());
            Map<AbstractTerm, AbstractPosting> map = new HashMap<>();
            map.put(queryTerm,posting);
            hits.add(new Hit(docId,docPath,map));
        }
        sorter.sort(hits);
        // (AbstractHit[]) hits.toArray()不能转换
        // TODO ???
        return hits.toArray(new AbstractHit[0]);
    }

    /**
     * 根据二个检索词进行搜索
     *
     * @param queryTerm1 ：第1个检索词
     * @param queryTerm2 ：第2个检索词
     * @param sorter     ：    排序器
     * @param combine    ：   多个检索词的逻辑组合方式
     * @return 命中结果数组
     */
    @Override
    public AbstractHit[] search(AbstractTerm queryTerm1, AbstractTerm queryTerm2, Sort sorter, LogicalCombination combine) {
        AbstractHit[] hitsArray1 = search(queryTerm1,sorter);
        AbstractHit[] hitsArray2 = search(queryTerm2,sorter);
        // 都没搜到
        if (hitsArray1 == null) {
            return hitsArray2;
        }else if (hitsArray2 == null) {
            return hitsArray1;
        }
        // 下面可以保证hitsArray1和hitsArray2不为null

        // 使用Arrays.asList()方法将数组转换List
        List<AbstractHit> hits1 = Arrays.asList(hitsArray1);
        List<AbstractHit> hits2 = Arrays.asList(hitsArray2);

        List<AbstractHit> result = new ArrayList<>();

        // 求OR
        // 一个hits以docId为单位, 一个docId对应一个搜索结果
        // 因此下面合并这些搜索结果
        result = hits1;
        for (int i = 0; i < result.size(); i++) {
            for (int j = 0; j < hits2.size(); j++) {
                if(result.get(i).getDocId()==hits2.get(j).getDocId()){
                    result.get(i).getTermPostingMapping().putAll(
                            hits2.get(j).getTermPostingMapping());
                }
            }
        }

        // 如果求OR, 直接就完毕了
        if (combine == LogicalCombination.OR){
            return result.toArray(new AbstractHit[0]);
        }

        // 求AND, 将每个文档不同时含有两个词的删去即可
        List<AbstractHit> newResult = new ArrayList<>();
        if (combine==LogicalCombination.AND){
            for (AbstractHit abstractHit : result) {
                if (abstractHit.getTermPostingMapping().size() == 2) {
                    newResult.add(abstractHit);
                }
            }
        }
        return newResult.toArray(new AbstractHit[0]);
    }
}
