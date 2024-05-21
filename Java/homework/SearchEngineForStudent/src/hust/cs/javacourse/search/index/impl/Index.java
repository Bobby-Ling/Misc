package hust.cs.javacourse.search.index.impl;

import hust.cs.javacourse.search.index.*;

import java.io.*;
import java.util.ArrayList;
import java.util.Map;
import java.util.Set;

/**
 * <pre style="font-family: '微软雅黑', Consolas, monospace;"/>
 * Index
 * Map<Integer, String> docIdToDocPathMapping
 * Map<AbstractTerm, AbstractPostingList> termToPostingListMapping
 */
public class Index extends AbstractIndex {
    /**
     * 返回索引的字符串表示
     *
     * @return 索引的字符串表示
     */
    @Override
    public String toString() {
        return "termToPostingListMapping: " + termToPostingListMapping +
                "\ndocIdToDocPathMapping: " + docIdToDocPathMapping;
    }

    /**
     * 添加文档到索引，更新索引内部的HashMap <br>
     * document指代一个文档, 包含List tuples <br>
     * TermTuple(term,freq=1,curPos) <br>
     * @param document ：文档的AbstractDocument子类型表示
     */
    @Override
    public void addDocument(AbstractDocument document) {
        // 更新termToPostingListMapping
        if(document == null) {
            return;
        }
        for(AbstractTermTuple abstractTermTuple: document.getTuples()){
            // 对于document中的每一个TermTuple
            // 没有与Term对应的KV对就新建一个
            if(!termToPostingListMapping.containsKey(abstractTermTuple.term)){
                termToPostingListMapping.put(abstractTermTuple.term,new PostingList());
            }
            // 找到对应自己Term的PostingList
            AbstractPostingList postingList=termToPostingListMapping.get(abstractTermTuple.term);
            // 如果postingList为空, 创建一个没有任何单词的posting
            if(postingList.indexOf(document.getDocId())==-1){
                postingList.add(
                        new Posting(document.getDocId(), 0, new ArrayList<Integer>()));
            }
            // 找到对应自己docId的Posting
            AbstractPosting posting=postingList.get(postingList.indexOf(document.getDocId()));
            // 加入这个Term
            posting.setFreq(posting.getFreq()+1);
            posting.getPositions().add(abstractTermTuple.curPos);
        }

        // 更新docIdToDocPathMapping
        docIdToDocPathMapping.put(document.getDocId(),document.getDocPath());
    }

    /**
     * <pre>
     * 从索引文件里加载已经构建好的索引.内部调用FileSerializable接口方法readObject即可
     * @param file ：索引文件
     * </pre>
     */
    @Override
    public void load(File file) {
        try {
            ObjectInputStream in = new ObjectInputStream(new FileInputStream(file));
            readObject(in);
        } catch (IOException e) {e.printStackTrace();}
    }

    /**
     * <pre>
     * 将在内存里构建好的索引写入到文件. 内部调用FileSerializable接口方法writeObject即可
     * @param file ：写入的目标索引文件
     * </pre>
     */
    @Override
    public void save(File file) {
        try {
            ObjectOutputStream oos = new ObjectOutputStream(
                    new FileOutputStream(file)
            );
            writeObject(oos);
        } catch (IOException e) {e.printStackTrace();}
    }

    /**
     * 返回指定单词的PostingList
     *
     * @param term : 指定的单词
     * @return 指定单词的PostingList;如果索引字典没有该单词，则返回null
     */
    @Override
    public AbstractPostingList search(AbstractTerm term) {
        return termToPostingListMapping.get(term);
    }

    /**
     * 返回索引的字典.字典为索引里所有单词的并集
     *
     * @return 索引中Term列表
     */
    @Override
    public Set<AbstractTerm> getDictionary() {
        return termToPostingListMapping.keySet();
    }

    /**
     * <pre>
     * 对索引进行优化，包括：
     *      对索引里每个单词的PostingList按docId从小到大排序
     *      同时对每个Posting里的positions从小到大排序
     * 在内存中把索引构建完后执行该方法
     * </pre>
     */
    @Override
    public void optimize() {
        termToPostingListMapping.forEach((term,postingList)->{
            postingList.sort();
        });
    }

    /**
     * 根据docId获得对应文档的完全路径名
     *
     * @param docId ：文档id
     * @return  对应文档的完全路径名
     */
    @Override
    public String getDocName(int docId) {
        return docIdToDocPathMapping.get(docId);
    }

    /**
     * 写到二进制文件
     *
     * @param out :输出流对象
     */
    @Override
    public void writeObject(ObjectOutputStream out) {
        try {
            out.writeObject(docIdToDocPathMapping);
            out.writeObject(termToPostingListMapping);
        }catch (Exception e){e.printStackTrace();}
    }

    /**
     * 从二进制文件读
     *
     * @param in ：输入流对象
     */
    @Override
    public void readObject(ObjectInputStream in) {
        try {
            docIdToDocPathMapping = (Map<Integer, String>) in.readObject();
            termToPostingListMapping = (Map<AbstractTerm, AbstractPostingList>) in.readObject();
        }catch (IOException | ClassNotFoundException e){e.printStackTrace();}
        // 可以捕获多种异常
    }
}
