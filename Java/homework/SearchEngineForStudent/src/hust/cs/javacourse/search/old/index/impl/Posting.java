package hust.cs.javacourse.search.index.impl;

import hust.cs.javacourse.search.index.AbstractPosting;

import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.Comparator;
import java.util.List;

public class Posting extends AbstractPosting {
    /**
     * 缺省构造函数
     */
    public Posting() {
    }

    /**
     * 构造函数
     *
     * @param docId     ：包含单词的文档id
     * @param freq      ：单词在文档里出现的次数
     * @param positions ：单词在文档里出现的位置
     */
    public Posting(int docId, int freq, List<Integer> positions) {
        super(docId, freq, positions);
    }

    /**
     * 判断二个Posting内容是否相同
     *
     * @param obj ：要比较的另外一个Posting
     * @return 如果内容相等返回true，否则返回false
     */
    @Override
    public boolean equals(Object obj) {
        if(obj instanceof Posting anotherPosting){
            if(this==anotherPosting){
                return true;
            }
            if(this.freq==anotherPosting.freq&&
                    this.docId== anotherPosting.docId&&
                    this.positions.size()==anotherPosting.positions.size()){
                for(int i=0; i<positions.size(); i++){
                    if(!this.positions.get(i).equals(anotherPosting.positions.get(i))){
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        return false;
    }

    /**
     * 返回Posting的字符串表示
     *
     * @return 字符串
     */
    @Override
    public String toString() {
        return this.getDocId() + "\t" + this.getFreq() + "\t" + this.getPositions().toString();
    }

    /**
     * 返回包含单词的文档id
     *
     * @return ：文档id
     */
    @Override
    public int getDocId() {
        return this.docId;
    }

    /**
     * 设置包含单词的文档id
     *
     * @param docId ：包含单词的文档id
     */
    @Override
    public void setDocId(int docId) {
        this.docId = docId;
    }

    /**
     * 返回单词在文档里出现的次数
     *
     * @return ：出现次数
     */
    @Override
    public int getFreq() {
        return this.freq;
    }

    /**
     * 设置单词在文档里出现的次数
     *
     * @param freq :单词在文档里出现的次数
     */
    @Override
    public void setFreq(int freq) {
        this.freq = freq;
    }

    /**
     * 返回单词在文档里出现的位置列表
     *
     * @return ：位置列表
     */
    @Override
    public List<Integer> getPositions() {
        return this.positions;
    }

    /**
     * 设置单词在文档里出现的位置列表
     *
     * @param positions ：单词在文档里出现的位置列表
     */
    @Override
    public void setPositions(List<Integer> positions) {
        this.positions = positions;
    }

    /**
     * 比较二个Posting对象的大小（根据docId）
     *
     * @param o ： 另一个Posting对象
     * @return ：二个Posting对象的docId的差值
     */
    @Override
    public int compareTo(AbstractPosting o) {
        return this.getDocId() - o.getDocId();
    }

    /**
     * 对内部positions从小到大排序
     */
    @Override
    public void sort() {
        this.positions.sort(Comparator.naturalOrder());
    }

    /**
     * 写到二进制文件
     *
     * @param out :输出流对象
     */
    @Override
    public void writeObject(ObjectOutputStream out) {

    }

    /**
     * 从二进制文件读
     *
     * @param in ：输入流对象
     */
    @Override
    public void readObject(ObjectInputStream in) {

    }
}
